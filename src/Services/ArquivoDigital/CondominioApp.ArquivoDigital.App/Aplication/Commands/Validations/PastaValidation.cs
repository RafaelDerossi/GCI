using System;
using FluentValidation;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations
{
   public class PastaValidation<T> : AbstractValidator<T> where T : PastaCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
        protected void ValidateTitulo()
        {
            RuleFor(c => c.Titulo)
                .NotEmpty()
                .Length(1, 50).WithMessage("Titulo da Pasta deve ter entre 1 e 50 caracteres!");
        }
        protected void ValidateDescricao()
        {
            RuleFor(c => c.Descricao)                
                .Length(0, 200).WithMessage("Descrição da Pasta deve ter até 200 caracteres!");
        }

        protected void ValidatePublica()
        {
            RuleFor(c => c.Publica)                
                .NotNull()                
                .WithMessage("Publica não pode estar vazio!");
        }     

        protected void ValidateCondominioId()
        {
            RuleFor(c => c.CondominioId)
                .NotEqual(Guid.Empty)
                .WithMessage("Condominio não pode estar vazio!");
        }
     
    }
}
