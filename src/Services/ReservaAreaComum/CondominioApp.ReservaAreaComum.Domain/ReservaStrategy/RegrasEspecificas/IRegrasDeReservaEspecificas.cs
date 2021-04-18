using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy
{
    public interface IRegrasDeReservaEspecificas
    {
        ValidationResult Validar();        
    }
}
