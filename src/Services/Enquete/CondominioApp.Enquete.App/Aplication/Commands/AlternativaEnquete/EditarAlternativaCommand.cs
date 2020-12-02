using CondominioApp.Enquetes.App.Aplication.Commands.Validations;
using System;
using System.Collections.Generic;

namespace CondominioApp.Enquetes.App.Aplication.Commands
{
   public class EditarAlternativaCommand : AlternativaEnqueteCommand
    {

        public EditarAlternativaCommand(Guid alternativaId, string descricao)
        {
            Id = alternativaId;
            Descricao = descricao;                  
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new EditarAlternativaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class EditarAlternativaCommandValidation : AlternativaEnqueteValidation<EditarAlternativaCommand>
        {
            public EditarAlternativaCommandValidation()
            {
                ValidateId();
                ValidateDescricao();                             
            }
        }

    }
}
