using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.RegrasParaAdministrador
{
    public interface IRegrasDeAdministradorParaReservar
    {
        ValidationResult Validar(Reserva reserva);
    }
}
