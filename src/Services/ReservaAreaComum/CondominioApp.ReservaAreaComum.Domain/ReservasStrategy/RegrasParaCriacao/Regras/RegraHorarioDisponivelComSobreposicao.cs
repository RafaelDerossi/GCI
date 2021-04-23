using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegraDeReservaBase;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaHorariosConflitantes;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras
{
    public class RegraHorarioDisponivelComSobreposicao : ReservaStrategyBase, IRegraHorarioDisponivelComSobreposicao
    {       
        public ValidationResult Validar(Reserva _reserva, AreaComum _areaComum)
        {
            ValidationResult.Errors.Clear();

            var retorno = ValidarQuantidadeDeVagasPorUnidade(_reserva, _areaComum);
            if (!retorno.IsValid) 
                return retorno;

            return ValidarQuantidadeDeVagas(_reserva, _areaComum);
        }

        private ValidationResult ValidarQuantidadeDeVagas(Reserva _reserva, AreaComum _areaComum)
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

        private ValidationResult ValidarQuantidadeDeVagasPorUnidade(Reserva _reserva, AreaComum _areaComum)
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
