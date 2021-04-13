using CondominioApp.Core.Enumeradores;
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
                .Where(x => x.Status == StatusReserva.APROVADA &&
                            x.DataDeRealizacao == _reserva.DataDeRealizacao &&                            
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
            foreach (var reserva in reservasAprovadas)
            {
                bool overlap = VerificadorDeHorariosConflitantes.Verificar(reserva, reservaNova);

                if (overlap && reserva.ReservadoPelaAdministracao)
                {
                    _reserva.Reprovar("Este período foi reservado pela administração de seu condomínio!");
                    AdicionarErros(_reserva.Justificativa);
                    return ValidationResult;
                }
                else if(overlap)
                {
                    _reserva.EnviarParaFila("O horário que você deseja esta comprometido, sua solicitação de reserva foi encaminhada para a fila de espera.");
                    AdicionarErros(_reserva.Justificativa);
                    return ValidationResult;
                }
            }
            return ValidationResult;
        }
    }
}
