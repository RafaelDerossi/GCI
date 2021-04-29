using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.RegrasGerais
{
    public interface IRegrasGeraisParaReservar
    {
        ValidationResult Validar(Reserva _reserva, AreaComum _areaComum);

        ValidationResult VerificaReservasAprovadas(Reserva _reserva, AreaComum _areaComum);
    }
}
