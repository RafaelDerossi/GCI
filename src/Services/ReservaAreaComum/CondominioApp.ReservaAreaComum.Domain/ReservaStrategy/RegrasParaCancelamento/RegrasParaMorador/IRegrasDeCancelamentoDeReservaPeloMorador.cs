using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCancelamento.RegrasParaMorador
{
    public interface IRegrasDeCancelamentoDeReservaPeloMorador
    {
        ValidationResult Validar(Reserva reserva, AreaComum areaComum);        
    }
}
