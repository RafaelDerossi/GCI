using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
   public class RemoverVisitaCommand : VisitaCommand
    {
        public RemoverVisitaCommand(Guid id)
        {
            Id = id;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new RemoverVisitaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class RemoverVisitaCommandValidation : VisitaValidation<RemoverVisitaCommand>
        {
            public RemoverVisitaCommandValidation()
            {
                ValidateId();
            }
        }

    }
}
