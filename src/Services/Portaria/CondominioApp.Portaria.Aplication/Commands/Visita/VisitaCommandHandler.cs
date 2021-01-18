using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Portaria.Aplication.Events;
using CondominioApp.Portaria.Aplication.Factories;
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
        private IVisitanteFactory _visitanteFactory;

        public VisitaCommandHandler(IVisitanteRepository visitanteRepository, IVisitanteFactory visitanteFactory)
        {
            _visitanteRepository = visitanteRepository;
            _visitanteFactory = visitanteFactory;
        }


        public async Task<ValidationResult> Handle(CadastrarVisitaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            if (request.VisitanteId==Guid.Empty)
               return await CadastrarVisitaComVisitanteNovo(request);

            return await CadastrarVisitaComVisitanteExistente(request);
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
            
            var visitanteBd = await _visitanteRepository.ObterPorId(visitaBd.VisitanteId);
            if (visitanteBd == null)
            {
                AdicionarErro("Visitante não encontrado.");
                return ValidationResult;
            }

            if (!visitanteBd.VisitantePermanente)
            {
                visitanteBd.SetNome(request.NomeVisitante);
                visitanteBd.SetTipoDeDocumento(request.TipoDeDocumentoVisitante);
                visitanteBd.SetCpf(request.CpfVisitante);
                visitanteBd.SetRg(request.RgVisitante);
                visitanteBd.SetEmail(request.EmailVisitante);
                visitanteBd.SetTipoDeVisitante(request.TipoDeVisitante);
                visitanteBd.SetNomeEmpresa(request.NomeEmpresaVisitante);
            }
            visitanteBd.SetFoto(request.FotoVisitante);
            visitanteBd.SetVeiculo(request.Veiculo);

            visitanteBd.AdicionarVisita(visitaBd);           

            _visitanteRepository.Atualizar(visitanteBd);

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

            if (visitaBd.ObterStatus() != StatusVisita.PENDENTE)
            {
                AdicionarErro("Visita não pode ser aprovada pois ja esta " + visitaBd.ObterStatus().ToString().ToLower());
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

            if (visitaBd.ObterStatus() != StatusVisita.PENDENTE && visitaBd.ObterStatus() != StatusVisita.APROVADA)
            {
                AdicionarErro("Visita não pode ser reprovada pois ja esta " + visitaBd.ObterStatus().ToString().ToLower());
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

            if (visitaBd.ObterStatus() != StatusVisita.APROVADA)
            {
                AdicionarErro("Visita não pode ser iniciada pois ja esta " + visitaBd.ObterStatus().ToString().ToLower());
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



       

       
        private async Task<ValidationResult> CadastrarVisitaComVisitanteNovo(CadastrarVisitaCommand request)
        {
            var visita = VisitaFactory(request);

            if (request.CpfVisitante.Numero != "")
            {
                if (_visitanteRepository.VisitanteJaCadastradoPorCpf(request.CpfVisitante, request.VisitanteId).Result)
                {
                    AdicionarErro("CPF informado ja consta no sistema.");
                    return ValidationResult;
                }
            }

            if (request.RgVisitante.Numero != "")
            {
                if (_visitanteRepository.VisitanteJaCadastradoPorRg(request.RgVisitante, request.VisitanteId).Result)
                {
                    AdicionarErro("RG informado ja consta no sistema.");
                    return ValidationResult;
                }
            }

            var visitante = _visitanteFactory.Fabricar(request);           


            visitante.AdicionarVisita(visita);

            _visitanteRepository.Adicionar(visitante);

            //Evento
            AdicionarEventoDeVisitaCadastrada(visita);
           
            return await PersistirDados(_visitanteRepository.UnitOfWork);
        }

        private async Task<ValidationResult> CadastrarVisitaComVisitanteExistente(CadastrarVisitaCommand request)
        {
           var visita = VisitaFactory(request);

           var visitante = _visitanteRepository.ObterPorId(request.VisitanteId).Result;
            if (visitante == null)
            {
                AdicionarErro("Visitante não encontrado.");
                return ValidationResult;
            }

            if (!visitante.VisitantePermanente)
            {
                visitante.SetNome(request.NomeVisitante);
                visitante.SetTipoDeDocumento(request.TipoDeDocumentoVisitante);
                visitante.SetCpf(request.CpfVisitante);
                visitante.SetRg(request.RgVisitante);
                visitante.SetEmail(request.EmailVisitante);
                visitante.SetTipoDeVisitante(request.TipoDeVisitante);
                visitante.SetNomeEmpresa(request.NomeEmpresaVisitante);
            }
            visitante.SetFoto(request.FotoVisitante);
            visitante.SetVeiculo(request.Veiculo);


            visitante.AdicionarVisita(visita);

            _visitanteRepository.AdicionarVisita(visita);
            _visitanteRepository.Atualizar(visitante);

            //Evento
            AdicionarEventoDeVisitaCadastrada(visita);

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

        private void AdicionarEventoDeVisitaCadastrada(Visita visita)
        {
            visita.AdicionarEvento(
               new VisitaCadastradaEvent(
                   visita.Id, visita.DataDeEntrada, visita.Observacao, visita.Status, visita.VisitanteId,
                   visita.NomeVisitante, visita.TipoDeDocumentoVisitante, visita.CpfVisitante,
                   visita.RgVisitante, visita.EmailVisitante, visita.FotoVisitante, visita.TipoDeVisitante,
                   visita.NomeEmpresaVisitante, visita.CondominioId, visita.NomeCondominio, visita.UnidadeId,
                   visita.NumeroUnidade, visita.AndarUnidade, visita.GrupoUnidade, visita.TemVeiculo,
                   visita.Veiculo, visita.UsuarioId, visita.NomeUsuario));
        }

        public void Dispose()
        {
            _visitanteRepository?.Dispose();
        }


    }
}
