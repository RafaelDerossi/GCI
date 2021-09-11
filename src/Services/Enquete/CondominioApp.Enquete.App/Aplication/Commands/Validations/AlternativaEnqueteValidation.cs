using System;
using FluentValidation;

namespace CondominioApp.Enquetes.App.Aplication.Commands.Validations
{
   public class AlternativaEnqueteValidation<T> : AbstractValidator<T> where T : AlternativaEnqueteCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateDescricao()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty()
                .Length(2, 200).WithMessage("Descrição da Enquete deve ter mais de 2 caracteres!");
        }

    }
}
