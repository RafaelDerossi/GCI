using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents;
using CondominioApp.ReservaAreaComum.Aplication.Events;
using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
    public class ReservaCommandHandler : CommandHandler,
         IRequestHandler<CadastrarReservaCommand, ValidationResult>,
         IRequestHandler<AprovarReservaAutomaticamenteCommand, ValidationResult>,
         IRequestHandler<AguardarAprovacaoDaReservaPelaAdmCommand, ValidationResult>,
         IRequestHandler<ReprovarReservaCommand, ValidationResult>,
         IRequestHandler<EnviarReservaParaFilaCommand, ValidationResult>,
         IRequestHandler<AprovarReservaPelaAdministracaoCommand, ValidationResult>,
         IRequestHandler<CancelarReservaComoUsuarioCommand, ValidationResult>,
         IRequestHandler<CancelarReservaComoAdministradorCommand, ValidationResult>,
         IRequestHandler<RetirarReservaDaFilaCommand, ValidationResult>,         
         IDisposable
    {

        private IReservaAreaComumRepository _reservaAreaComumRepository;

        public ReservaCommandHandler(IReservaAreaComumRepository areaComumRepository)
        {
            _reservaAreaComumRepository = areaComumRepository;            
        }


        public async Task<ValidationResult> Handle(CadastrarReservaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;           

            var areacomum = await _reservaAreaComumRepository.ObterPorId(request.AreaComumId);
            if (areacomum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }

            var reserva = ReservaFactory(request);

            reserva.ColocarEmProcessamento();

            var Result = areacomum.AdicionarReserva(reserva);
            if (!Result.IsValid) 
                return Result;
            
            _reservaAreaComumRepository.AdicionarReserva(reserva);

            //Evento
            reserva.AdicionarEvento
                (new ReservaCadastradaEvent
                (reserva.Id, reserva.AreaComumId,
                areacomum.Nome, areacomum.CondominioId, areacomum.NomeCondominio, areacomum.Capacidade,
                reserva.Observacao, reserva.UnidadeId, reserva.NumeroUnidade, reserva.AndarUnidade,
                reserva.DescricaoGrupoUnidade, reserva.MoradorId, reserva.NomeMorador, reserva.DataDeRealizacao,
                reserva.HoraInicio, reserva.HoraFim, reserva.Preco, reserva.Status, reserva.Justificativa,
                reserva.Origem,reserva.CriadaPelaAdministracao, reserva.ReservadoPelaAdministracao));
            

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

            var areacomum = await _reservaAreaComumRepository.ObterPorId(request.AreaComumId);
            if (areacomum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }


            reserva.Aprovar(reserva.Justificativa);

            _reservaAreaComumRepository.AtualizarReserva(reserva);            

            //Evento
            reserva.AdicionarEvento(new StatusDaReservaAlteradoEvent(reserva.Id, reserva.Status, reserva.Justificativa, reserva.Observacao));

            reserva.EnviarPush(areacomum.Nome, areacomum.CondominioId);

            reserva.EnviarEmail(areacomum.Nome, areacomum.CondominioId);

            return await PersistirDados(_reservaAreaComumRepository.UnitOfWork);
        }


        public async Task<ValidationResult> Handle(ReprovarReservaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var reserva = await _reservaAreaComumRepository.ObterReservaPorId(request.Id);
            if (reserva == null)
            {
                AdicionarErro("Reserva não encontrada!");
                return ValidationResult;
            }

            var areacomum = await _reservaAreaComumRepository.ObterPorId(request.AreaComumId);
            if (areacomum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }

            reserva.Reprovar(reserva.Justificativa);


            _reservaAreaComumRepository.AtualizarReserva(reserva);


            //Evento
            reserva.AdicionarEvento(new StatusDaReservaAlteradoEvent(reserva.Id, reserva.Status, reserva.Justificativa, reserva.Observacao));

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

            var areacomum = await _reservaAreaComumRepository.ObterPorId(request.AreaComumId);
            if (areacomum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }

            reserva.AguardarAprovacao(reserva.Justificativa);


            _reservaAreaComumRepository.AtualizarReserva(reserva);


            //Evento
            reserva.AdicionarEvento(new StatusDaReservaAlteradoEvent(reserva.Id, reserva.Status, reserva.Justificativa, reserva.Observacao));

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

            var areacomum = await _reservaAreaComumRepository.ObterPorId(request.AreaComumId);
            if (areacomum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }

            reserva.EnviarParaFila(reserva.Justificativa);


            _reservaAreaComumRepository.AtualizarReserva(reserva);


            //Evento
            reserva.AdicionarEvento(new StatusDaReservaAlteradoEvent(reserva.Id, reserva.Status, reserva.Justificativa, reserva.Observacao));

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

            var areacomum = await _reservaAreaComumRepository.ObterPorId(request.AreaComumId);
            if (areacomum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }

            var retorno = areacomum.AprovarReservaPelaAdministracao(request.Id);
            if (!retorno.IsValid)
                return retorno;

            //Evento
            reserva.AdicionarEvento(new StatusDaReservaAlteradoEvent(reserva.Id, reserva.Status, reserva.Justificativa, reserva.Observacao));

            reserva.EnviarPush(areacomum.Nome, areacomum.CondominioId);

            reserva.EnviarEmail(areacomum.Nome, areacomum.CondominioId);


            return await PersistirDados(_reservaAreaComumRepository.UnitOfWork);
        }


        public async Task<ValidationResult> Handle(CancelarReservaComoUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

           
            var areaComum = await _reservaAreaComumRepository.ObterPorId(await _reservaAreaComumRepository.Obter_AreaComumId_Por_ReservaId(request.Id));
            if (areaComum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }

            var reserva = areaComum.ObterReserva(request.Id);

            var result = areaComum.CancelarReservaComoUsuario(reserva, request.Justificativa);
            if (!result.IsValid)
                return result;


            //Evento
            reserva.AdicionarEvento(new StatusDaReservaAlteradoEvent(reserva.Id, reserva.Status, reserva.Justificativa, reserva.Observacao));

            reserva.EnviarPush(areaComum.Nome, areaComum.CondominioId);

            reserva.EnviarEmail(areaComum.Nome, areaComum.CondominioId);


            return await PersistirDados(_reservaAreaComumRepository.UnitOfWork);
        }


        public async Task<ValidationResult> Handle(CancelarReservaComoAdministradorCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var areaComum = await _reservaAreaComumRepository.ObterPorId(await _reservaAreaComumRepository.Obter_AreaComumId_Por_ReservaId(request.Id));
            if (areaComum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }

            var reserva = areaComum.ObterReserva(request.Id);          

            var result = areaComum.CancelarReservaComoAdministrador(reserva, request.Justificativa);
            if (!result.IsValid)
                return result;

            //Evento
            reserva.AdicionarEvento(new StatusDaReservaAlteradoEvent(reserva.Id, reserva.Status, reserva.Justificativa, reserva.Observacao));

            reserva.EnviarPush(areaComum.Nome, areaComum.CondominioId);

            reserva.EnviarEmail(areaComum.Nome, areaComum.CondominioId);


            return await PersistirDados(_reservaAreaComumRepository.UnitOfWork);
          
        }


        public async Task<ValidationResult> Handle(RetirarReservaDaFilaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            //Obtem Area Comum
            var areaComum = await _reservaAreaComumRepository.ObterPorId(await _reservaAreaComumRepository.Obter_AreaComumId_Por_ReservaId(request.Id));
            if (areaComum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }

            //Retira proxima Reserva da Fila da fila
            var reservaCancelada = areaComum.ObterReserva(request.Id);
            var reservaRetiradaDaFila = areaComum.RetirarProximaReservaDaFila(reservaCancelada);            
            if (reservaRetiradaDaFila == null)
            {
                return ValidationResult;
            }

            //Evento
            reservaRetiradaDaFila.AdicionarEvento
                (new StatusDaReservaAlteradoEvent
                (reservaRetiradaDaFila.Id, reservaRetiradaDaFila.Status,
                 reservaRetiradaDaFila.Justificativa, reservaRetiradaDaFila.Observacao));

            reservaRetiradaDaFila.EnviarPushReservaRetiradaDaFila(areaComum.Nome, areaComum.CondominioId);


            return await PersistirDados(_reservaAreaComumRepository.UnitOfWork);
        }


        private Reserva ReservaFactory(CadastrarReservaCommand request)
        {
            return new Reserva
                (request.AreaComumId, request.Observacao, request.UnidadeId, request.NumeroUnidade, request.AndarUnidade,
                 request.GrupoUnidade, request.MoradorId, request.NomeMorador, request.DataDeRealizacao.Date,
                 request.HoraInicio, request.HoraFim, request.Preco, request.Origem, request.CriadaPelaAdministracao,
                 request.ReservadoPelaAdministracao);
        }
        

        public void Dispose()
        {
            _reservaAreaComumRepository?.Dispose();
        }

    }
}
