using CondominioApp.Enquetes.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Enquetes.App.Aplication.Commands
{
   public class EditarDataFimDaEnqueteCommand : EnqueteCommand
    {

        public EditarDataFimDaEnqueteCommand
            (Guid enqueteId, DateTime dataFim)
        {
            Id = enqueteId;            
            SetDataFim(dataFim);            
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new EditarDataFimDaEnqueteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class EditarDataFimDaEnqueteCommandValidation : EnqueteValidation<EditarDataFimDaEnqueteCommand>
        {
            public EditarDataFimDaEnqueteCommandValidation()
            {
                ValidateId();                                
                ValidateDataFinal();
            }
        }

    }
}
