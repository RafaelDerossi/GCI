using FluentValidation.Results;

namespace CondominioApp.OneSignal.Recursos
{
   public abstract class RetornoBase
    {
        public ValidationResult ValidationResult { get; private set; }

        public virtual bool ComSucesso()
        {
            return ValidationResult.IsValid;
        }

        public void AdicionarErrosDeProcessamento(string mensagemDeErro)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagemDeErro));
        }

        protected RetornoBase()
        {
            ValidationResult = new ValidationResult();
        }        
    }
}
