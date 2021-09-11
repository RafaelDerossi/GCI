using FluentValidation;
using System;

namespace CondominioApp.Principal.Aplication.Commands.Validations
{
    public abstract class ContratoValidation<T> : AbstractValidator<T> where T : ContratoCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
        protected void ValidateCondominioId()
        {
            RuleFor(c => c.CondominioId)
                   .NotEqual(Guid.Empty);
        }
    }
}
