using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegraDeReservaBase;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.Regras
{
   public class RegraDataRetroativaPermitida : RegrasDeReservaBase, IRegraDataRetroativaPermitida
    {       
        public ValidationResult Validar(Reserva _reserva)
        {
            ValidationResult.Errors.Clear();
            if (_reserva.DataDeRealizacao.Date < DateTime.Today.Date.AddYears(-5))
            {
                _reserva.Reprovar("Data de realização da reserva retroativa deve ser menor que 5 anos!");
                AdicionarErros(_reserva.Justificativa);
                return ValidationResult;
            }

            //Regra para Data de realizacao da Reserva
            if (_reserva.DataDeRealizacao.Date > DateTime.Today.Date.AddYears(5))
            {
                _reserva.Reprovar("Data de realização da reserva deve ser menor que 5 anos!");
                AdicionarErros(_reserva.Justificativa);
                return ValidationResult;
            }

            return ValidationResult;
        }
    }
}
