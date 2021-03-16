using CondominioApp.Core.Messages;
using CondominioApp.Principal.Aplication.Events;
using CondominioApp.Principal.Domain;
using CondominioApp.Principal.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Principal.Aplication.Commands
{
    public class ContratoCommandHandler : CommandHandler,
         IRequestHandler<CadastrarContratoCommand, ValidationResult>,
         IRequestHandler<EditarContratoCommand, ValidationResult>,
         IRequestHandler<RemoverContratoCommand, ValidationResult>,
         IDisposable
    {

        private IPrincipalRepository _condominioRepository;

        public ContratoCommandHandler(IPrincipalRepository condominioRepository)
        {
            _condominioRepository = condominioRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarContratoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var contrato = new Contrato(
                request.CondominioId, request.DataAssinatura, request.TipoPlano,
                request.DescricaoContrato, request.Ativo, request.LinkContrato);

            if (!ValidationResult.IsValid) return ValidationResult;


            var condominio = await _condominioRepository.ObterPorId(contrato.CondominioId);
            if (condominio == null)
            {
                AdicionarErro("Condominio não encontrado.");
                return ValidationResult;
            }

            var resultado = condominio.AdicionarContrato(contrato);

            if (!resultado.IsValid) return resultado;


            _condominioRepository.AdicionarContrato(contrato);
            _condominioRepository.Atualizar(condominio);
            

            contrato.AdicionarEvento(
                new ContratoCadastradoEvent(contrato.Id, contrato.CondominioId, contrato.DataAssinatura, contrato.Tipo,
                contrato.Descricao, contrato.Ativo, contrato.Link));            

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(EditarContratoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var contratoBd = _condominioRepository.ObterContratoPorId(request.Id).Result;
            if (contratoBd == null)
            {
                AdicionarErro("Contrato não encontrado.");
                return ValidationResult;
            }

            contratoBd.SetDataAssinatura(request.DataAssinatura);
            contratoBd.SetTipoDePlano(request.TipoPlano);
            contratoBd.SetDescricao(request.DescricaoContrato);
            contratoBd.SetLink(request.LinkContrato);           

            var condominio = _condominioRepository.ObterPorId(contratoBd.CondominioId).Result;
            if (condominio == null)
            {
                AdicionarErro("Condominio não encontrado.");
                return ValidationResult;
            }

            var resultado = condominio.AdicionarContrato(contratoBd);
            if (!resultado.IsValid) return resultado;

            if (request.Ativo)
                contratoBd.Ativar();

            _condominioRepository.Atualizar(condominio);            

            contratoBd.AdicionarEvento(new ContratoEditadoEvent(
                 contratoBd.Id, contratoBd.CondominioId, contratoBd.DataAssinatura, contratoBd.Tipo,
                 contratoBd.Descricao, contratoBd.Ativo, contratoBd.Link));


            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoverContratoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var contratoBd = _condominioRepository.ObterContratoPorId(request.Id).Result;

            if (contratoBd == null)
            {
                AdicionarErro("Contrato não encontrado.");
                return ValidationResult;
            }

            contratoBd.EnviarParaLixeira();

            contratoBd.AdicionarEvento(
             new ContratoRemovidoEvent(contratoBd.Id));

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }


        
        public void Dispose()
        {
            _condominioRepository?.Dispose();
        }

    }
}
