﻿using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces
{
    public interface IRegraIntervaloParaMesmaUnidade
    {
        ValidationResult Validar(Reserva reserva, AreaComum areaComum);
    }
}