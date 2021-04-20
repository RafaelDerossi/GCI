using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCancelamento;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy
{
   public interface IRegrasDeReserva
    {
        ValidationResult ValidarRegrasParaCriacao(Reserva reserva, AreaComum areaComum);

        ValidationResult VerificaReservasAprovadas(Reserva _reserva, AreaComum _areaComum);

        ValidationResult ValidarRegrasParaCancelamentoPelaAdministracao(Reserva reserva);

        ValidationResult ValidarRegrasParaCancelamentoPeloMorador(Reserva reserva, AreaComum areaComum);
    }
}
