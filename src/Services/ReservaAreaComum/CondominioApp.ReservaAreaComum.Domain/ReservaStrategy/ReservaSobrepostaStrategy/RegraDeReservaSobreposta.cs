using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.ReservaSobrepostaStrategy
{
    public class RegraDeReservaSobreposta : RegrasDeReservaSobrepostaStrategy
    {
        private readonly Reserva _reserva;

        private readonly AreaComum _areaComum;

        public RegraDeReservaSobreposta(Reserva reserva, AreaComum areaComum)
        {
            _reserva = reserva;
            _areaComum = areaComum;
        }

        public override ValidationResult Validar()
        {
            List<Reserva> ReservasAprovadas = _areaComum.Reservas.Where(x => x.Ativa && !x.EstaNaFila && !x.Lixeira).ToList();

            if (OverLap(ReservasAprovadas, _reserva))
            {
                //Bloquear reserva quando ha uma reserva da administração
                if (ReservasAprovadas.Any(x => (x.ReservadoPelaAdministracao && _reserva.SaberSeReservaSobrepoeOutraOuEIgual(x))))
                {
                    AdicionarErros("Este período foi reservado pela administração de seu condomínio!");
                    return ValidationResult;
                }

                AdicionarErros("O horário que você deseja esta comprometido, deseja ficar em uma fila de espera?");
                return ValidationResult;
            }
            else
                return ValidationResult;
        }

        /// <summary>
        /// Verificação de reservas sobrepostas
        /// </summary>
        /// <param name="ReservasAprovadas"></param>
        /// <param name="nova"></param>
        /// <returns></returns>
        private bool OverLap(List<Reserva> ReservasAprovadas, Reserva nova)
        {
            foreach (var reserva in ReservasAprovadas)
            {
                bool overlap = nova.ObterHoraInicio < reserva.ObterHoraFim && reserva.ObterHoraInicio < nova.ObterHoraFim;

                int hInicio = nova.ObterHoraInicio;
                int hrInicio = reserva.ObterHoraInicio;

                //if (!overlap)
                //{
                //    hrInicio++;
                //    hrInicio++;
                //    overlap = hInicio > reserva.HoraFim && hrInicio > reserva.HoraFim;
                //}

                if (overlap)
                    return true;
            }
            return false;
        }
    }
}
