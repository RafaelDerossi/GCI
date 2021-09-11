using CondominioApp.Core.Helpers;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegraDeReservaBase;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces;
using FluentValidation.Results;
using System;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras
{
    public class RegraAntecedenciaMinima : ReservaStrategyBase, IRegraAntecedenciaMinima
    {       
        public ValidationResult Validar(Reserva _reserva, AreaComum _areaComum)
        {
            ValidationResult.Errors.Clear();
            if (_areaComum.AntecedenciaMinimaEmDias > 0)
            {
                DateTime dataRealizacaoSubtraida = _reserva.DataDeRealizacao.AddDays(-_areaComum.AntecedenciaMinimaEmDias);

                if (dataRealizacaoSubtraida.Date < DataHoraDeBrasilia.Get().Date)
                {
                    _reserva.Reprovar($"Esta reserva apenas é permitida com {_areaComum.AntecedenciaMinimaEmDias} dia(s) de antecedência!");
                    AdicionarErros(_reserva.Justificativa);
                    return ValidationResult;
                }
            }

            return ValidationResult;
        }
    }
}
