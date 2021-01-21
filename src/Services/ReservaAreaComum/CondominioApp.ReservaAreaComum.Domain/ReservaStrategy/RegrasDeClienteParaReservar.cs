using CondominioApp.Core.Helpers;
using CondominioApp.ReservaAreaComum.Domain.ValueObject;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy
{
    public class RegrasDeClienteParaReservar : RegrasStrategy
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
            //Regra de Intervalo Entre Reservas para o mesmo usuario
            var retorno = ValidaIntervaloEntreReservasDoUsuario();
            if (!retorno.IsValid)
                return retorno;

            //Regra para não permitir Reserva Retroativa
            if (_reserva.DataDeRealizacao.Date < DateTime.Today.Date)
            {
                AdicionarErros("A data de realização da reserva deve ser maior ou igual a de hoje");
                return ValidationResult;
            }

            //Regra de bloqueio
            if (!string.IsNullOrEmpty(_areaComum.DataInicioBloqueio.ToString()))
            {
                BloqueioDeArea bloqueioDeAreaComum = new BloqueioDeArea(_areaComum.DataInicioBloqueio.Value, _areaComum.DataFimBloqueio.Value);
                if (bloqueioDeAreaComum.EstaBloqueada(_reserva.DataDeRealizacao))
                {
                    AdicionarErros(bloqueioDeAreaComum.ToString());
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
                    AdicionarErros($"Esta reserva é permitida no máximo até dia {string.Format("{0:d }", dataHojeSomada)}!");
                    return ValidationResult;
                }                   
            }

            //Regra para antecedencia Minima
            if (_areaComum.AntecedenciaMinimaEmDias > 0)
            {
                DateTime dataRealizacaoSubtraida = _reserva.DataDeRealizacao.AddDays(-_areaComum.AntecedenciaMinimaEmDias);

                if (dataRealizacaoSubtraida.Date < DataHoraDeBrasilia.Get().Date)
                {
                    AdicionarErros($"Esta reserva apenas é permitida com {_areaComum.AntecedenciaMinimaEmDias} dia(s) de antecedência!");
                    return ValidationResult;
                }
            }

            //Regra de Dias Possíveis de reservas
            string[] arrayDias = _areaComum.DiasPermitidos.ToUpper().Split('|');
            if (!arrayDias.Any(x => x.Equals(_reserva.DataDeRealizacao.DayOfWeek.ToString().ToUpper())))
            {
                AdicionarErros("Não é possível efetuar uma reserva desta área para o dia da semana selecionado.");
                return ValidationResult;
            }

            //Regra limite de reservas por Unidade
            if (_areaComum.NumeroLimiteDeReservaPorUnidade > 0)
            {
                if (_areaComum.Reservas
                    .Where(x => x.UnidadeId == _reserva.UnidadeId &&
                           x.DataDeRealizacao == _reserva.DataDeRealizacao &&
                           !x.Cancelada && 
                           !x.Lixeira)
                    .Count() >= _areaComum.NumeroLimiteDeReservaPorUnidade)
                {
                    AdicionarErros("Limite de reservas diárias desta unidade alcançado!");
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
                    AdicionarErros("Horário não permitido.");
                    return ValidationResult;
                }
            }
            else if (HoraInicioPermitido > HoraFimPermitido)
            {
                if ((HoraInicioReversa < HoraInicioPermitido && HoraInicioReversa >= HoraFimPermitido) ||
                    (HoraFimReserva > HoraFimPermitido && HoraFimReserva <= HoraInicioPermitido))
                {
                    AdicionarErros("Horário não permitido.");
                    return ValidationResult;
                }
            }           

            return ValidationResult;
        }

        /// <summary>
        /// Verifica Intervalo entre reservas do usuario
        /// </summary>
        /// <returns></returns>
        private ValidationResult ValidaIntervaloEntreReservasDoUsuario()
        {
            Reserva ultimaReserva = _areaComum.Reservas
                .Where(r => r.UsuarioId == _reserva.UsuarioId)
                .OrderByDescending(r => r.DataDeCadastro)
                .FirstOrDefault();

            if (ultimaReserva == null)
                return ValidationResult;

            DateTime dataUltimaReserva = ultimaReserva.DataDeCadastro;

            dataUltimaReserva = dataUltimaReserva.AddHours(_areaComum.ObterHorasDeIntervaloDeReservaPorUsuario);
            dataUltimaReserva = dataUltimaReserva.AddMinutes(_areaComum.ObterMinutosDeIntervaloDeReservaPorUsuario);

            if (dataUltimaReserva > DataHoraDeBrasilia.Get())
            {
                AdicionarErros("Você não pode realizar outra reserva para esta área comum até " +
                    dataUltimaReserva.ToLongDateString() + " as " + dataUltimaReserva.ToLongTimeString());                
            }
            return ValidationResult;
        }
    }
}
