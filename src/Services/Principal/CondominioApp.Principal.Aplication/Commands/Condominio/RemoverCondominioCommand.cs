using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
   public class RemoverCondominioCommand : CondominioCommand
    {

        public RemoverCondominioCommand(Guid condominioId)
        {
            CondominioId = condominioId;           
        }


        public override bool EstaValido()
        {
            ValidationResult = new RemoverCondominioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        
        public class RemoverCondominioCommandValidation : CondominioValidation<RemoverCondominioCommand>
        {
            public RemoverCondominioCommandValidation()
            {
                ValidateId();              
            }
        }

    }
}
