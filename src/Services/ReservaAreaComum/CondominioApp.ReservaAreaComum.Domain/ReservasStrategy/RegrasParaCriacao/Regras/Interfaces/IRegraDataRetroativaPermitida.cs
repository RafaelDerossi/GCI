using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces
{
    public interface IRegraDataRetroativaPermitida
    {
        ValidationResult Validar(Reserva reserva);
    }
}
