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
         IRequestHandler<CadastrarVisitantePorMoradorCommand, ValidationResult>,
         IRequestHandler<CadastrarVisitantePorPorteiroCommand, ValidationResult>,
         IRequestHandler<EditarVisitantePorMoradorCommand, ValidationResult>,
         IRequestHandler<EditarVisitantePorPorteiroCommand, ValidationResult>,
         IRequestHandler<RemoverVisitanteCommand, ValidationResult>,
         IDisposable
    {
        private readonly IPortariaRepository _visitanteRepository;

        public VisitanteCommandHandler(IPortariaRepository visitanteRepository)
        {
            _visitanteRepository = visitanteRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarVisitantePorMoradorCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var visitante = VisitanteFactory(request);

            if (visitante.Documento != "")
            {
                if (_visitanteRepository.VisitanteJaCadastradoPorDocumento(visitante.Documento, visitante.Id).Result)
                {
                    AdicionarErro("Documento informado ja consta no sistema.");
                    return ValidationResult;
                }
            }           

            _visitanteRepository.Adicionar(visitante);

            AdicionarEventoVisitanteCadastrado(visitante, request);

            return await PersistirDados(_visitanteRepository.UnitOfWork);
        }
        public async Task<ValidationResult> Handle(CadastrarVisitantePorPorteiroCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var visitante = VisitanteFactory(request);

            if (request.Id != null)
                visitante.SetEntidadeId(request.Id);

            if (visitante.Documento != "")
            {
                if (_visitanteRepository.VisitanteJaCadastradoPorDocumento(visitante.Documento, visitante.Id).Result)
                {
                    AdicionarErro("Documento informado ja consta no sistema.");
                    return ValidationResult;
                }
            }

            _visitanteRepository.Adicionar(visitante);


            AdicionarEventoVisitanteCadastrado(visitante, request);


            return await PersistirDados(_visitanteRepository.UnitOfWork);
        }
        public async Task<ValidationResult> Handle(EditarVisitantePorMoradorCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var visitante = await _visitanteRepository.ObterPorId(request.Id);
            if (visitante == null)
            {
                AdicionarErro("Visitante não encontrado.");
                return ValidationResult;
            }


            visitante.SetNome(request.Nome);
            visitante.SetDocumento(request.Documento, request.TipoDeDocumento);
            visitante.SetEmail(request.Email);
            visitante.SetFoto(request.Foto);
            visitante.SetTipoDeVisitante(request.TipoDeVisitante);
            visitante.SetNomeEmpresa(request.NomeEmpresa);
            visitante.MarcarVisitanteComoPermanente();
            if (!request.VisitantePermanente)
                visitante.MarcarVisitanteComoTemporario();
            visitante.MarcarNaoTemVeiculo();
            if (!request.TemVeiculo)
                visitante.MarcarTemVeiculo();


            if (visitante.Documento != "")
            {
                if (_visitanteRepository.VisitanteJaCadastradoPorDocumento(visitante.Documento, visitante.Id).Result)
                {
                    AdicionarErro("Documento informado ja consta no sistema.");
                    return ValidationResult;
                }
            }           

            

            _visitanteRepository.Atualizar(visitante);

            AdicionarEventoVisitanteEditado(visitante);

            return await PersistirDados(_visitanteRepository.UnitOfWork);
        }
        public async Task<ValidationResult> Handle(EditarVisitantePorPorteiroCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var visitante = await _visitanteRepository.ObterPorId(request.Id);
            if (visitante == null)
            {
                AdicionarErro("Visitante não encontrado.");
                return ValidationResult;
            }


            if (visitante.Documento != "")
            {
                if (_visitanteRepository.VisitanteJaCadastradoPorDocumento(visitante.Documento, visitante.Id).Result)
                {
                    AdicionarErro("Documento informado ja consta no sistema.");
                    return ValidationResult;
                }
            }

            if (!visitante.VisitantePermanente)
            {
                visitante.SetNome(request.Nome);
                visitante.SetDocumento(request.Documento, request.TipoDeDocumento);               
                visitante.SetEmail(request.Email);
                visitante.SetTipoDeVisitante(request.TipoDeVisitante);
                visitante.SetNomeEmpresa(request.NomeEmpresa);
            }
            visitante.SetFoto(request.Foto);
            visitante.MarcarNaoTemVeiculo();
            if (!request.TemVeiculo)
                visitante.MarcarTemVeiculo();

            _visitanteRepository.Atualizar(visitante);

            AdicionarEventoVisitanteEditado(visitante);

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


        private Visitante VisitanteFactory(VisitanteCommand request)
        {
            return new Visitante
                (request.Nome, request.TipoDeDocumento, request.Documento, request.Email,
                 request.Foto, request.CondominioId, request.UnidadeId, request.VisitantePermanente,
                 request.QrCode, request.TipoDeVisitante, request.NomeEmpresa, request.TemVeiculo);
        }

        private void AdicionarEventoVisitanteCadastrado(Visitante visitante, VisitanteCommand request)
        {
            visitante.AdicionarEvento(
                new VisitanteCadastradoEvent(
                    visitante.Id, visitante.Nome, visitante.TipoDeDocumento, visitante.Documento, visitante.Email,
                    visitante.Foto, visitante.CondominioId, request.NomeCondominio, visitante.UnidadeId,
                    request.NumeroUnidade, request.AndarUnidade, request.GrupoUnidade, visitante.VisitantePermanente,
                    visitante.QrCode, visitante.TipoDeVisitante, visitante.NomeEmpresa, visitante.TemVeiculo));
        }

        private void AdicionarEventoVisitanteEditado(Visitante visitante)
        {
            visitante.AdicionarEvento(
                 new VisitanteEditadoEvent(
                     visitante.Id, visitante.Nome, visitante.TipoDeDocumento, visitante.Documento,
                     visitante.Email, visitante.Foto, visitante.VisitantePermanente, visitante.TipoDeVisitante,
                     visitante.NomeEmpresa, visitante.TemVeiculo));
        }

        public void Dispose()
        {
            _visitanteRepository?.Dispose();
        }


    }
}
