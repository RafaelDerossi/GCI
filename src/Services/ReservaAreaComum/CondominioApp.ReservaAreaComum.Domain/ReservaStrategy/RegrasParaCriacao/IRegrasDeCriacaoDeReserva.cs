using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva
{
    public interface IRegrasDeCriacaoDeReserva
    {
        ValidationResult Validar(Reserva reserva, AreaComum areaComum);
        ValidationResult VerificaReservasAprovadas(Reserva _reserva, AreaComum _areaComum);
    }
}
