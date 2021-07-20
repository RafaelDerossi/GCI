using CondominioApp.Core.Enumeradores;
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
         IRequestHandler<AdicionarVisitantePorMoradorCommand, ValidationResult>,
         IRequestHandler<AdicionarVisitantePorPorteiroCommand, ValidationResult>,
         IRequestHandler<AtualizarVisitantePorMoradorCommand, ValidationResult>,
         IRequestHandler<AtualizarVisitantePorPorteiroCommand, ValidationResult>,
         IRequestHandler<ApagarVisitanteCommand, ValidationResult>,
         IDisposable
    {
        private readonly IPortariaRepository _visitanteRepository;

        public VisitanteCommandHandler(IPortariaRepository visitanteRepository)
        {
            _visitanteRepository = visitanteRepository;
        }


        public async Task<ValidationResult> Handle(AdicionarVisitantePorMoradorCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var visitante = VisitanteFactory(request, TipoDeUsuario.MORADOR);

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
        public async Task<ValidationResult> Handle(AdicionarVisitantePorPorteiroCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var visitante = VisitanteFactory(request, TipoDeUsuario.FUNCIONARIO);

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
        public async Task<ValidationResult> Handle(AtualizarVisitantePorMoradorCommand request, CancellationToken cancellationToken)
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
            visitante.SetTipoDeVisitante(request.TipoDeVisitante);
            visitante.SetNomeEmpresa(request.NomeEmpresa);

            if (request.Foto != null)
                visitante.SetFoto(request.Foto);

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
        public async Task<ValidationResult> Handle(AtualizarVisitantePorPorteiroCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var visitante = await _visitanteRepository.ObterPorId(request.Id);
            if (visitante == null)
            {
                AdicionarErro("Visitante não encontrado.");
                return ValidationResult;
            }
           
            if (visitante.TipoDeUsuarioDoCriador != TipoDeUsuario.MORADOR)
            {
                visitante.SetNome(request.Nome);
                visitante.SetDocumento(request.Documento, request.TipoDeDocumento);               
                visitante.SetEmail(request.Email);
                visitante.SetTipoDeVisitante(request.TipoDeVisitante);
                visitante.SetNomeEmpresa(request.NomeEmpresa);
            }

            if (request.Foto != null)
                visitante.SetFoto(request.Foto);

            visitante.MarcarNaoTemVeiculo();
            if (!request.TemVeiculo)
                visitante.MarcarTemVeiculo();

            _visitanteRepository.Atualizar(visitante);

            AdicionarEventoVisitanteEditado(visitante);

            return await PersistirDados(_visitanteRepository.UnitOfWork);
        }
        public async Task<ValidationResult> Handle(ApagarVisitanteCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var visitanteBd = _visitanteRepository.ObterPorId(request.Id).Result;
            if (visitanteBd == null)
            {
                AdicionarErro("Visitante não encontrado.");
                return ValidationResult;
            }            

            _visitanteRepository.Apagar(x=>x.Id == visitanteBd.Id);
            
            //Evento
            visitanteBd.AdicionarEvento(new VisitanteApagadoEvent(visitanteBd.Id));

            return await PersistirDados(_visitanteRepository.UnitOfWork);
        }


        private Visitante VisitanteFactory(VisitanteCommand request, TipoDeUsuario tipoDeUsuarioDoCriador)
        {
            return new Visitante
                (request.Nome, request.TipoDeDocumento, request.Documento, request.Email,
                 request.Foto, request.CondominioId, request.UnidadeId, request.VisitantePermanente,
                 request.TipoDeVisitante, request.NomeEmpresa, request.TemVeiculo,
                 request.CriadorId, request.NomeDoCriador, tipoDeUsuarioDoCriador);
        }

        private void AdicionarEventoVisitanteCadastrado(Visitante visitante, VisitanteCommand request)
        {
            visitante.AdicionarEvento(
                new VisitanteAdicionadoEvent(
                    visitante.Id, visitante.Nome, visitante.TipoDeDocumento, visitante.Documento,
                    visitante.Email, visitante.Foto, visitante.CondominioId, request.NomeCondominio, visitante.UnidadeId,
                    request.NumeroUnidade, request.AndarUnidade, request.GrupoUnidade, visitante.VisitantePermanente,
                    visitante.TipoDeVisitante, visitante.NomeEmpresa, visitante.TemVeiculo,
                    visitante.CriadorId, visitante.NomeDoCriador, visitante.TipoDeUsuarioDoCriador));
        }

        private void AdicionarEventoVisitanteEditado(Visitante visitante)
        {
            visitante.AdicionarEvento(
                 new VisitanteAtualizadoEvent(
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
