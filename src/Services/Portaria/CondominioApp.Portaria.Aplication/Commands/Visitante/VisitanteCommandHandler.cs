using CondominioApp.Core.Messages;
using CondominioApp.Portaria.Aplication.Events;
using CondominioApp.Portaria.Domain;
using CondominioApp.Portaria.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Portaria.Aplication.Commands
{
    public class VisitanteCommandHandler : CommandHandler,
         IRequestHandler<CadastrarVisitanteCommand, ValidationResult>,
         IRequestHandler<EditarVisitanteCommand, ValidationResult>,
         IRequestHandler<RemoverVisitanteCommand, ValidationResult>,
         IDisposable
    {
        private IVisitanteRepository _visitanteRepository;

        public VisitanteCommandHandler(IVisitanteRepository visitanteRepository)
        {
            _visitanteRepository = visitanteRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarVisitanteCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var visitante = VisitanteFactory(request);

            if (visitante.Cpf.Numero != "")
            {
                if (_visitanteRepository.VisitanteJaCadastradoPorCpf(visitante.Cpf, visitante.Id).Result)
                {
                    AdicionarErro("CPF informado ja consta no sistema.");
                    return ValidationResult;
                }
            }

            if (visitante.Rg.Numero != "")
            {
                if (_visitanteRepository.VisitanteJaCadastradoPorRg(visitante.Rg, visitante.Id).Result)
                {
                    AdicionarErro("RG informado ja consta no sistema.");
                    return ValidationResult;
                }
            }

            _visitanteRepository.Adicionar(visitante);

            
            visitante.AdicionarEvento(
                new VisitanteCadastradoEvent(
                    visitante.Id, visitante.Nome, visitante.TipoDeDocumento, visitante.Cpf, visitante.Rg, visitante.Email, visitante.Foto,
                    visitante.CondominioId, visitante.NomeCondominio, visitante.UnidadeId, visitante.NumeroUnidade,
                    visitante.AndarUnidade, visitante.GrupoUnidade, visitante.VisitantePermanente, visitante.QrCode,
                    visitante.TipoDeVisitante, visitante.NomeEmpresa, visitante.TemVeiculo, visitante.Veiculo));


            return await PersistirDados(_visitanteRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(EditarVisitanteCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var visitante = await _visitanteRepository.ObterPorId(request.Id);
            if (visitante == null)
            {
                AdicionarErro("Visitante não encontrado.");
                return ValidationResult;
            }
                
            if (request.Cpf != null)
            {
                if (_visitanteRepository.VisitanteJaCadastradoPorCpf(request.Cpf, request.Id).Result)
                {
                    AdicionarErro("CPF informado ja consta no sistema.");
                    return ValidationResult;
                }
            }

            if (visitante.Rg != null)
            {
                if (_visitanteRepository.VisitanteJaCadastradoPorRg(request.Rg, request.Id).Result)
                {
                    AdicionarErro("RG informado ja consta no sistema.");
                    return ValidationResult;
                }
            }

            visitante.SetNome(request.Nome);
            visitante.SetTipoDeDocumento(request.TipoDeDocumento);
            visitante.SetCpf(request.Cpf);
            visitante.SetRg(request.Rg);
            visitante.SetEmail(request.Email);
            visitante.SetFoto(request.Foto);
            visitante.SetVeiculo(request.Veiculo);
            visitante.SetTipoDeVisitante(request.TipoDeVisitante);
            visitante.SetNomeEmpresa(request.NomeEmpresa);
            

            visitante.MarcarVisitanteComoPermanente();
            if (!request.VisitantePermanente)
                visitante.MarcarVisitanteComoTemporario();


            _visitanteRepository.Atualizar(visitante);


            visitante.AdicionarEvento(
                new VisitanteEditadoEvent(
                    visitante.Id, visitante.Nome, visitante.Cpf, visitante.Rg, visitante.Email, visitante.Foto,
                    visitante.VisitantePermanente, visitante.TipoDeVisitante, visitante.NomeEmpresa, 
                    visitante.TemVeiculo, visitante.Veiculo));


            return await PersistirDados(_visitanteRepository.UnitOfWork);
        }


        public async Task<ValidationResult> Handle(RemoverVisitanteCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var visitanteBd = _visitanteRepository.ObterPorId(request.Id).Result;
            if (visitanteBd == null)
            {
                AdicionarErro("Visitante não encontrado.");
                return ValidationResult;
            }

            visitanteBd.EnviarParaLixeira();

            _visitanteRepository.Atualizar(visitanteBd);

            
            //Evento
            visitanteBd.AdicionarEvento(new VisitanteRemovidoEvent(visitanteBd.Id));


            return await PersistirDados(_visitanteRepository.UnitOfWork);
        }


        private Visitante VisitanteFactory(CadastrarVisitanteCommand request)
        {
            return new Visitante
                (request.Nome, request.TipoDeDocumento, request.Rg, request.Cpf, request.Email,
                 request.Foto, request.CondominioId, request.NomeCondominio, request.UnidadeId,
                 request.NumeroUnidade, request.AndarUnidade, request.GrupoUnidade, request.VisitantePermanente,
                 request.QrCode, request.TipoDeVisitante, request.NomeEmpresa, request.Veiculo);
        }


        public void Dispose()
        {
            _visitanteRepository?.Dispose();
        }


    }
}
