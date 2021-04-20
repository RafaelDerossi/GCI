using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCancelamento.RegrasParaAdministracao
{
    public interface IRegrasDeCancelamentoDeReservaPelaAdministracao
    {
        ValidationResult Validar(Reserva reserva);        
    }
}
