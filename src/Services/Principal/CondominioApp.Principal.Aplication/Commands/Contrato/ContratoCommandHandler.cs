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
         IRequestHandler<AdicionarContratoCommand, ValidationResult>,
         IRequestHandler<AtualizarContratoCommand, ValidationResult>,
         IRequestHandler<ApagarContratoCommand, ValidationResult>,
         IRequestHandler<AtivarContratoCommand, ValidationResult>,
         IRequestHandler<DesativarContratoCommand, ValidationResult>,
         IDisposable
    {

        private readonly IPrincipalRepository _condominioRepository;

        public ContratoCommandHandler(IPrincipalRepository condominioRepository)
        {
            _condominioRepository = condominioRepository;
        }


        public async Task<ValidationResult> Handle(AdicionarContratoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var contrato = new Contrato(
                request.CondominioId, request.DataAssinatura, request.TipoPlano,
                request.DescricaoContrato, request.Ativo, request.ArquivoContrato,
                request.QuantidadeDeUnidadesContratado);

            if (!ValidationResult.IsValid) return ValidationResult;


            var condominio = await _condominioRepository.ObterPorId(contrato.CondominioId);
            if (condominio == null)
            {
                AdicionarErro("Condominio não encontrado.");
                return ValidationResult;
            }


            if (contrato.Ativo)
            {
                foreach (var item in condominio.Contratos)
                {
                    item.Desativar();
                    _condominioRepository.AtualizarContrato(item);
                }
            }

            var resultado = condominio.AdicionarContrato(contrato);
            if (!resultado.IsValid) return resultado;           
                

            _condominioRepository.AdicionarContrato(contrato);
            _condominioRepository.Atualizar(condominio);

            condominio.AdicionarEvento(
                new ContratoDefinidoEvent
                (condominio.Id, contrato.Id, contrato.DataAssinatura, contrato.Tipo, contrato.Descricao,
                 contrato.Ativo, contrato.QuantidadeDeUnidadesContratada, contrato.ArquivoContrato));

            condominio.AdicionarEvento(
             new ConfiguracaoDoCondominioAtualizadaEvent(condominio.Id,
             condominio.PortariaAtivada, condominio.PortariaParaMoradorAtivada, condominio.ClassificadoAtivado,
             condominio.ClassificadoParaMoradorAtivado, condominio.MuralAtivado, condominio.MuralParaMoradorAtivado,
             condominio.ChatAtivado, condominio.ChatParaMoradorAtivado, condominio.ReservaAtivada,
             condominio.ReservaNaPortariaAtivada, condominio.OcorrenciaAtivada, condominio.OcorrenciaParaMoradorAtivada,
             condominio.CorrespondenciaAtivada, condominio.CorrespondenciaNaPortariaAtivada,
             condominio.CadastroDeVeiculoPeloMoradorAtivado, condominio.EnqueteAtivada, condominio.ControleDeAcessoAtivado,
             condominio.TarefaAtivada, condominio.OrcamentoAtivado, condominio.AutomacaoAtivada));

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarContratoCommand request, CancellationToken cancellationToken)
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
            contratoBd.SetQuantidadeDeUnidadesContratada(request.QuantidadeDeUnidadesContratado);

            var condominio = _condominioRepository.ObterPorId(contratoBd.CondominioId).Result;
            if (condominio == null)
            {
                AdicionarErro("Condominio não encontrado.");
                return ValidationResult;
            }

            var resultado = condominio.AdicionarContrato(contratoBd);
            if (!resultado.IsValid) return resultado;
          
            _condominioRepository.Atualizar(condominio);

            condominio.AdicionarEvento(
               new ContratoAtualizadoEvent(contratoBd.Id, contratoBd.DataAssinatura, contratoBd.Tipo,
                                           contratoBd.Descricao, contratoBd.QuantidadeDeUnidadesContratada));

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ApagarContratoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var contratoBd = _condominioRepository.ObterContratoPorId(request.Id).Result;

            if (contratoBd == null)
            {
                AdicionarErro("Contrato não encontrado.");
                return ValidationResult;
            }

            _condominioRepository.ApagarContrato(x => x.Id == contratoBd.Id);

            contratoBd.AdicionarEvento(
               new ContratoApagadoEvent(contratoBd.Id));

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtivarContratoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var contratoBd = _condominioRepository.ObterContratoPorId(request.Id).Result;

            if (contratoBd == null)
            {
                AdicionarErro("Contrato não encontrado.");
                return ValidationResult;
            }

            contratoBd.Ativar();

            _condominioRepository.AtualizarContrato(contratoBd);

            contratoBd.AdicionarEvento(
               new ContratoDefinidoEvent(contratoBd.CondominioId, contratoBd.Id, contratoBd.DataAssinatura,
                                           contratoBd.Tipo, contratoBd.Descricao, contratoBd.Ativo,
                                           contratoBd.QuantidadeDeUnidadesContratada, contratoBd.ArquivoContrato));

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(DesativarContratoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var contratoBd = _condominioRepository.ObterContratoPorId(request.Id).Result;

            if (contratoBd == null)
            {
                AdicionarErro("Contrato não encontrado.");
                return ValidationResult;
            }

            contratoBd.Desativar();

            _condominioRepository.AtualizarContrato(contratoBd);

            contratoBd.AdicionarEvento(
               new ContratoDesativadoEvent(contratoBd.Id));

            return await PersistirDados(_condominioRepository.UnitOfWork);
        }


        public void Dispose()
        {
            _condominioRepository?.Dispose();
        }

    }
}
