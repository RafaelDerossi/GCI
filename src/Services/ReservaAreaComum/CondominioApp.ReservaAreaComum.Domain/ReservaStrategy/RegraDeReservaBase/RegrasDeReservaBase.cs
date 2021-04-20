using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegraDeReservaBase
{
    public abstract class RegrasDeReservaBase
    {
        protected ValidationResult ValidationResult { get; private set; } = new ValidationResult();


        protected void AdicionarErros(string mensagem)
        {            
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }        
    }
}
