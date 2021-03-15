using FluentValidation;
using System;

namespace CondominioApp.Usuarios.App.Aplication.Commands.Validations
{
    public abstract class FuncionarioValidation<T> : AbstractValidator<T> where T : FuncionarioCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateUsuarioId()
        {
            RuleFor(c => c.UsuarioId)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateCondominioId()
        {
            RuleFor(c => c.CondominioId)
                .NotEqual(Guid.Empty);
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
