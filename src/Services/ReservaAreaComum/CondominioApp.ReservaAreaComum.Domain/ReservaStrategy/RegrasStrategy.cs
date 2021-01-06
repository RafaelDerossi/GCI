using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy
{
    public abstract class RegrasStrategy
    {
        protected ValidationResult ValidationResult { get; private set; } = new ValidationResult();

        protected void AdicionarErros(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        public abstract ValidationResult Validar();


    }
}
