using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy
{
    public interface IReservaStrategy
    {
        ValidationResult ValidarRegrasParaCriacao(Reserva reserva, AreaComum areaComum);

        ValidationResult VerificaReservasAprovadas(Reserva _reserva, AreaComum _areaComum);

        ValidationResult ValidarRegrasParaCancelamentoPelaAdministracao(Reserva reserva);

        ValidationResult ValidarRegrasParaCancelamentoPeloMorador(Reserva reserva, AreaComum areaComum);
    }
}
