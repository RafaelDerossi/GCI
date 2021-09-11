using CondominioApp.Core.Enumeradores;
using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
   public class DesativarContratoCommand : ContratoCommand
    {
        public DesativarContratoCommand(Guid id)
        {
            Id = id;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new DesativarContratoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class DesativarContratoCommandValidation : ContratoValidation<DesativarContratoCommand>
        {
            public DesativarContratoCommandValidation()
            {
                ValidateId();            
            }
        }

    }
}
