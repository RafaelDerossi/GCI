using CondominioApp.Enquetes.App.Aplication.Commands.Validations;
using System;
using System.Collections.Generic;

namespace CondominioApp.Enquetes.App.Aplication.Commands
{
   public class AlterarAlternativaCommand : AlternativaEnqueteCommand
    {

        public AlterarAlternativaCommand(Guid alternativaId, string descricao)
        {
            Id = alternativaId;
            Descricao = descricao;                  
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AlterarAlternativaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AlterarAlternativaCommandValidation : AlternativaEnqueteValidation<AlterarAlternativaCommand>
        {
            public AlterarAlternativaCommandValidation()
            {
                ValidateId();
                ValidateDescricao();                             
            }
        }

    }
}
