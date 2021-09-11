using System;
using FluentValidation;

namespace CondominioApp.Automacao.App.Aplication.Commands.Validations
{
    public abstract class CondominioCredencialValidation<T> : AbstractValidator<T> where T : CondominioCredencialCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id não pode estar vazio!"); ;
        }

        protected void ValidateCondominioId()
        {
            RuleFor(c => c.CondominioId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do Condominio não pode estar vazio!"); ;
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email.Endereco)
                  .NotNull()
                  .NotEmpty()
                  .EmailAddress()
                  .WithMessage("E-mail não pode estar vazio!");
        }

        protected void ValidateSenha()
        {
            RuleFor(c => c.Senha)
                  .NotNull()
                  .NotEmpty();
        }

        protected void ValidateTipoApiAutomacao()
        {
            RuleFor(c => c.TipoApiAutomacao)
                  .NotNull()
                  .NotEmpty();
        }

    }
}
