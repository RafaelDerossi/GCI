using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces
{
    public interface IRegraBloqueioDaAreaComum
    {
        ValidationResult Validar(Reserva reserva, AreaComum areaComum);
    }
}
