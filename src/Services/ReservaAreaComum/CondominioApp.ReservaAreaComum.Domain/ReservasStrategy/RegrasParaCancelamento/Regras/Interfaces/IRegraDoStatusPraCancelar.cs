using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCancelamento.Regras.Interfaces
{
    public interface IRegraDoStatusPraCancelar
    {
        ValidationResult Validar(Reserva reserva);
    }
}
