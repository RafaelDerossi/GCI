using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegraDeReservaBase;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.Regras
{
    public class RegraIntervalosFixos : RegrasDeReservaBase, IRegraIntervalosFixos
    {       
        public ValidationResult Validar(Reserva _reserva, AreaComum _areaComum)
        {
            ValidationResult.Errors.Clear();
            if (!_areaComum.TemIntervaloFixoEntreReservas) return ValidationResult;

            if (_areaComum.ObterTempoDeIntervaloEntreReservas == 0) return ValidationResult;

            if (_areaComum.TemHorariosEspecificos) return ValidationResult;

            if (_areaComum.Reservas.Any(x => x.Status == StatusReserva.APROVADA && !x.Lixeira && x.DataDeRealizacao == _reserva.DataDeRealizacao))
            {
                var reservasDoDia = _areaComum.Reservas.Where(x => x.Status == StatusReserva.APROVADA && !x.Lixeira && x.DataDeRealizacao == _reserva.DataDeRealizacao).ToList();
                foreach (Reserva reserva in reservasDoDia)
                {
                    if (reserva.ObterHoraInicio < _reserva.ObterHoraInicio)
                    {
                        if ((reserva.ObterHoraFim + _areaComum.ObterTempoDeIntervaloEntreReservas) > _reserva.ObterHoraInicio)
                        {
                            AdicionarErros("Esta área esta configurada para reservas com intervalos, não foi possível criar sua reserva, tente um outro horário");
                            return ValidationResult;
                        }
                    }
                    else if (reserva.ObterHoraInicio >= _reserva.ObterHoraFim)
                    {
                        if ((_reserva.ObterHoraFim + _areaComum.ObterTempoDeIntervaloEntreReservas) > reserva.ObterHoraInicio)
                        {
                            AdicionarErros("Esta área esta configurada para reservas com intervalos, não foi possível criar sua reserva, tente um outro horário");
                            return ValidationResult;
                        }
                    }
                }
            }

            return ValidationResult;
        }
    }
}
