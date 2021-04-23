using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCancelamento
{
    public interface IRegrasDeCancelamentoDeReserva
    {
        ValidationResult ValidarCancelamentoPelaAdministracao(Reserva reserva);

        ValidationResult ValidarCancelamentoPeloMorador(Reserva reserva, AreaComum areaComum);
    }
}
