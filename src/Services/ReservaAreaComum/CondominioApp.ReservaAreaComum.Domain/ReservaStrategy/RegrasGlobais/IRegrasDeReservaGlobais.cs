using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy
{
    public interface IRegrasDeReservaGlobais
    {
        ValidationResult Validar();        
    }
}
