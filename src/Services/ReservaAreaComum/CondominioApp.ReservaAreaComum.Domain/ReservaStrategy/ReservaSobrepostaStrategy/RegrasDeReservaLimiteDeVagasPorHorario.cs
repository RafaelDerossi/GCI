using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.ReservaSobrepostaStrategy
{
    public class RegrasDeReservaLimiteDeVagasPorHorario : RegrasDeReservaSobrepostaStrategy
    {
        private readonly Reserva _reserva;

        private readonly AreaComum _areaComum;

        public RegrasDeReservaLimiteDeVagasPorHorario(Reserva reserva, AreaComum areaComum)
        {
            _reserva = reserva;
            _areaComum = areaComum;
        }

        public override ValidationResult Validar()
        {
            List<Reserva> ReservasAprovadas = _areaComum.Reservas
                .Where(x => x.Ativa &&
                            x.DataDeRealizacao == _reserva.DataDeRealizacao &&
                            !x.EstaNaFila &&
                            !x.Cancelada &&
                            !x.Lixeira)
                .ToList();
            
            return OverLap(ReservasAprovadas, _reserva);
            
        }

        /// <summary>
        /// Verificação de reservas sobrepostas
        /// </summary>
        /// <param name="reservasAprovadas"></param>
        /// <param name="reservaNova"></param>
        /// <returns></returns>
        private ValidationResult OverLap(List<Reserva> reservasAprovadas, Reserva reservaNova)
        {
            var verificadorDeHorariosConflitantes = new VerificadorDeHorariosConflitantes();

            foreach (var reserva in reservasAprovadas)
            {
                bool overlap = verificadorDeHorariosConflitantes.Verificar(reserva, reservaNova);

                if (overlap && reserva.ReservadoPelaAdministracao)
                {
                    AdicionarErros("Este período foi reservado pela administração de seu condomínio!");
                    return ValidationResult;
                }
                else if(overlap)
                {
                    AdicionarErros("O horário que você deseja esta comprometido, deseja ficar em uma fila de espera?");
                    return ValidationResult;
                }
            }
            return ValidationResult;
        }
    }
}
