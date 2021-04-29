using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.RegrasDeMorador
{
    public interface IRegrasDeMoradorParaReservar
    {
        ValidationResult Validar(Reserva reserva, AreaComum areaComum);        
    }
}
