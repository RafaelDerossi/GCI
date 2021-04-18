using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.ReservaAreaComum.Domain.ValueObject;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy
{
    public class RegrasDeClienteParaReservar : RegraDeReservaBase, IRegrasDeReservaEspecificas
    {
        private readonly Reserva _reserva;

        private readonly AreaComum _areaComum;

        public RegrasDeClienteParaReservar(Reserva reserva, AreaComum areaComum)
        {
            _reserva = reserva;
            _areaComum = areaComum;
        }

        public override ValidationResult Validar()
        {
            //Regra de Intervalo Entre Reservas para a mesma unidade
            var retorno = ValidaIntervaloEntreReservasDaUnidade();
            if (!retorno.IsValid)
                return retorno;

            //Regra para não permitir Reserva Retroativa
            if (_reserva.DataDeRealizacao.Date < DateTime.Today.Date)
            {
                _reserva.Reprovar("A data de realização da reserva deve ser maior ou igual a de hoje");                
                AdicionarErros(_reserva.Justificativa);
                return ValidationResult;
            }

            //Regra de bloqueio
            if (!string.IsNullOrEmpty(_areaComum.DataInicioBloqueio.ToString()))
            {
                BloqueioDeArea bloqueioDeAreaComum = new BloqueioDeArea(_areaComum.DataInicioBloqueio.Value, _areaComum.DataFimBloqueio.Value);
                if (bloqueioDeAreaComum.EstaBloqueada(_reserva.DataDeRealizacao))
                {
                    _reserva.Reprovar(bloqueioDeAreaComum.ToString());                    
                    AdicionarErros(_reserva.Justificativa);
                    return ValidationResult;
                }
            }

            //Regra para antecedencia máxima
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

            //Regra para antecedencia Minima
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

            //Regra de Dias Possíveis de reservas
            string[] arrayDias = _areaComum.DiasPermitidos.ToUpper().Split('|');
            if (!arrayDias.Any(x => x.Equals(_reserva.DataDeRealizacao.DayOfWeek.ToString().ToUpper())))
            {
                _reserva.Reprovar("Não é possível efetuar uma reserva desta área para o dia da semana selecionado.");                
                AdicionarErros(_reserva.Justificativa);
                return ValidationResult;
            }

            //Regra limite de reservas por Unidade
            if (_areaComum.NumeroLimiteDeReservaPorUnidade > 0)
            {
                if (_areaComum.Reservas
                    .Where(x => x.UnidadeId == _reserva.UnidadeId &&
                           x.DataDeRealizacao == _reserva.DataDeRealizacao &&
                           x.Status == StatusReserva.APROVADA && 
                           !x.Lixeira)
                    .Count() >= _areaComum.NumeroLimiteDeReservaPorUnidade)
                {
                    _reserva.Reprovar("Limite de reservas diárias desta unidade alcançado!");                    
                    AdicionarErros(_reserva.Justificativa);
                    return ValidationResult;
                }
            }           

            //Regra verifica se o horário da reserva esta dentro dos limites permitidos
            if (!_areaComum.TemHorariosEspecificos)
                return ValidaLimitesDeHorario();

            return ValidationResult;
        }

        /// <summary>
        /// Verifica limites de horários da Reserva
        /// </summary>
        /// <returns></returns>
        private ValidationResult ValidaLimitesDeHorario()
        {
            var HoraInicioPermitido = _areaComum.HorarioDeInicioParaReservar();
            var HoraFimPermitido = _areaComum.HorarioDeFimParaReservar();
            var HoraInicioReversa = _reserva.ObterHoraInicio;
            var HoraFimReserva = _reserva.ObterHoraFim;

            if (HoraInicioPermitido < HoraFimPermitido)
            {
                if (HoraInicioReversa < HoraInicioPermitido ||
                    HoraInicioReversa >= HoraFimPermitido ||
                    HoraFimReserva > HoraFimPermitido ||
                    HoraFimReserva <= HoraInicioPermitido)
                {
                    _reserva.Reprovar("Horário não permitido.");                    
                    AdicionarErros(_reserva.Justificativa);
                    return ValidationResult;
                }
            }
            else if (HoraInicioPermitido > HoraFimPermitido)
            {
                if ((HoraInicioReversa < HoraInicioPermitido && HoraInicioReversa >= HoraFimPermitido) ||
                    (HoraFimReserva > HoraFimPermitido && HoraFimReserva <= HoraInicioPermitido))
                {
                    _reserva.Reprovar("Horário não permitido.");                    
                    AdicionarErros(_reserva.Justificativa);
                    return ValidationResult;
                }
            }           

            return ValidationResult;
        }

        /// <summary>
        /// Verifica Intervalo entre reservas da unidade
        /// </summary>
        /// <returns></returns>
        private ValidationResult ValidaIntervaloEntreReservasDaUnidade()
        {
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

            foreach (var reserva in ultimasReserva)
            {
                DateTime dataPermitidaParaAProximaReservaAntes = reserva.ObterDataHoraInicioDaRealizacao()
                                                                         .AddHours(-horasDeIntervalo)
                                                                         .AddMinutes(-minutosDeIntervalo);

                DateTime dataPermitidaParaAProximaReservaDepois = reserva.ObterDataHoraFimDaRealizacao()
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
