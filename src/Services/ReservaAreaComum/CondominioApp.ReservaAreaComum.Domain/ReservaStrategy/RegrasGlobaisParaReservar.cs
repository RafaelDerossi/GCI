using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.ReservaSobrepostaStrategy;
using FluentValidation.Results;
using System;
using System.Linq;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy
{
    public class RegrasGlobaisParaReservar : RegrasStrategy
    {
        private readonly Reserva _reserva;

        private readonly AreaComum _areaComum;

        private readonly IRegrasDeReservaSobrepostaStrategy _strategyReservaSobreposta;
        
        public RegrasGlobaisParaReservar(Reserva reserva, AreaComum areaComum, IRegrasDeReservaSobrepostaStrategy strategyReservaSobreposta)
        {
            _reserva = reserva;
            _areaComum = areaComum;            
            _strategyReservaSobreposta = strategyReservaSobreposta;
        }

        public override ValidationResult Validar()
        {
            var result = ValidarIntervalosFixos();
            if (!result.IsValid) return result;

            result = ValidarDuracaoLimiteDaReserva();
            if (!result.IsValid) return result;

            if (!_reserva.EstaNaFila)
                return _strategyReservaSobreposta.Validar();

            return result;
        }

        public ValidationResult VerificaReservasAprovadas()
        {
            return _strategyReservaSobreposta.Validar();
        }

        private ValidationResult ValidarDuracaoLimiteDaReserva()
        {
            //Regra para o tempo de duração da reserva
            if (_areaComum.ObterTempoDeDuracaoDeReserva == 0) return ValidationResult;

            var horaIni = _reserva.HoraInicio.Split(':')[0];
            var minIni = _reserva.HoraInicio.Split(':')[1];
            var horaFim = _reserva.HoraFim.Split(':')[0];
            var minFim = _reserva.HoraFim.Split(':')[1];
            var minutosIni = Convert.ToInt32((60 * Convert.ToInt32(horaIni)) + Convert.ToInt32(minIni));
            var minutosFim = Convert.ToInt32((60 * Convert.ToInt32(horaFim)) + Convert.ToInt32(minFim));

            if ((minutosFim - minutosIni) > _areaComum.ObterTempoDeDuracaoDeReserva)
            {
                AdicionarErros("Período da reserva deve ser no máximo de " + _areaComum.TempoDeDuracaoDeReserva + " hora(s)");
                return ValidationResult;
            }

            return ValidationResult;
        }


        private ValidationResult ValidarIntervalosFixos()
        {
           

            //Regra para Intervalos Fixos
            if (!_areaComum.TemIntervaloFixoEntreReservas) return ValidationResult;

            if (_areaComum.ObterTempoDeIntervaloEntreReservas == 0) return ValidationResult;

            //Pegar o horario fim da ultima reserva realizada
            if (_areaComum.Reservas.Any())
            {
                int HorarioFimDaUltimaReservaFeita = _areaComum.Reservas.OrderByDescending(r => r.DataDeCadastro)
                    .ToList().FirstOrDefault().ObterHoraFim;

                if ((HorarioFimDaUltimaReservaFeita + _areaComum.ObterTempoDeIntervaloEntreReservas) >= _reserva.ObterHoraInicio)
                {
                    AdicionarErros("Esta área esta configurada para reservas com intervalos, não foi possível criar sua reserva, tente um outro horário");
                    return ValidationResult;
                }
            }

            return ValidationResult;
        }

    }
}
