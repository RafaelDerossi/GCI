using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace CondominioApp.Usuarios.App.Aplication.Commands.Validations
{    
    public abstract class UsuarioValidation<T> : AbstractValidator<T> where T : UsuarioCommand
    {
        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty() //.WithMessage("Nome do morador não pode estar vazio!")
                .Length(2, 150).WithMessage("Nome do morador deve ter mais de 2 caracteres!");
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email.Endereco)
                  .NotNull()
                  .NotEmpty()
                  .EmailAddress()
                  .WithMessage("E-mail do morador não pode estar vazio!");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.UsuarioId)
                .NotEqual(Guid.Empty);
        }      

    }
}
