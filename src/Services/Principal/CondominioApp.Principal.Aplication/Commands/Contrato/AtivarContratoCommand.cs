using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
   public class AtivarContratoCommand : ContratoCommand
    {
        public AtivarContratoCommand(Guid id)
        {
            Id = id;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtivarContratoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtivarContratoCommandValidation : ContratoValidation<AtivarContratoCommand>
        {
            public AtivarContratoCommandValidation()
            {
                ValidateId();            
            }
        }

    }
}
