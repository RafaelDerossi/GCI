using CondominioApp.Core.Enumeradores;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.ReservaSobrepostaStrategy
{
    public class RegraParaReservaComSobreposicao : RegrasDeReservaSobrepostaBase
    {
        private readonly AreaComum _areaComum;

        private readonly Reserva _reserva;

        public RegraParaReservaComSobreposicao(AreaComum areaComum, Reserva reserva)
        {
            _areaComum = areaComum;
            _reserva = reserva;
        }

        public override ValidationResult Validar()
        {
            var validationResultQuantidadeDeVagas = ValidarQuantidadeDeVagas();
            if (!validationResultQuantidadeDeVagas.IsValid) return validationResultQuantidadeDeVagas;

            return ValidarQuantidadeDeVagasPorUnidade();
        }

        private ValidationResult ValidarQuantidadeDeVagas()
        {
            int quantidadeReservaMesmoHorario = _areaComum.Reservas.Count(x => x.Status == StatusReserva.APROVADA && !x.Lixeira &&
                                                                               x.ObterHoraInicio == _reserva.ObterHoraInicio &&
                                                                               x.ObterHoraFim == _reserva.ObterHoraFim &&
                                                                               x.DataDeRealizacao == _reserva.DataDeRealizacao);

            if (quantidadeReservaMesmoHorario > 0 && _areaComum.NumeroLimiteDeReservaSobreposta > 0 && 
                quantidadeReservaMesmoHorario >= _areaComum.NumeroLimiteDeReservaSobreposta)
            {
                _reserva.EnviarParaFila("Não ha mais vagas para o período selecionado! Sua Solicitação de reserva foi encaminhada para a fila de espera.");
                AdicionarErros(_reserva.Justificativa);
                return ValidationResult;
            }

            return ValidationResult;
        }

        private ValidationResult ValidarQuantidadeDeVagasPorUnidade()
        {
            int quantidadeReservaMesmoHorarioPorUnidade = _areaComum.Reservas.Count(x => x.Status == StatusReserva.APROVADA && !x.Lixeira &&
                                                                                         x.ObterHoraInicio == _reserva.ObterHoraInicio &&
                                                                                         x.ObterHoraFim == _reserva.ObterHoraFim &&
                                                                                         x.UnidadeId == _reserva.UnidadeId &&
                                                                                         x.DataDeRealizacao == _reserva.DataDeRealizacao);

            if (quantidadeReservaMesmoHorarioPorUnidade > 0 && _areaComum.NumeroLimiteDeReservaSobrepostaPorUnidade > 0 &&
                quantidadeReservaMesmoHorarioPorUnidade >= _areaComum.NumeroLimiteDeReservaSobrepostaPorUnidade)
            {
                _reserva.Reprovar("Não ha mais vagas no período selecionado para sua unidade!");
                AdicionarErros(_reserva.Justificativa);
                return ValidationResult;
            }

            return ValidationResult;
        }
    }
}
