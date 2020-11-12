using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Aplication.Commands.Validations
{
    public abstract class GrupoValidation<T> : AbstractValidator<T> where T : GrupoCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.GrupoId)
                .NotEqual(Guid.Empty);
        }       
        protected void ValidateDescricao()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("Nome do condominio não pode estar vazio!")
                .Length(2, 200).WithMessage("Nome do condominio deve ter mais de 2 caracteres!");
        }
        protected void ValidateCondominioId()
        {
            RuleFor(c => c.CondominioId)
                .NotEqual(Guid.Empty);
        }

    }
}
