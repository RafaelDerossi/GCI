using CondominioApp.ReservaAreaComum.Aplication.Commands;
using FluentValidation;
using System;

namespace CondominioApp.Principal.Aplication.Commands.Validations
{
    public abstract class FotoDaAreaComumValidation<T> : AbstractValidator<T> where T : FotoDaAreaComumCommand
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

        protected void ValidateAreaComumId()
        {
            RuleFor(c => c.AreaComumId)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateFoto()
        {
            RuleFor(c => c.Foto)
                .NotNull();
        }
    }
}
