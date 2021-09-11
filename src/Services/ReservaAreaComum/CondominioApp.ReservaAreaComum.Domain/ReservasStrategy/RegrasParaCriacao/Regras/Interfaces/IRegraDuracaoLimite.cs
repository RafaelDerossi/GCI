using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces
{
    public interface IRegraDuracaoLimite
    {
        ValidationResult Validar(Reserva reserva, AreaComum areaComum);
    }
}
