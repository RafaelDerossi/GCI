using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.ReservaSobrepostaStrategy
{
    public class RegrasDeReservaLimiteDeVagasPorHorario : RegrasDeReservaSobrepostaStrategy
    {
        private readonly AreaComum _areaComum;

        private readonly Reserva _reserva;

        public RegrasDeReservaLimiteDeVagasPorHorario(AreaComum areaComum, Reserva reserva)
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
            int quantidadeReservaMesmoHorario = _areaComum.Reservas.Count(x => x.Ativa && !x.EstaNaFila && !x.Lixeira &&
                                                                               x.ObterHoraInicio == _reserva.ObterHoraInicio &&
                                                                               x.ObterHoraFim == _reserva.ObterHoraFim);

            if (quantidadeReservaMesmoHorario >= _areaComum.NumeroLimiteDeReservaSobreposta)
            {
                AdicionarErros("Não ha mais vagas para o período selecionado!");
                return ValidationResult;
            }

            return ValidationResult;
        }

        private ValidationResult ValidarQuantidadeDeVagasPorUnidade()
        {
            int quantidadeReservaMesmoHorarioPorUnidade = _areaComum.Reservas.Count(x => x.Ativa && !x.EstaNaFila && !x.Lixeira &&
                                                                                         x.ObterHoraInicio == _reserva.ObterHoraInicio &&
                                                                                         x.ObterHoraFim == _reserva.ObterHoraFim &&
                                                                                         x.UnidadeId == _reserva.UnidadeId);

            if (quantidadeReservaMesmoHorarioPorUnidade >= _areaComum.NumeroLimiteDeReservaSobrepostaPorUnidade)
            {
                AdicionarErros("Não ha mais vagas no período selecionado para sua unidade!");
                return ValidationResult;
            }

            return ValidationResult;
        }
    }
}
