using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCancelamento.Regras.Interfaces
{
    public interface IRegraDoPrazoMinimoPraCancelar
    {
        ValidationResult Validar(Reserva reserva, AreaComum areaComum);
    }
}
