using System;
using FluentValidation;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations
{
   public class ArquivoValidation<T> : AbstractValidator<T> where T : ArquivoCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }           

        protected void ValidateTamanho()
        {
            RuleFor(c => c.Tamanho)
                .NotEmpty()
                .WithMessage("Tamanho do Arquivo deve ser maior que zero!"); ;
        }

        protected void ValidateCondominioId()
        {
            RuleFor(c => c.CondominioId)
                .NotEqual(Guid.Empty);
                
        }

        protected void ValidatePastaId()
        {
            RuleFor(c => c.PastaId)
                .NotEqual(Guid.Empty);                
        }

        protected void ValidatePublico()
        {
            RuleFor(c => c.Publico)                
                .NotNull()        
                .WithMessage("Publico não pode estar vazio!");
        }            
     
    }
}
