using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
   public class TerminarVisitaCommand : VisitaCommand
    {
        public TerminarVisitaCommand(Guid id)
        {
            Id = id;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new TerminarVisitaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class TerminarVisitaCommandValidation : VisitaValidation<TerminarVisitaCommand>
        {
            public TerminarVisitaCommandValidation()
            {
                ValidateId();
            }
        }

    }
}
