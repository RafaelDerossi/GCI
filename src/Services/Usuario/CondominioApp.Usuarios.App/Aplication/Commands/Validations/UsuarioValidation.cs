using FluentValidation;
using System;

namespace CondominioApp.Usuarios.App.Aplication.Commands.Validations
{
    public abstract class UsuarioValidation<T> : AbstractValidator<T> where T : UsuarioCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.UsuarioId)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateCondominioId()
        {
            RuleFor(c => c.CondominioId)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateUnidadeId()
        {
            RuleFor(c => c.UnidadeId)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .Length(2, 150).WithMessage("Nome do usuario deve ter entre 2 e 150 caracteres!");
        }

        protected void ValidateSobrenome()
        {
            RuleFor(c => c.Sobrenome)
                .NotEmpty()
                .Length(2, 150).WithMessage("Sobrenome do usuario deve ter entre 2 e 150 caracteres!");
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email.Endereco)
                  .NotNull()
                  .NotEmpty()
                  .EmailAddress()
                  .WithMessage("E-mail do usuario não pode estar vazio!");
        }


        protected void ValidateAtribuicao()
        {
            RuleFor(c => c.Atribuicao)                
                .MaximumLength(200).WithMessage("Atribuição do funcionario deve ter no máximo 200 caracteres!");
        }

        protected void ValidateFuncao()
        {
            RuleFor(c => c.Funcao)                
                .MaximumLength(200).WithMessage("Função do funcionario deve ter no máximo 200 caracteres!");
        }

    }
}
