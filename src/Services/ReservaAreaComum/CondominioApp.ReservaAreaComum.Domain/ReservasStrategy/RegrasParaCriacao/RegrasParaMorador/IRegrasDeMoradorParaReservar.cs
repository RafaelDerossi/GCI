using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.RegrasDeMorador
{
    public interface IRegrasDeMoradorParaReservar
    {
        ValidationResult Validar(Reserva reserva, AreaComum areaComum);        
    }
}
