using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.ReservaSobrepostaStrategy
{
    public class RegraDeReservaSobreposta : RegrasDeReservaSobrepostaStrategy
    {
        private readonly AreaComum _areaComum;

        private readonly Reserva _reserva;

        public RegraDeReservaSobreposta(AreaComum areaComum, Reserva reserva)
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
            int quantidadeReservaMesmoHorario = _areaComum.Reservas.Count(x => x.Ativa && !x.EstaNaFila && !x.Cancelada && !x.Lixeira &&
                                                                               x.ObterHoraInicio == _reserva.ObterHoraInicio &&
                                                                               x.ObterHoraFim == _reserva.ObterHoraFim &&
                                                                               x.DataDeRealizacao == _reserva.DataDeRealizacao);

            if (quantidadeReservaMesmoHorario > 0 && _areaComum.NumeroLimiteDeReservaSobreposta > 0 && 
                quantidadeReservaMesmoHorario >= _areaComum.NumeroLimiteDeReservaSobreposta)
            {
                AdicionarErros("Não ha mais vagas para o período selecionado!");
                return ValidationResult;
            }

            return ValidationResult;
        }
        private ValidationResult ValidarQuantidadeDeVagasPorUnidade()
        {
            int quantidadeReservaMesmoHorarioPorUnidade = _areaComum.Reservas.Count(x => x.Ativa && !x.EstaNaFila && !x.Cancelada && !x.Lixeira &&
                                                                                         x.ObterHoraInicio == _reserva.ObterHoraInicio &&
                                                                                         x.ObterHoraFim == _reserva.ObterHoraFim &&
                                                                                         x.UnidadeId == _reserva.UnidadeId &&
                                                                                         x.DataDeRealizacao == _reserva.DataDeRealizacao);

            if (quantidadeReservaMesmoHorarioPorUnidade > 0 && _areaComum.NumeroLimiteDeReservaSobrepostaPorUnidade > 0 &&
                quantidadeReservaMesmoHorarioPorUnidade >= _areaComum.NumeroLimiteDeReservaSobrepostaPorUnidade)
            {
                AdicionarErros("Não ha mais vagas no período selecionado para sua unidade!");
                return ValidationResult;
            }

            return ValidationResult;
        }
    }
}
