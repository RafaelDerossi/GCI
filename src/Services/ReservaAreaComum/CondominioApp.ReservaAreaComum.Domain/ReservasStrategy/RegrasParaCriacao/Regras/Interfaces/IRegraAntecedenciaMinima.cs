using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces
{
    public interface IRegraAntecedenciaMinima
    {
        ValidationResult Validar(Reserva reserva, AreaComum areaComum);
    }
}
