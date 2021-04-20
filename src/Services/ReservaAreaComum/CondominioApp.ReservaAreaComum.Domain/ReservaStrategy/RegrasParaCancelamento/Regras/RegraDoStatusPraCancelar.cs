using CondominioApp.Core.Enumeradores;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegraDeReservaBase;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCancelamento.Regras.Interfaces;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCancelamento.Regras
{
   public class RegraDoStatusPraCancelar : RegrasDeReservaBase, IRegraDoStatusPraCancelar
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
