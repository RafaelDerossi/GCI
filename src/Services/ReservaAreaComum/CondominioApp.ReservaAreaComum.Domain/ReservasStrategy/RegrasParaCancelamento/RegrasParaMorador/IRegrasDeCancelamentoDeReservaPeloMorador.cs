using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCancelamento.RegrasParaMorador
{
    public interface IRegrasDeCancelamentoDeReservaPeloMorador
    {
        ValidationResult Validar(Reserva reserva, AreaComum areaComum);        
    }
}
