using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Portaria.Aplication.Events;
using CondominioApp.Portaria.Domain;
using CondominioApp.Portaria.Domain.Interfaces;
using CondominioApp.Portaria.ValueObjects;
using FluentValidation.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Portaria.Aplication.Commands
{
    public class VisitaCommandHandler : CommandHandler,
         IRequestHandler<CadastrarVisitaPorPorteiroCommand, ValidationResult>,
         IRequestHandler<CadastrarVisitaPorMoradorCommand, ValidationResult>,
         IRequestHandler<EditarVisitaCommand, ValidationResult>,
         IRequestHandler<RemoverVisitaCommand, ValidationResult>,
         IRequestHandler<AprovarVisitaCommand, ValidationResult>,
         IRequestHandler<ReprovarVisitaCommand, ValidationResult>,
         IRequestHandler<IniciarVisitaCommand, ValidationResult>,
         IRequestHandler<TerminarVisitaCommand, ValidationResult>,
         IDisposable
    {
        private IPortariaRepository _visitanteRepository;       

        public VisitaCommandHandler(IPortariaRepository visitanteRepository)
        {
            _visitanteRepository = visitanteRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarVisitaPorPorteiroCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var visita = VisitaFactory(request);           

            _visitanteRepository.AdicionarVisita(visita);

            //Evento
            visita.AdicionarEvento(
              new VisitaCadastradaEvent(
                  visita.Id, visita.DataDeEntrada, visita.Observacao, visita.Status, visita.VisitanteId,
                  visita.NomeVisitante, visita.TipoDeDocumentoVisitante, visita.Documento,
                  visita.EmailVisitante, visita.FotoVisitante, visita.TipoDeVisitante,
                  visita.NomeEmpresaVisitante, visita.CondominioId, request.NomeCondominio, visita.UnidadeId,
                  request.NumeroUnidade, request.AndarUnidade, request.GrupoUnidade, visita.TemVeiculo,
                  visita.Veiculo, visita.MoradorId, request.NomeMorador));

            return await PersistirDados(_visitanteRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(CadastrarVisitaPorMoradorCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var visitante = await _visitanteRepository.ObterPorIdAsNoTracking(request.VisitanteId);
            if (visitante == null)
            {
                AdicionarErro("Visitante não encontrado.");
                return ValidationResult;
            }

            var visita = VisitaFactory(request, visitante);
             
            _visitanteRepository.AdicionarVisita(visita);

            //Evento
            visita.AdicionarEvento(
              new VisitaCadastradaEvent(
                  visita.Id, visita.DataDeEntrada, visita.Observacao, visita.Status, visita.VisitanteId,
                  visita.NomeVisitante, visita.TipoDeDocumentoVisitante, visita.Documento,
                  visita.EmailVisitante, visita.FotoVisitante, visita.TipoDeVisitante,
                  visita.NomeEmpresaVisitante, visita.CondominioId, request.NomeCondominio, visita.UnidadeId,
                  request.NumeroUnidade, request.AndarUnidade, request.GrupoUnidade, visita.TemVeiculo,
                  visita.Veiculo, visita.MoradorId, request.NomeMorador));

            
            return await PersistirDados(_visitanteRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(EditarVisitaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var visitaBd = await _visitanteRepository.ObterVisitaPorId(request.Id);
            if (visitaBd == null)
            {
                AdicionarErro("Visita não encontrada.");
                return ValidationResult;
            }


            var retorno = visitaBd.Editar
                (request.Observacao, request.NomeVisitante, request.TipoDeVisitante, request.NomeEmpresaVisitante,
                request.UnidadeId, request.TemVeiculo, request.Veiculo);
            if (!retorno.IsValid)
                return retorno;


            _visitanteRepository.AtualizarVisita(visitaBd);

            //Evento
            visitaBd.AdicionarEvento(
                 new VisitaEditadaEvent(
                     request.Id, request.Observacao, request.NomeVisitante, request.TipoDeDocumentoVisitante,
                     request.DocumentoVisitante, request.EmailVisitante, request.FotoVisitante,
                     request.TipoDeVisitante, request.NomeEmpresaVisitante, request.UnidadeId,
                     request.NumeroUnidade, request.AndarUnidade, request.GrupoUnidade, request.TemVeiculo,
                     request.Veiculo, request.MoradorId, request.NomeMorador));

            return await PersistirDados(_visitanteRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoverVisitaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var visitaBd = _visitanteRepository.ObterVisitaPorId(request.Id).Result;
            if (visitaBd == null)
            {
                AdicionarErro("Visita não encontrada.");
                return ValidationResult;
            }

            
            var retorno = visitaBd.Remover();
            if (!retorno.IsValid)
                return retorno;

            _visitanteRepository.AtualizarVisita(visitaBd);

            //Evento
            visitaBd.AdicionarEvento(new VisitaRemovidaEvent(request.Id));

            return await PersistirDados(_visitanteRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AprovarVisitaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var visitaBd = _visitanteRepository.ObterVisitaPorId(request.Id).Result;
            if (visitaBd == null)
            {
                AdicionarErro("Visita não encontrada.");
                return ValidationResult;
            }

           
            var retorno = visitaBd.AprovarVisita();
            if (!retorno.IsValid)
                return retorno;

            _visitanteRepository.AtualizarVisita(visitaBd);

            //Evento
            visitaBd.AdicionarEvento(new VisitaAprovadaEvent(request.Id));

            return await PersistirDados(_visitanteRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ReprovarVisitaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var visitaBd = _visitanteRepository.ObterVisitaPorId(request.Id).Result;
            if (visitaBd == null)
            {
                AdicionarErro("Visita não encontrada.");
                return ValidationResult;
            }


            var retorno = visitaBd.ReprovarVisita();
            if (!retorno.IsValid)
                return retorno;

            _visitanteRepository.AtualizarVisita(visitaBd);

            //Evento
            visitaBd.AdicionarEvento(new VisitaReprovadaEvent(request.Id));

            return await PersistirDados(_visitanteRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(IniciarVisitaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var visitaBd = _visitanteRepository.ObterVisitaPorId(request.Id).Result;
            if (visitaBd == null)
            {
                AdicionarErro("Visita não encontrada.");
                return ValidationResult;
            }

             
            var retorno = visitaBd.IniciarVisita();
            if (!retorno.IsValid)
                return retorno;

            _visitanteRepository.AtualizarVisita(visitaBd);

            //Evento
            visitaBd.AdicionarEvento(new VisitaIniciadaEvent(request.Id, request.DataDeEntrada));

            return await PersistirDados(_visitanteRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(TerminarVisitaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var visitaBd = _visitanteRepository.ObterVisitaPorId(request.Id).Result;
            if (visitaBd == null)
            {
                AdicionarErro("Visita não encontrada.");
                return ValidationResult;
            }

            var retorno = visitaBd.TerminarVisita();
            if (!retorno.IsValid)
                return retorno;

            _visitanteRepository.AtualizarVisita(visitaBd);

            //Evento
            visitaBd.AdicionarEvento(new VisitaTerminadaEvent(request.Id, request.DataDeSaida));

            return await PersistirDados(_visitanteRepository.UnitOfWork);
        }




        
        private Visita VisitaFactory(CadastrarVisitaPorPorteiroCommand request)
        {
            return new Visita
                (request.DataDeEntrada, request.Observacao, request.Status,
                 request.VisitanteId, request.NomeVisitante, request.TipoDeDocumentoVisitante,
                 request.DocumentoVisitante, request.EmailVisitante, request.FotoVisitante,
                 request.TipoDeVisitante, request.NomeEmpresaVisitante, request.CondominioId,
                 request.UnidadeId, request.TemVeiculo, request.Veiculo,
                 request.MoradorId, request.NomeMorador);
        }

        private Visita VisitaFactory(CadastrarVisitaPorMoradorCommand request, Visitante visitante)
        {           
            return new Visita
                (request.DataDeEntrada, request.Observacao, request.Status,
                 request.VisitanteId, visitante.Nome, visitante.TipoDeDocumento,
                 visitante.Documento, visitante.Email, visitante.Foto,
                 visitante.TipoDeVisitante, visitante.NomeEmpresa, request.CondominioId,
                 request.UnidadeId, request.TemVeiculo, request.Veiculo,
                 request.MoradorId, request.NomeMorador);
        }


        public void Dispose()
        {
            _visitanteRepository?.Dispose();
        }


    }
}
