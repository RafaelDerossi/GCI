using CondominioApp.Core.Helpers;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegraDeReservaBase;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces;
using FluentValidation.Results;
using System;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras
{
    public class RegraDataRetroativaNaoPermitida : ReservaStrategyBase, IRegraDataRetroativaNaoPermitida
    {       
        public ValidationResult Validar(Reserva _reserva)
        {
            ValidationResult.Errors.Clear();
            if (_reserva.DataDeRealizacao.Date < DataHoraDeBrasilia.Get().Date)
            {
                _reserva.Reprovar("Informe uma data de realização da reserva posterior ou igual a hoje");
                AdicionarErros(_reserva.Justificativa);
                return ValidationResult;
            }

            //Regra para Data de realizacao da Reserva
            var dataLimite = DataHoraDeBrasilia.Get().AddYears(5).Date;
            if (_reserva.DataDeRealizacao.Date > dataLimite)
            {
                _reserva.Reprovar($"Informe uma data de realização da reserva anterior a {dataLimite.ToShortDateString()}!");
                AdicionarErros(_reserva.Justificativa);
                return ValidationResult;
            }

            return ValidationResult;
        }
    }
}
