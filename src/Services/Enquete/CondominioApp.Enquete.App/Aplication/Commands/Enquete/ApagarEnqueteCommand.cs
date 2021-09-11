using CondominioApp.Enquetes.App.Aplication.Commands.Validations;
using System;
using System.Collections.Generic;

namespace CondominioApp.Enquetes.App.Aplication.Commands
{
   public class ApagarEnqueteCommand : EnqueteCommand
    {

        public ApagarEnqueteCommand(Guid enqueteId)
        {
            Id = enqueteId;           
        }


        public override bool EstaValido()
        {
            ValidationResult = new ApagarEnqueteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ApagarEnqueteCommandValidation : EnqueteValidation<ApagarEnqueteCommand>
        {
            public ApagarEnqueteCommandValidation()
            {
                ValidateId();                         
            }
        }

    }
}
