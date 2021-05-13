using CondominioApp.Enquetes.App.Aplication.Commands.Validations;
using System;
using System.Collections.Generic;

namespace CondominioApp.Enquetes.App.Aplication.Commands
{
   public class AtualizarAlternativaCommand : AlternativaEnqueteCommand
    {

        public AtualizarAlternativaCommand(Guid alternativaId, string descricao)
        {
            Id = alternativaId;
            Descricao = descricao;                  
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtualizarAlternativaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtualizarAlternativaCommandValidation : AlternativaEnqueteValidation<AtualizarAlternativaCommand>
        {
            public AtualizarAlternativaCommandValidation()
            {
                ValidateId();
                ValidateDescricao();                             
            }
        }

    }
}
