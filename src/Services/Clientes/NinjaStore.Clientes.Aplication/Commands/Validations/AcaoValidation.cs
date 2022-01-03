using FluentValidation;
using System;

namespace GCI.Acoes.Aplication.Commands.Validations
{
    public abstract class AcaoValidation<T> : AbstractValidator<T> where T : AcaoCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }       
        protected void ValidateCodigo()
        {
            RuleFor(c => c.Codigo)
                .NotEmpty().WithMessage("Código da Ação não pode estar vazia!")
                .Length(2, 50).WithMessage("Código da Ação deve ter entre 2 e 50 caracteres!");
        }       
        protected void ValidateRazaoSocial()
        {
            RuleFor(c => c.RazaoSocial)
                .NotEmpty().WithMessage("Razão Social da Ação não pode estar vazia!")
                .Length(2, 300).WithMessage("Razão Social da Ação deve ter entre 2 e 300 caracteres!");
        }
    }
}
