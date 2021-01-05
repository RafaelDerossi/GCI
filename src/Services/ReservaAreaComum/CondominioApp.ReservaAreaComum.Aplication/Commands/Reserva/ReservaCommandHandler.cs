using CondominioApp.Core.Messages;
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
         IRequestHandler<AprovarReservaCommand, ValidationResult>,
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

            var reserva = ReservaFactory(request);

            var areacomum = await _reservaAreaComumRepository.ObterPorId(request.AreaComumId);
            if (areacomum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }

           var Result = areacomum.AdicionarReserva(reserva);

            if (!Result.IsValid) return Result;
            
            _reservaAreaComumRepository.AdicionarReserva(reserva);

            //Evento
            reserva.AdicionarEvento
                (new ReservaCadastradaEvent
                (reserva.Id, reserva.AreaComumId,
                areacomum.Nome, areacomum.CondominioId, areacomum.NomeCondominio, areacomum.Capacidade,
                reserva.Observacao, reserva.UnidadeId, reserva.NumeroUnidade, reserva.AndarUnidade,
                reserva.DescricaoGrupoUnidade, reserva.UsuarioId, reserva.NomeUsuario, reserva.DataDeRealizacao,
                reserva.HoraInicio, reserva.HoraFim, reserva.Ativa, reserva.Preco, reserva.EstaNaFila,
                reserva.Origem, reserva.ReservadoPelaAdministracao));

            return await PersistirDados(_reservaAreaComumRepository.UnitOfWork);
        }


        public async Task<ValidationResult> Handle(AprovarReservaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var reserva = await _reservaAreaComumRepository.ObterReservaPorId(request.Id);
            if (reserva == null)
            {
                AdicionarErro("Reserva não encontrada!");
                return ValidationResult;
            }

            reserva.Aprovar();

            //Evento
            reserva.AdicionarEvento(new ReservaAprovadaEvent(reserva.Id));

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
            reserva.AdicionarEvento(new ReservaCanceladaEvent(reserva.Id, reserva.Justificativa));


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
            reserva.AdicionarEvento(new ReservaCanceladaEvent(reserva.Id, reserva.Justificativa));

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
            reservaRetiradaDaFila.AdicionarEvento(new ReservaRetiradaDaFilaEvent(reservaRetiradaDaFila.Id));
            
            return await PersistirDados(_reservaAreaComumRepository.UnitOfWork);
        }


        private Reserva ReservaFactory(CadastrarReservaCommand request)
        {
            return new Reserva
                (request.AreaComumId, request.Observacao, request.UnidadeId, request.NumeroUnidade, request.AndarUnidade,
                 request.DescricaoGrupoUnidade, request.UsuarioId, request.NomeUsuario, request.DataDeRealizacao.Date,
                 request.HoraInicio, request.HoraFim, request.Preco, request.EstaNaFila, request.Origem,
                 request.ReservadoPelaAdministracao);
        }
        
        public void Dispose()
        {
            _reservaAreaComumRepository?.Dispose();
        }

    }
}
