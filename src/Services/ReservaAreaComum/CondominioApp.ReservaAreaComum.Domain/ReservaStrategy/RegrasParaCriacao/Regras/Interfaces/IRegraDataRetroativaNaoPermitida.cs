using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces
{
    public interface IRegraDataRetroativaNaoPermitida
    {
        ValidationResult Validar(Reserva reserva);
    }
}
