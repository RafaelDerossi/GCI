using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCancelamento.Regras.Interfaces
{
    public interface IRegraDoStatusPraCancelar
    {
        ValidationResult Validar(Reserva reserva);
    }
}
