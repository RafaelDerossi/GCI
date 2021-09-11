using CondominioApp.Core.Enumeradores;
using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
   public class ApagarContratoCommand : ContratoCommand
    {
        public ApagarContratoCommand(Guid id)
        {
            Id = id;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new ApagarContratoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ApagarContratoCommandValidation : ContratoValidation<ApagarContratoCommand>
        {
            public ApagarContratoCommandValidation()
            {
                ValidateId();            
            }
        }

    }
}
