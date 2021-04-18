using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy
{
    public interface IRegrasDeReserva
    {
        ValidationResult Validar();        
    }
}
