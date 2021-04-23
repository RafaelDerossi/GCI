using CondominioApp.Core.Enumeradores;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegraDeReservaBase;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCancelamento.Regras.Interfaces;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCancelamento.Regras
{
   public class RegraDoStatusPraCancelar : ReservaStrategyBase, IRegraDoStatusPraCancelar
    {       
        public ValidationResult Validar(Reserva reserva)
        {
            ValidationResult.Errors.Clear();

            if (reserva.Status == StatusReserva.CANCELADA ||
                reserva.Status == StatusReserva.EXPIRADA ||
                reserva.Status == StatusReserva.REMOVIDA ||
                reserva.Status == StatusReserva.REPROVADA)
            {
                AdicionarErros("Esta reserva não pode ser cancelada!");
                return ValidationResult;
            }
            return ValidationResult;
        }
    }
}
