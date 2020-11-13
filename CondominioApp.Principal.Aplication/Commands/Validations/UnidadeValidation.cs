using FluentValidation;
using System;

namespace CondominioApp.Principal.Aplication.Commands.Validations
{
    public abstract class UnidadeValidation<T> : AbstractValidator<T> where T : UnidadeCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.UnidadeId)
                .NotEqual(Guid.Empty);
        }       
        protected void ValidateCodigo()
        {
            RuleFor(c => c.Codigo)
                .NotNull()
                .NotEmpty()
                .WithMessage("Codigo do condominio não pode estar vazio!");                
        }
        protected void ValidateNumero()
        {
            RuleFor(c => c.Numero)
                  .NotNull().WithMessage("Numero não pode estar vazio!")
                  .NotEmpty().WithMessage("Numero não pode estar vazio!");
        }
        protected void ValidateAndar()
        {
            RuleFor(c => c.Andar)
                  .NotNull()
                  .NotEmpty()
                  .WithMessage("Andar não pode estar vazio!");
        }
        protected void ValidateVaga()
        {
            RuleFor(c => c.Vaga)
                  .NotNull()                 
                  .WithMessage("Vaga não pode estar vazio!");
        }        
        protected void ValidateGrupoId()
        {
            RuleFor(c => c.GrupoId)
               .NotEqual(Guid.Empty);
        }
        protected void ValidateCondominioId()
        {
            RuleFor(c => c.CondominioId)
               .NotEqual(Guid.Empty);
        }
    }
}
