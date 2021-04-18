using CondominioApp.Core.Helpers;
using CondominioApp.ReservaAreaComum.Domain.ValueObject;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy
{
    public class RegrasDeAdministradorParaReservar : RegraDeReservaBase, IRegrasDeReservaEspecificas
    {
        private readonly Reserva _reserva;        

        public RegrasDeAdministradorParaReservar(Reserva reserva)
        {
            _reserva = reserva;
        }

        public override ValidationResult Validar()
        {
            //Regra para Data de realizacao da Reserva Retroativa
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
