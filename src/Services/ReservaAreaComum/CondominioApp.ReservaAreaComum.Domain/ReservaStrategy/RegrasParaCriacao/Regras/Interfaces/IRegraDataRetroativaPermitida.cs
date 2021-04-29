using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces
{
    public interface IRegraDataRetroativaPermitida
    {
        ValidationResult Validar(Reserva reserva);
    }
}
