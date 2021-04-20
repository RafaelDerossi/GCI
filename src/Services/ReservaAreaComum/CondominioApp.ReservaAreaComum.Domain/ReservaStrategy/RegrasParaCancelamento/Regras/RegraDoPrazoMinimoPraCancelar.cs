using CondominioApp.Core.Helpers;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegraDeReservaBase;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCancelamento.Regras.Interfaces;
using FluentValidation.Results;
using System;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCancelamento.Regras
{
    public class RegraDoPrazoMinimoPraCancelar : RegrasDeReservaBase, IRegraDoPrazoMinimoPraCancelar
    {       
        public ValidationResult Validar(Reserva reserva, AreaComum areaComum)
        {
            ValidationResult.Errors.Clear();

            var dataAtual = DataHoraDeBrasilia.Get();

            int qtdDias = Convert.ToInt32((reserva.DataDeRealizacao.Date - dataAtual.Date).TotalDays);
            if (qtdDias <= areaComum.AntecedenciaMinimaParaCancelamentoEmDias && areaComum.AntecedenciaMinimaParaCancelamentoEmDias > 0)
            {
                AdicionarErros("Prazo para cancelamento expirado!");
                return ValidationResult;
            }

            if (qtdDias == 0 && areaComum.AntecedenciaMinimaParaCancelamentoEmDias == 0)
            {
                var horaAtual = dataAtual.ToString("HH:mm");
                var horaAtualInt = Convert.ToInt32(horaAtual.Replace(":", ""));

                if (horaAtualInt >= reserva.ObterHoraInicio)
                {
                    AdicionarErros("Prazo para cancelamento expirado!");
                    return ValidationResult;
                }
            }

            if (qtdDias < 0 && areaComum.AntecedenciaMinimaParaCancelamentoEmDias == 0)
            {
                AdicionarErros("Prazo para cancelamento expirado!");
                return ValidationResult;
            }

            return ValidationResult;
        }
    }
}
