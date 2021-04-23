using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegraDeReservaBase;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaHorariosConflitantes;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras
{
    public class RegraHorarioDisponivelSemSobreposicao : ReservaStrategyBase, IRegraHorarioDisponivelSemSobreposicao
    {       
        public ValidationResult Validar(Reserva _reserva, AreaComum _areaComum)
        {
            ValidationResult.Errors.Clear();

            List<Reserva> ReservasAprovadas = _areaComum.Reservas
                   .Where(x => x.Status == StatusReserva.APROVADA &&
                               x.DataDeRealizacao == _reserva.DataDeRealizacao &&
                               !x.Lixeira)
                   .ToList();

            return OverLap(ReservasAprovadas, _reserva);
        }
        
        private ValidationResult OverLap(List<Reserva> reservasAprovadas, Reserva reservaNova)
        {
            foreach (var reserva in reservasAprovadas)
            {
                bool overlap = VerificadorDeHorariosConflitantes.Verificar(reserva, reservaNova);

                if (overlap && reserva.ReservadoPelaAdministracao)
                {
                    reservaNova.Reprovar("Este período foi reservado pela administração de seu condomínio!");
                    AdicionarErros(reservaNova.Justificativa);
                    return ValidationResult;
                }
                else if (overlap)
                {
                    reservaNova.EnviarParaFila("O horário que você deseja esta comprometido, sua solicitação de reserva foi encaminhada para a fila de espera.");
                    AdicionarErros(reservaNova.Justificativa);
                    return ValidationResult;
                }
            }
            return ValidationResult;
        }
    }
}
