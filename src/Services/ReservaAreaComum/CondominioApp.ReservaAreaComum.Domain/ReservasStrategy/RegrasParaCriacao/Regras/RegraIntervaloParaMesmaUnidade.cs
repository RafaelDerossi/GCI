using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegraDeReservaBase;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras
{
   public class RegraIntervaloParaMesmaUnidade : ReservaStrategyBase, IRegraIntervaloParaMesmaUnidade
    {       
        public ValidationResult Validar(Reserva _reserva, AreaComum _areaComum)
        {
            ValidationResult.Errors.Clear();
            if (_areaComum.ObterHorasDeIntervaloDeReservaPorUnidade == 0 && _areaComum.ObterMinutosDeIntervaloDeReservaPorUnidade == 0)
                return ValidationResult;

            if (_areaComum.Reservas.Any(r => r.UnidadeId == _reserva.UnidadeId &&
                                             r.DataDeRealizacao == _reserva.DataDeRealizacao &&
                                             r.HoraInicio == _reserva.HoraInicio &&
                                             r.HoraFim == _reserva.HoraFim &&
                                            !r.Lixeira &&
                                             r.Status == StatusReserva.APROVADA))
                return ValidationResult;


            var dataHJ = DataHoraDeBrasilia.Get().Date;

            List<Reserva> ultimasReserva = _areaComum.Reservas
                                            .Where(r => r.UnidadeId == _reserva.UnidadeId &&
                                                        r.DataDeRealizacao >= dataHJ &&
                                                        r.Status == StatusReserva.APROVADA)
                                            .OrderByDescending(r => r.DataDeRealizacao)
                                            .ToList();

            if (ultimasReserva.Count() == 0)
                return ValidationResult;

            DateTime dataHoraInicioDaRealizacao = _reserva.ObterDataHoraInicioDaRealizacao();
            DateTime dataHoraFimDaRealizacao = _reserva.ObterDataHoraFimDaRealizacao();
            var horasDeIntervalo = _areaComum.ObterHorasDeIntervaloDeReservaPorUnidade;
            var minutosDeIntervalo = _areaComum.ObterMinutosDeIntervaloDeReservaPorUnidade;

            foreach (var item in ultimasReserva)
            {
                DateTime dataPermitidaParaAProximaReservaAntes = item.ObterDataHoraInicioDaRealizacao()
                                                                         .AddHours(-horasDeIntervalo)
                                                                         .AddMinutes(-minutosDeIntervalo);

                DateTime dataPermitidaParaAProximaReservaDepois = item.ObterDataHoraFimDaRealizacao()
                                                                         .AddHours(horasDeIntervalo)
                                                                         .AddMinutes(minutosDeIntervalo);




                if (dataHoraFimDaRealizacao > dataPermitidaParaAProximaReservaAntes && dataHoraInicioDaRealizacao < dataPermitidaParaAProximaReservaDepois)
                {
                    _reserva.Reprovar(@$"Você não pode realizar uma nova reserva nesta área comum entre
                                      {dataPermitidaParaAProximaReservaAntes.ToLongDateString()} as 
                                      {dataPermitidaParaAProximaReservaAntes.ToLongTimeString()} e 
                                      {dataPermitidaParaAProximaReservaDepois.ToLongDateString()} as 
                                      {dataPermitidaParaAProximaReservaDepois.ToLongTimeString()}.");
                    AdicionarErros(_reserva.Justificativa);
                    return ValidationResult;
                }
            }


            return ValidationResult;
        }
    }
}
