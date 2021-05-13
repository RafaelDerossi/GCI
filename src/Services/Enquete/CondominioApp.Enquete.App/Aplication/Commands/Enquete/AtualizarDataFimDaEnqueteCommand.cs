using CondominioApp.Enquetes.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Enquetes.App.Aplication.Commands
{
   public class AtualizarDataFimDaEnqueteCommand : EnqueteCommand
    {

        public AtualizarDataFimDaEnqueteCommand
            (Guid enqueteId, DateTime dataFim)
        {
            Id = enqueteId;            
            SetDataFim(dataFim);            
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtualizarDataFimDaEnqueteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtualizarDataFimDaEnqueteCommandValidation : EnqueteValidation<AtualizarDataFimDaEnqueteCommand>
        {
            public AtualizarDataFimDaEnqueteCommandValidation()
            {
                ValidateId();                                
                ValidateDataFinal();
            }
        }

    }
}
