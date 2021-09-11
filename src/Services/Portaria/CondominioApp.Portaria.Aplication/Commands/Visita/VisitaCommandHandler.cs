using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Portaria.Aplication.Events;
using CondominioApp.Portaria.Domain;
using CondominioApp.Portaria.Domain.FlatModel;
using CondominioApp.Portaria.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Portaria.Aplication.Commands
{
    public class VisitaCommandHandler : CommandHandler,
         IRequestHandler<AdicionarVisitaPorPorteiroCommand, ValidationResult>,
         IRequestHandler<AdicionarVisitaPorMoradorCommand, ValidationResult>,
         IRequestHandler<AtualizarVisitaCommand, ValidationResult>,
         IRequestHandler<ApagarVisitaCommand, ValidationResult>,
         IRequestHandler<AprovarVisitaCommand, ValidationResult>,
         IRequestHandler<ReprovarVisitaCommand, ValidationResult>,
         IRequestHandler<IniciarVisitaCommand, ValidationResult>,
         IRequestHandler<TerminarVisitaCommand, ValidationResult>,
         IDisposable
    {
        private readonly IPortariaRepository _portariaRepository;       

        public VisitaCommandHandler(IPortariaRepository portariaRepository)
        {
            _portariaRepository = portariaRepository;
        }


        public async Task<ValidationResult> Handle(AdicionarVisitaPorPorteiroCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var visitante = await _portariaRepository.ObterPorId(request.VisitanteId);
            if (visitante == null)
            {
                AdicionarErro("Visitante não encontrado.");
                return ValidationResult;
            }

            var visita = VisitaFactory(request, visitante);

            _portariaRepository.AdicionarVisita(visita);

            //Evento
            visita.AdicionarEvento(
              new VisitaAdicionadaEvent(
                  visita.Id, visita.DataDeEntrada, visita.Observacao, visita.Status,
                  visita.VisitanteId, visita.NomeVisitante, visita.TipoDeDocumentoVisitante,
                  visita.Documento, visita.EmailVisitante, visita.FotoVisitante,
                  visita.TipoDeVisitante, visita.NomeEmpresaVisitante, visita.CondominioId,
                  request.NomeCondominio, visita.UnidadeId, request.NumeroUnidade, request.AndarUnidade,
                  request.GrupoUnidade, visita.TemVeiculo, visita.Veiculo, visita.MoradorId,
                  request.NomeMorador));

            visita.EnviarPushAvisoDeVisitaNaPortaria();

            return await PersistirDados(_portariaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AdicionarVisitaPorMoradorCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var visitante = await _portariaRepository.ObterPorIdAsNoTracking(request.VisitanteId);
            if (visitante == null)
            {
                AdicionarErro("Visitante não encontrado.");
                return ValidationResult;
            }

            var visita = VisitaFactory(request, visitante);
             
            _portariaRepository.AdicionarVisita(visita);

            //Evento
            visita.AdicionarEvento(
              new VisitaAdicionadaEvent(
                  visita.Id, visita.DataDeEntrada, visita.Observacao, visita.Status, visita.VisitanteId,
                  visita.NomeVisitante, visita.TipoDeDocumentoVisitante, visita.Documento,
                  visita.EmailVisitante, visita.FotoVisitante,
                  visita.TipoDeVisitante, visita.NomeEmpresaVisitante, visita.CondominioId,
                  request.NomeCondominio, visita.UnidadeId, request.NumeroUnidade, request.AndarUnidade,
                  request.GrupoUnidade, visita.TemVeiculo, visita.Veiculo, visita.MoradorId, request.NomeMorador));

            
            return await PersistirDados(_portariaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarVisitaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var visitaBd = await _portariaRepository.ObterVisitaPorId(request.Id);
            if (visitaBd == null)
            {
                AdicionarErro("Visita não encontrada.");
                return ValidationResult;
            }

            var visitante = await _portariaRepository.ObterPorId(request.VisitanteId);
            if (visitante == null)
            {
                AdicionarErro("Visitante não encontrado.");
                return ValidationResult;
            }

            var retorno = visitaBd.Editar
                (request.Observacao, visitante.Nome, request.TipoDeVisitante, request.NomeEmpresaVisitante,
                 request.UnidadeId, request.TemVeiculo, request.Veiculo);
            if (!retorno.IsValid)
                return retorno;


            _portariaRepository.AtualizarVisita(visitaBd);

            //Evento
            visitaBd.AdicionarEvento(
                 new VisitaAtualizadaEvent(
                     request.Id, request.Observacao, visitante.Nome, visitante.TipoDeDocumento,
                     visitante.Documento, visitante.Email, visitante.Foto, request.TipoDeVisitante,
                     request.NomeEmpresaVisitante, request.UnidadeId, request.NumeroUnidade,
                     request.AndarUnidade, request.GrupoUnidade, request.TemVeiculo, request.Veiculo,
                     request.MoradorId, request.NomeMorador));


            return await PersistirDados(_portariaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ApagarVisitaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var visitaBd = _portariaRepository.ObterVisitaPorId(request.Id).Result;
            if (visitaBd == null)
            {
                AdicionarErro("Visita não encontrada.");
                return ValidationResult;
            }
            
            var retorno = visitaBd.Remover();
            if (!retorno.IsValid)
                return retorno;

            _portariaRepository.ApagarVisita(x=>x.Id == visitaBd.Id);

            //Evento
            visitaBd.AdicionarEvento(new VisitaApagadaEvent(request.Id));

            return await PersistirDados(_portariaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AprovarVisitaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var visitaBd = _portariaRepository.ObterVisitaPorId(request.Id).Result;
            if (visitaBd == null)
            {
                AdicionarErro("Visita não encontrada.");
                return ValidationResult;
            }

           
            var retorno = visitaBd.AprovarVisita();
            if (!retorno.IsValid)
                return retorno;

            _portariaRepository.AtualizarVisita(visitaBd);

            //Evento
            visitaBd.AdicionarEvento(new VisitaAprovadaEvent(request.Id));

            return await PersistirDados(_portariaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ReprovarVisitaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var visitaBd = _portariaRepository.ObterVisitaPorId(request.Id).Result;
            if (visitaBd == null)
            {
                AdicionarErro("Visita não encontrada.");
                return ValidationResult;
            }


            var retorno = visitaBd.ReprovarVisita();
            if (!retorno.IsValid)
                return retorno;

            _portariaRepository.AtualizarVisita(visitaBd);

            //Evento
            visitaBd.AdicionarEvento(new VisitaReprovadaEvent(request.Id));

            return await PersistirDados(_portariaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(IniciarVisitaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var visitaBd = _portariaRepository.ObterVisitaPorId(request.Id).Result;
            if (visitaBd == null)
            {
                AdicionarErro("Visita não encontrada.");
                return ValidationResult;
            }

             
            var retorno = visitaBd.IniciarVisita();
            if (!retorno.IsValid)
                return retorno;

            _portariaRepository.AtualizarVisita(visitaBd);

            //Evento
            visitaBd.AdicionarEvento(new VisitaIniciadaEvent(request.Id, request.DataDeEntrada));

            visitaBd.EnviarPushAvisoDeVisitaIniciada();

            return await PersistirDados(_portariaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(TerminarVisitaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var visitaBd = _portariaRepository.ObterVisitaPorId(request.Id).Result;
            if (visitaBd == null)
            {
                AdicionarErro("Visita não encontrada.");
                return ValidationResult;
            }

            var retorno = visitaBd.TerminarVisita();
            if (!retorno.IsValid)
                return retorno;

            _portariaRepository.AtualizarVisita(visitaBd);

            //Evento
            visitaBd.AdicionarEvento(new VisitaTerminadaEvent(request.Id, request.DataDeSaida));

            visitaBd.EnviarPushAvisoDeVisitaTerminada();

            return await PersistirDados(_portariaRepository.UnitOfWork);
        }


        
        private Visita VisitaFactory(AdicionarVisitaPorPorteiroCommand request, Visitante visitante)
        {
            return new Visita
                (request.DataDeEntrada, request.Observacao, request.Status,
                 request.VisitanteId, visitante.Nome, visitante.TipoDeDocumento,
                 visitante.Documento, visitante.Email, visitante.Foto,
                 request.TipoDeVisitante, request.NomeEmpresaVisitante, request.CondominioId,
                 request.UnidadeId, request.TemVeiculo, request.Veiculo,
                 request.MoradorId);
        }

        private Visita VisitaFactory(AdicionarVisitaPorMoradorCommand request, Visitante visitante)
        {           
            return new Visita
                (request.DataDeEntrada, request.Observacao, request.Status,
                 request.VisitanteId, visitante.Nome, visitante.TipoDeDocumento,
                 visitante.Documento, visitante.Email, visitante.Foto,
                 visitante.TipoDeVisitante, visitante.NomeEmpresa, request.CondominioId,
                 request.UnidadeId, request.TemVeiculo, request.Veiculo,
                 request.MoradorId);
        }


        public void Dispose()
        {
            _portariaRepository?.Dispose();
        }


    }
}
