using CondominioApp.Core.Helpers;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegraDeReservaBase;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces;
using FluentValidation.Results;
using System;
using System.Linq;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras
{
    public class RegraDuracaoLimite : ReservaStrategyBase, IRegraDuracaoLimite
    {       
        public ValidationResult Validar(Reserva _reserva, AreaComum _areaComum)
        {
            ValidationResult.Errors.Clear();

            if (_areaComum.ObterTempoDeDuracaoDeReserva == 0) return ValidationResult;

            var horaIni = _reserva.HoraInicio.Split(':')[0];
            var minIni = _reserva.HoraInicio.Split(':')[1];
            var horaFim = _reserva.HoraFim.Split(':')[0];
            var minFim = _reserva.HoraFim.Split(':')[1];
            var minutosIni = Convert.ToInt32((60 * Convert.ToInt32(horaIni)) + Convert.ToInt32(minIni));
            var minutosFim = Convert.ToInt32((60 * Convert.ToInt32(horaFim)) + Convert.ToInt32(minFim));

            if ((minutosFim - minutosIni) > _areaComum.ObterTempoDeDuracaoDeReserva)
            {
                AdicionarErros("Período da reserva deve ser no máximo de " + _areaComum.TempoDeDuracaoDeReserva + " hora(s)");
                return ValidationResult;
            }

            return ValidationResult;
        }
    }
}
