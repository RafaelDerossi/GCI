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
   public class RegraDiasPermitidos : RegrasDeReservaBase, IRegraDiasPermitidos
    {       
        public ValidationResult Validar(Reserva _reserva, AreaComum _areaComum)
        {
            ValidationResult.Errors.Clear();
            string[] arrayDias = _areaComum.DiasPermitidos.ToUpper().Split('|');
            if (!arrayDias.Any(x => x.Equals(_reserva.DataDeRealizacao.DayOfWeek.ToString().ToUpper())))
            {
                _reserva.Reprovar("Não é possível efetuar uma reserva desta área para o dia da semana selecionado.");
                AdicionarErros(_reserva.Justificativa);
                return ValidationResult;
            }


            return ValidationResult;
        }
    }
}
