using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegraDeReservaBase;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces;
using CondominioApp.ReservaAreaComum.Domain.ValueObject;
using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.Regras
{
    public class RegraBloqueioDaAreaComum : RegrasDeReservaBase, IRegraBloqueioDaAreaComum
    {       
        public ValidationResult Validar(Reserva _reserva, AreaComum _areaComum)
        {
            ValidationResult.Errors.Clear();
            if (!string.IsNullOrEmpty(_areaComum.DataInicioBloqueio.ToString()))
            {
                BloqueioDeArea bloqueioDeAreaComum = new BloqueioDeArea(_areaComum.DataInicioBloqueio.Value, _areaComum.DataFimBloqueio.Value);
                if (bloqueioDeAreaComum.EstaBloqueada(_reserva.DataDeRealizacao))
                {
                    _reserva.Reprovar(bloqueioDeAreaComum.ToString());
                    AdicionarErros(_reserva.Justificativa);
                    return ValidationResult;
                }
            }

            return ValidationResult;
        }
    }
}
