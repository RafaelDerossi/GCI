using CondominioApp.Enquetes.App.Aplication.Commands.Validations;
using System;
using System.Collections.Generic;

namespace CondominioApp.Enquetes.App.Aplication.Commands
{
   public class RemoverAlternativaCommand : AlternativaEnqueteCommand
    {

        public RemoverAlternativaCommand(Guid alternativaId)
        {
            Id = alternativaId;                        
        }

        public override bool EstaValido()
        {
            ValidationResult = new RemoverAlternativaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class RemoverAlternativaCommandValidation : AlternativaEnqueteValidation<RemoverAlternativaCommand>
        {
            public RemoverAlternativaCommandValidation()
            {
                ValidateId();                           
            }
        }

    }
}
