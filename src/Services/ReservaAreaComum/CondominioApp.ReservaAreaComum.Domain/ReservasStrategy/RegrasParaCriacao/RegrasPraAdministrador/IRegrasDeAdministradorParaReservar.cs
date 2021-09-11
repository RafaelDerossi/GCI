using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.RegrasParaAdministrador
{
    public interface IRegrasDeAdministradorParaReservar
    {
        ValidationResult Validar(Reserva reserva);
    }
}
