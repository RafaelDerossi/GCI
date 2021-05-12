using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
   public class ApagarCondominioCommand : CondominioCommand
    {

        public ApagarCondominioCommand(Guid condominioId)
        {
            CondominioId = condominioId;           
        }


        public override bool EstaValido()
        {
            ValidationResult = new ApagarCondominioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        
        public class ApagarCondominioCommandValidation : CondominioValidation<ApagarCondominioCommand>
        {
            public ApagarCondominioCommandValidation()
            {
                ValidateId();              
            }
        }

    }
}
