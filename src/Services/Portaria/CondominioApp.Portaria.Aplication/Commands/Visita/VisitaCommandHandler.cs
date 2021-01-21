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
    public class VisitaCommandHandler : CommandHandler,
         IRequestHandler<CadastrarVisitaCommand, ValidationResult>,
         IRequestHandler<EditarVisitaCommand, ValidationResult>,
         IRequestHandler<RemoverVisitaCommand, ValidationResult>,
         IRequestHandler<AprovarVisitaCommand, ValidationResult>,
         IRequestHandler<ReprovarVisitaCommand, ValidationResult>,
         IRequestHandler<IniciarVisitaCommand, ValidationResult>,
         IRequestHandler<TerminarVisitaCommand, ValidationResult>,
         IDisposable
    {
        private IVisitanteRepository _visitanteRepository;       

        public VisitaCommandHandler(IVisitanteRepository visitanteRepository)
        {
            _visitanteRepository = visitanteRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarVisitaCommand request, CancellationToken cancellationToken)
        {
            var visita = VisitaFactory(request);           

            _visitanteRepository.AdicionarVisita(visita);

            //Evento
            visita.AdicionarEvento(
              new VisitaCadastradaEvent(
                  visita.Id, visita.DataDeEntrada, visita.Observacao, visita.Status, visita.VisitanteId,
                  visita.NomeVisitante, visita.TipoDeDocumentoVisitante, visita.CpfVisitante,
                  visita.RgVisitante, visita.EmailVisitante, visita.FotoVisitante, visita.TipoDeVisitante,
                  visita.NomeEmpresaVisitante, visita.CondominioId, visita.NomeCondominio, visita.UnidadeId,
                  visita.NumeroUnidade, visita.AndarUnidade, visita.GrupoUnidade, visita.TemVeiculo,
                  visita.Veiculo, visita.UsuarioId, visita.NomeUsuario));

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
            
            if (visitaBd.ObterStatus() != StatusVisita.PENDENTE)
            {
                AdicionarErro("Visita não pode ser editada pois esta " + visitaBd.ObterStatus().ToString());
                return ValidationResult;
            }

            visitaBd.SetObservacao(request.Observacao);
            visitaBd.SetNomeVisitante(request.NomeVisitante);
            visitaBd.SetTipoDeVisitante(request.TipoDeVisitante);
            visitaBd.SetNomeEmpresaVisitante(request.NomeEmpresaVisitante);
            visitaBd.SetUnidadeId(request.UnidadeId);
            visitaBd.SetNumeroUnidade(request.NumeroUnidade);
            visitaBd.SetAndarUnidade(request.AndarUnidade);
            visitaBd.SetGrupoUnidade(request.GrupoUnidade);
            visitaBd.SetVeiculo(request.Veiculo);
            visitaBd.SetUsuario(request.UsuarioId, request.NomeUsuario);
            
            

            _visitanteRepository.AtualizarVisita(visitaBd);

            //Evento
            visitaBd.AdicionarEvento(
                 new VisitaEditadaEvent(
                     request.Id, request.Observacao, request.NomeVisitante, request.TipoDeDocumentoVisitante,
                     request.CpfVisitante, request.RgVisitante, request.EmailVisitante, request.FotoVisitante,
                     request.TipoDeVisitante, request.NomeEmpresaVisitante, request.UnidadeId,
                     request.NumeroUnidade, request.AndarUnidade, request.GrupoUnidade, request.TemVeiculo,
                     request.Veiculo, request.UsuarioId, request.NomeUsuario));

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

            if (visitaBd.ObterStatus() != StatusVisita.PENDENTE &&
                visitaBd.ObterStatus() != StatusVisita.APROVADA)
            {
                AdicionarErro("Visita não pode ser removida pois ja esta " + visitaBd.ObterStatus().ToString().ToLower());
                return ValidationResult;
            }            

            visitaBd.EnviarParaLixeira();

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

            if (visitaBd.ObterStatus() == StatusVisita.APROVADA)
            {
                AdicionarErro("Visita já esta aprovada.");
                return ValidationResult;
            }
            if (visitaBd.ObterStatus() != StatusVisita.PENDENTE)
            {
                AdicionarErro("Visita não pode ser aprovada pois esta " + visitaBd.ObterStatus().ToString().ToLower());
                return ValidationResult;
            }

            visitaBd.AprovarVisita();

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
            if (visitaBd.ObterStatus() == StatusVisita.REPROVADA)
            {
                AdicionarErro("Visita já esta reprovada.");
                return ValidationResult;
            }
            if (visitaBd.ObterStatus() != StatusVisita.PENDENTE && visitaBd.ObterStatus() != StatusVisita.APROVADA)
            {
                AdicionarErro("Visita não pode ser reprovada pois esta " + visitaBd.ObterStatus().ToString().ToLower());
                return ValidationResult;
            }

            visitaBd.ReprovarVisita();

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

            if (visitaBd.ObterStatus() == StatusVisita.PENDENTE)
            {
                AdicionarErro("Visita não pode ser iniciada pois ainda esta pendente de aprovação.");
                return ValidationResult;
            }
            if (visitaBd.ObterStatus() == StatusVisita.INICIADA)
            {
                AdicionarErro("Visita já esta iniciada.");
                return ValidationResult;
            }
            if (visitaBd.ObterStatus() != StatusVisita.APROVADA)
            {
                AdicionarErro("Visita não pode ser iniciada pois esta " + visitaBd.ObterStatus().ToString().ToLower());
                return ValidationResult;
            }
             
            visitaBd.IniciarVisita();

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

            if (visitaBd.ObterStatus() == StatusVisita.TERMINADA)
            {
                AdicionarErro("Visita já esta terminada.");
                return ValidationResult;
            }
            if (visitaBd.ObterStatus() != StatusVisita.INICIADA)
            {
                AdicionarErro("Visita não pode ser terminada pois não esta iniciada.");
                return ValidationResult;
            }

            visitaBd.TerminarVisita();

            _visitanteRepository.AtualizarVisita(visitaBd);

            //Evento
            visitaBd.AdicionarEvento(new VisitaTerminadaEvent(request.Id, request.DataDeSaida));

            return await PersistirDados(_visitanteRepository.UnitOfWork);
        }
       
            

    

        private Visita VisitaFactory(CadastrarVisitaCommand request)
        {
            return new Visita
                (request.DataDeEntrada, request.Observacao, request.Status,
                 request.VisitanteId, request.NomeVisitante, request.TipoDeDocumentoVisitante,
                 request.RgVisitante, request.CpfVisitante, request.EmailVisitante, request.FotoVisitante,
                 request.TipoDeVisitante, request.NomeEmpresaVisitante, request.CondominioId,
                 request.NomeCondominio, request.UnidadeId, request.NumeroUnidade, request.AndarUnidade,
                 request.GrupoUnidade, request.Veiculo, request.UsuarioId, request.NomeUsuario);
        }
        

        public void Dispose()
        {
            _visitanteRepository?.Dispose();
        }


    }
}
