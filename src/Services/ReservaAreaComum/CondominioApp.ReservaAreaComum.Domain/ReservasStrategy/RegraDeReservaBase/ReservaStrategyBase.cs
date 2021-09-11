using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegraDeReservaBase
{
    public abstract class ReservaStrategyBase
    {
        protected ValidationResult ValidationResult { get; private set; } = new ValidationResult();


        protected void AdicionarErros(string mensagem)
        {            
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }        
    }
}
