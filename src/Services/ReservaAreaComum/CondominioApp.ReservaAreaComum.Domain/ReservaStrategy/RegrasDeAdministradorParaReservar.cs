using CondominioApp.Core.Helpers;
using CondominioApp.ReservaAreaComum.Domain.ValueObject;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy
{
    public class RegrasDeAdministradorParaReservar : RegrasStrategy
    {
        private readonly Reserva _reserva;

        private readonly AreaComum _areaComum;

        public RegrasDeAdministradorParaReservar(Reserva reserva, AreaComum areaComum)
        {
            _reserva = reserva;
            _areaComum = areaComum;
        }

        public override ValidationResult Validar()
        {
            //Regra para Data de realizacao da Reserva Retroativa
            if (_reserva.DataDeRealizacao.Date < DateTime.Today.Date.AddYears(-5))
            {
                AdicionarErros("Data de realização da reserva retroativa deve ser menor que 5 anos!");
                return ValidationResult;
            }

            //Regra para Data de realizacao da Reserva
            if (_reserva.DataDeRealizacao.Date > DateTime.Today.Date.AddYears(5))
            {
                AdicionarErros("Data de realização da reserva deve ser menor que 5 anos!");
                return ValidationResult;
            }


            return ValidationResult;
        }
      
    }
}
