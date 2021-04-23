using CondominioApp.Core.Helpers;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegraDeReservaBase;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces;
using FluentValidation.Results;
using System;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras
{
    public class RegraAntecedenciaMaxima : ReservaStrategyBase, IRegraAntecedenciaMaxima
    {       
        public ValidationResult Validar(Reserva _reserva, AreaComum _areaComum)
        {
            ValidationResult.Errors.Clear();
            if (_areaComum.AntecedenciaMaximaEmMeses > 0 || _areaComum.AntecedenciaMaximaEmDias > 0)
            {
                DateTime dataRealizacaoSubtraida =
                    _reserva.DataDeRealizacao.AddDays(-_areaComum.AntecedenciaMaximaEmDias).AddMonths(-_areaComum.AntecedenciaMaximaEmMeses);
                DateTime dataHojeSomada = DataHoraDeBrasilia.Get().AddDays(_areaComum.AntecedenciaMaximaEmDias).AddMonths(_areaComum.AntecedenciaMaximaEmMeses);

                if (dataRealizacaoSubtraida.Date > DataHoraDeBrasilia.Get().Date)
                {
                    _reserva.Reprovar($"Esta reserva é permitida no máximo até dia {string.Format("{0:d }", dataHojeSomada)}!");
                    AdicionarErros(_reserva.Justificativa);
                    return ValidationResult;
                }
            }

            return ValidationResult;
        }
    }
}
