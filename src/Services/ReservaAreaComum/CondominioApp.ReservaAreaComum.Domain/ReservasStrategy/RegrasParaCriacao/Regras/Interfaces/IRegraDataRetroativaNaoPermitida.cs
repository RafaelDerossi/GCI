using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces
{
    public interface IRegraDataRetroativaNaoPermitida
    {
        ValidationResult Validar(Reserva reserva);
    }
}
