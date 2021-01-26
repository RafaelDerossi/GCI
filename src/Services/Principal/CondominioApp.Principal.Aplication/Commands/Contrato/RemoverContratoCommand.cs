using CondominioApp.Core.Enumeradores;
using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
   public class RemoverContratoCommand : ContratoCommand
    {
        public RemoverContratoCommand(Guid id)
        {
            Id = id;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new RemoverContratoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class RemoverContratoCommandValidation : ContratoValidation<RemoverContratoCommand>
        {
            public RemoverContratoCommandValidation()
            {
                ValidateId();            
            }
        }

    }
}
