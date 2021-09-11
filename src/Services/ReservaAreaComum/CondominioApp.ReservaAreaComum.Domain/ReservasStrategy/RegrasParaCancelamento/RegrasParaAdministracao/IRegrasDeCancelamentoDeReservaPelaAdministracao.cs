using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCancelamento.RegrasParaAdministracao
{
    public interface IRegrasDeCancelamentoDeReservaPelaAdministracao
    {
        ValidationResult Validar(Reserva reserva);        
    }
}
