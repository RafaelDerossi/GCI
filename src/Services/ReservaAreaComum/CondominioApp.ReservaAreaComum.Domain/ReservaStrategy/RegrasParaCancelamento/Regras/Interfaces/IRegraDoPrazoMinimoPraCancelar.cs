using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCancelamento.Regras.Interfaces
{
    public interface IRegraDoPrazoMinimoPraCancelar
    {
        ValidationResult Validar(Reserva reserva, AreaComum areaComum);
    }
}
