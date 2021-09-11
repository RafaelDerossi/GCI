using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.RegrasGerais
{
    public interface IRegrasGeraisParaReservar
    {
        ValidationResult Validar(Reserva _reserva, AreaComum _areaComum);

        ValidationResult VerificaReservasAprovadas(Reserva _reserva, AreaComum _areaComum);
    }
}
