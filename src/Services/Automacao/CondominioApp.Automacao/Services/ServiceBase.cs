using System;
using CondominioApp.Automacao.App.Services.Interfaces;
using FluentValidation.Results;

namespace CondominioApp.Automacao.Services
{
    public abstract class ServiceBase : IServiceBase
    {        
        public ValidationResult ValidationResult { get; set; }

        protected ServiceBase()
        {            
            ValidationResult = new ValidationResult();
        }

        public virtual bool EstaValido()
        {
            return ValidationResult.IsValid;
        }

        public void AdicionarErrosDeProcessamento(string mensagemDeErro)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty,mensagemDeErro));
        }
    }
}