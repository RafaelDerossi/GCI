﻿using CondominioApp.Core.Helpers;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegraDeReservaBase;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces;
using FluentValidation.Results;
using System;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras
{
    public class RegraHorarioDentroDosLimites : ReservaStrategyBase, IRegraHorarioDentroDosLimites
    {       
        public ValidationResult Validar(Reserva _reserva, AreaComum _areaComum)
        {
            ValidationResult.Errors.Clear();

            var HoraInicioPermitido = _areaComum.HorarioDeInicioParaReservar();
            var HoraFimPermitido = _areaComum.HorarioDeFimParaReservar();
            var HoraInicioReversa = _reserva.ObterHoraInicio;
            var HoraFimReserva = _reserva.ObterHoraFim;

            if (HoraInicioPermitido < HoraFimPermitido)
            {
                if (HoraInicioReversa < HoraInicioPermitido ||
                    HoraInicioReversa >= HoraFimPermitido ||
                    HoraFimReserva > HoraFimPermitido ||
                    HoraFimReserva <= HoraInicioPermitido)
                {
                    _reserva.Reprovar("Horário não permitido.");
                    AdicionarErros(_reserva.Justificativa);
                    return ValidationResult;
                }
            }
            else if (HoraInicioPermitido > HoraFimPermitido)
            {
                if ((HoraInicioReversa < HoraInicioPermitido && HoraInicioReversa >= HoraFimPermitido) ||
                    (HoraFimReserva > HoraFimPermitido && HoraFimReserva <= HoraInicioPermitido))
                {
                    _reserva.Reprovar("Horário não permitido.");
                    AdicionarErros(_reserva.Justificativa);
                    return ValidationResult;
                }
            }

            return ValidationResult;
        }
    }
}