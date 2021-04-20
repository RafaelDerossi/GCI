using CondominioApp.Core.Enumeradores;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegraDeReservaBase;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces;
using FluentValidation.Results;
using System.Linq;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.Regras
{
    public class RegraLimitePorUnidadePorDia : RegrasDeReservaBase, IRegraLimitePorUnidadePorDia
    {       
        public ValidationResult Validar(Reserva _reserva, AreaComum _areaComum)
        {
            ValidationResult.Errors.Clear();
            if (_areaComum.NumeroLimiteDeReservaPorUnidade > 0)
            {
                if (_areaComum.Reservas
                    .Where(x => x.UnidadeId == _reserva.UnidadeId &&
                           x.DataDeRealizacao == _reserva.DataDeRealizacao &&
                           x.Status == StatusReserva.APROVADA &&
                           !x.Lixeira)
                    .Count() >= _areaComum.NumeroLimiteDeReservaPorUnidade)
                {
                    _reserva.Reprovar("Limite de reservas diárias desta unidade alcançado!");
                    AdicionarErros(_reserva.Justificativa);
                    return ValidationResult;
                }
            }

            return ValidationResult;
        }
    }
}
