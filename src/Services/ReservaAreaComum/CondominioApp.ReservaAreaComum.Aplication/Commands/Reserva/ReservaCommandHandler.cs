using CondominioApp.Core.Messages;
using CondominioApp.ReservaAreaComum.Aplication.Events;
using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Domain.Interfaces;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy;
using FluentValidation.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
    public class ReservaCommandHandler : CommandHandler,
         IRequestHandler<SolicitarReservaComoMoradorCommand, ValidationResult>,
         IRequestHandler<SolicitarReservaComoAdministradorCommand, ValidationResult>,
         IRequestHandler<AprovarReservaAutomaticamenteCommand, ValidationResult>,
         IRequestHandler<AguardarAprovacaoDaReservaPelaAdmCommand, ValidationResult>,
         IRequestHandler<ReprovarReservaAutomaticamenteCommand, ValidationResult>,
         IRequestHandler<ReprovarReservaPelaAdmCommand, ValidationResult>,
         IRequestHandler<EnviarReservaParaFilaCommand, ValidationResult>,
         IRequestHandler<AprovarReservaPelaAdministracaoCommand, ValidationResult>,
         IRequestHandler<CancelarReservaComoUsuarioCommand, ValidationResult>,
         IRequestHandler<CancelarReservaComoAdministradorCommand, ValidationResult>,
         IRequestHandler<MarcarReservaComoExpiradaCommand, ValidationResult>,
         IRequestHandler<RetirarReservaDaFilaCommand, ValidationResult>,         
         IDisposable
    {

        private readonly IReservaAreaComumRepository _reservaAreaComumRepository;
        private readonly IReservaStrategy _regrasDeReserva;

        public ReservaCommandHandler
            (IReservaAreaComumRepository areaComumRepository, IReservaStrategy regrasDeReserva)
        {
            _reservaAreaComumRepository = areaComumRepository;       
            _regrasDeReserva = regrasDeReserva;
        }


        public async Task<ValidationResult> Handle(SolicitarReservaComoMoradorCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;           

            var areacomum = await _reservaAreaComumRepository.ObterPorId(request.AreaComumId);
            if (areacomum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }

            var reserva = ReservaFactory(request, false);

            reserva.ColocarEmProcessamento();
            
            areacomum.AdicionarReserva(reserva);
           
            _reservaAreaComumRepository.AdicionarReserva(reserva);

            //Evento
            reserva.AdicionarEvento
                (new ReservaSolicitadaComoUsuarioEvent
                (reserva.Id, reserva.AreaComumId,
                areacomum.Nome, areacomum.CondominioId, areacomum.NomeCondominio, areacomum.Capacidade,
                reserva.Observacao, reserva.UnidadeId, reserva.NumeroUnidade, reserva.AndarUnidade,
                reserva.DescricaoGrupoUnidade, reserva.MoradorId, reserva.NomeMorador, reserva.DataDeRealizacao,
                reserva.HoraInicio, reserva.HoraFim, reserva.Preco, reserva.Justificativa,
                reserva.Origem, reserva.ReservadoPelaAdministracao));
            

            return await PersistirDados(_reservaAreaComumRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(SolicitarReservaComoAdministradorCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var areacomum = await _reservaAreaComumRepository.ObterPorId(request.AreaComumId);
            if (areacomum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }

            var reserva = ReservaFactory(request, true);

            reserva.ColocarEmProcessamento();

            areacomum.AdicionarReserva(reserva);

            _reservaAreaComumRepository.AdicionarReserva(reserva);

            //Evento
            reserva.AdicionarEvento
                (new ReservaSolicitadaComoAdministradorEvent
                (reserva.Id, reserva.AreaComumId,
                areacomum.Nome, areacomum.CondominioId, areacomum.NomeCondominio, areacomum.Capacidade,
                reserva.Observacao, reserva.UnidadeId, reserva.NumeroUnidade, reserva.AndarUnidade,
                reserva.DescricaoGrupoUnidade, reserva.MoradorId, reserva.NomeMorador, reserva.DataDeRealizacao,
                reserva.HoraInicio, reserva.HoraFim, reserva.Preco, reserva.Justificativa,
                reserva.Origem, reserva.ReservadoPelaAdministracao,
                request.FuncionarioId, request.NomeFuncionario));


            return await PersistirDados(_reservaAreaComumRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AprovarReservaAutomaticamenteCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var reserva = await _reservaAreaComumRepository.ObterReservaPorId(request.Id);
            if (reserva == null)
            {
                AdicionarErro("Reserva não encontrada!");
                return ValidationResult;
            }

            var areacomum = await _reservaAreaComumRepository.ObterPorId(reserva.AreaComumId);
            if (areacomum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }


            reserva.Aprovar(request.Justificativa);

            _reservaAreaComumRepository.AtualizarReserva(reserva);          

            //Evento
            reserva.AdicionarEvento(
                new ReservaAprovadaAutomaticamenteEvent
                (reserva.Id, reserva.Justificativa, reserva.Observacao));

            reserva.EnviarPush(areacomum.Nome, areacomum.CondominioId);

            reserva.EnviarEmail(areacomum.Nome, areacomum.CondominioId);

            return await PersistirDados(_reservaAreaComumRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AprovarReservaPelaAdministracaoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var reserva = await _reservaAreaComumRepository.ObterReservaPorId(request.Id);
            if (reserva == null)
            {
                AdicionarErro("Reserva não encontrada!");
                return ValidationResult;
            }

            var areacomum = await _reservaAreaComumRepository.ObterPorId(reserva.AreaComumId);
            if (areacomum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }

            var retorno = areacomum.AprovarReservaPelaAdministracao(reserva.Id, _regrasDeReserva);
            if (!retorno.IsValid)
                return retorno;

            //Evento
            reserva.AdicionarEvento(
                new ReservaAprovadaPelaAdministracaoEvent
                (reserva.Id, reserva.Justificativa, reserva.Observacao, request.FuncionarioId,
                 request.NomeFuncionario, request.Origem));

            reserva.EnviarPush(areacomum.Nome, areacomum.CondominioId);

            reserva.EnviarEmail(areacomum.Nome, areacomum.CondominioId);


            return await PersistirDados(_reservaAreaComumRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ReprovarReservaAutomaticamenteCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var reserva = await _reservaAreaComumRepository.ObterReservaPorId(request.Id);
            if (reserva == null)
            {
                AdicionarErro("Reserva não encontrada!");
                return ValidationResult;
            }

            var areacomum = await _reservaAreaComumRepository.ObterPorId(reserva.AreaComumId);
            if (areacomum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }

            reserva.Reprovar(request.Justificativa);


            _reservaAreaComumRepository.AtualizarReserva(reserva);


            //Evento
            reserva.AdicionarEvento(
                new ReservaReprovadaAutomaticamenteEvent
                (reserva.Id, reserva.Justificativa, reserva.Observacao));

            reserva.EnviarPush(areacomum.Nome, areacomum.CondominioId);

            reserva.EnviarEmail(areacomum.Nome, areacomum.CondominioId);

            return await PersistirDados(_reservaAreaComumRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ReprovarReservaPelaAdmCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var reserva = await _reservaAreaComumRepository.ObterReservaPorId(request.Id);
            if (reserva == null)
            {
                AdicionarErro("Reserva não encontrada!");
                return ValidationResult;
            }

            var areacomum = await _reservaAreaComumRepository.ObterPorId(reserva.AreaComumId);
            if (areacomum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }

            reserva.Reprovar(request.Justificativa);


            _reservaAreaComumRepository.AtualizarReserva(reserva);


            //Evento
            reserva.AdicionarEvento(
                new ReservaReprovadaPelaAdmEvent
                (reserva.Id, reserva.Justificativa, reserva.Observacao, request.FuncionarioId,
                 request.NomeFuncionario, request.Origem));


            reserva.EnviarPush(areacomum.Nome, areacomum.CondominioId);

            reserva.EnviarEmail(areacomum.Nome, areacomum.CondominioId);

            return await PersistirDados(_reservaAreaComumRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AguardarAprovacaoDaReservaPelaAdmCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var reserva = await _reservaAreaComumRepository.ObterReservaPorId(request.Id);
            if (reserva == null)
            {
                AdicionarErro("Reserva não encontrada!");
                return ValidationResult;
            }

            var areacomum = await _reservaAreaComumRepository.ObterPorId(reserva.AreaComumId);
            if (areacomum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }

            
            reserva.AguardarAprovacao(request.Justificativa);


            _reservaAreaComumRepository.AtualizarReserva(reserva);


            //Evento
            reserva.AdicionarEvento(
                new ReservaEnviadaParaAguardarAprovacaoEvent
                (reserva.Id, reserva.Justificativa, reserva.Observacao));

            reserva.EnviarPush(areacomum.Nome, areacomum.CondominioId);

            reserva.EnviarEmail(areacomum.Nome, areacomum.CondominioId);


            return await PersistirDados(_reservaAreaComumRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(EnviarReservaParaFilaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var reserva = await _reservaAreaComumRepository.ObterReservaPorId(request.Id);
            if (reserva == null)
            {
                AdicionarErro("Reserva não encontrada!");
                return ValidationResult;
            }

            var areacomum = await _reservaAreaComumRepository.ObterPorId(reserva.AreaComumId);
            if (areacomum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }

            reserva.EnviarParaFila(request.Justificativa);


            _reservaAreaComumRepository.AtualizarReserva(reserva);


            //Evento
            reserva.AdicionarEvento(
                new ReservaEnviadaParaFilaEvent
                (reserva.Id, reserva.Justificativa, reserva.Observacao));

            reserva.EnviarPush(areacomum.Nome, areacomum.CondominioId);

            reserva.EnviarEmail(areacomum.Nome, areacomum.CondominioId);

            return await PersistirDados(_reservaAreaComumRepository.UnitOfWork);
        }
        
        public async Task<ValidationResult> Handle(CancelarReservaComoUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var reserva = await _reservaAreaComumRepository.ObterReservaPorId(request.Id);

            var areaComum = await _reservaAreaComumRepository.ObterPorId(reserva.AreaComumId);
            if (areaComum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }            

            var result = areaComum.CancelarReservaComoUsuario(reserva, request.Justificativa, _regrasDeReserva);
            if (!result.IsValid)
                return result;


            //Evento
            reserva.AdicionarEvento(
                new ReservaCanceladaPeloUsuarioEvent
                (reserva.Id, reserva.Justificativa, reserva.Observacao, request.MoradorId, request.NomeMorador, request.Origem));

            reserva.EnviarPush(areaComum.Nome, areaComum.CondominioId);

            reserva.EnviarEmail(areaComum.Nome, areaComum.CondominioId);


            return await PersistirDados(_reservaAreaComumRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(CancelarReservaComoAdministradorCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var reserva = await _reservaAreaComumRepository.ObterReservaPorId(request.Id);

            var areaComum = await _reservaAreaComumRepository.ObterPorId(reserva.AreaComumId);
            if (areaComum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }            

            var result = areaComum.CancelarReservaComoAdministrador(reserva, request.Justificativa, _regrasDeReserva);
            if (!result.IsValid)
                return result;

            //Evento
            reserva.AdicionarEvento(
                new ReservaCanceladaPelaAdmEvent
                (reserva.Id, reserva.Justificativa, reserva.Observacao,
                 request.FuncionarioId, request.NomeFuncionario, request.Origem));

            reserva.EnviarPush(areaComum.Nome, areaComum.CondominioId);

            reserva.EnviarEmail(areaComum.Nome, areaComum.CondominioId);


            return await PersistirDados(_reservaAreaComumRepository.UnitOfWork);
          
        }

        public async Task<ValidationResult> Handle(MarcarReservaComoExpiradaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var reserva = await _reservaAreaComumRepository.ObterReservaPorId(request.Id);
            if (reserva == null)
            {
                AdicionarErro("Reserva não encontrada!");
                return ValidationResult;
            }

            var areacomum = await _reservaAreaComumRepository.ObterPorId(reserva.AreaComumId);
            if (areacomum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }


            reserva.MarcarComoExpirada(request.Justificativa);

            _reservaAreaComumRepository.AtualizarReserva(reserva);

            //Evento
            reserva.AdicionarEvento(new ReservaMarcadaComoExpiradaEvent(reserva.Id, reserva.Justificativa, reserva.Observacao));


            return await PersistirDados(_reservaAreaComumRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RetirarReservaDaFilaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var reservaCancelada = await _reservaAreaComumRepository.ObterReservaPorId(request.Id);
           
            var areaComum = await _reservaAreaComumRepository.ObterPorId(reservaCancelada.AreaComumId);
            if (areaComum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }
            
            var reservaRetiradaDaFila = areaComum.RetirarProximaReservaDaFila(reservaCancelada, _regrasDeReserva);            
            if (reservaRetiradaDaFila == null)
            {
                return ValidationResult;
            }

            //Evento
            reservaRetiradaDaFila.AdicionarEvento
                (new ReservaRetiradaDaFilaEvent
                (reservaRetiradaDaFila.Id, reservaRetiradaDaFila.Status,
                 reservaRetiradaDaFila.Justificativa, reservaRetiradaDaFila.Observacao));

            reservaRetiradaDaFila.EnviarPushReservaRetiradaDaFila(areaComum.Nome, areaComum.CondominioId);

            reservaRetiradaDaFila.EnviarEmailReservaRetiradaDaFila(areaComum.Nome, areaComum.CondominioId);

            return await PersistirDados(_reservaAreaComumRepository.UnitOfWork);
        }


        


        private Reserva ReservaFactory(ReservaCommand request, bool criadaPelaAdministracao)
        {
            return new Reserva
                (request.AreaComumId, request.Observacao, request.UnidadeId, request.NumeroUnidade, request.AndarUnidade,
                 request.GrupoUnidade, request.MoradorId, request.NomeMorador, request.DataDeRealizacao.Date,
                 request.HoraInicio, request.HoraFim, request.Preco, request.Origem, criadaPelaAdministracao, request.ReservadoPelaAdministracao);
        }

       

        public void Dispose()
        {
            _reservaAreaComumRepository?.Dispose();
        }

    }
}
