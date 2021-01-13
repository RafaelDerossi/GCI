using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
   public class RemoverVisitanteCommand : VisitanteCommand
    {
        public RemoverVisitanteCommand(Guid id)
        {
            Id = id;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new RemoverVisitanteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class RemoverVisitanteCommandValidation : VisitanteValidation<RemoverVisitanteCommand>
        {
            public RemoverVisitanteCommandValidation()
            {
                ValidateId();
            }
        }

    }
}
