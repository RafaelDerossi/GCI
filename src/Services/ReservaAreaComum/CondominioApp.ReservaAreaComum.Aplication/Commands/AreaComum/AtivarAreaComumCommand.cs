using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
    public class AtivarAreaComumCommand : AreaComumCommand
    {
        public AtivarAreaComumCommand(Guid areaComumId)
        {
            Id = areaComumId;           
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtivarAreaComumCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtivarAreaComumCommandValidation : AreaComumValidation<AtivarAreaComumCommand>
        {
            public AtivarAreaComumCommandValidation()
            {
                ValidateId();               
            }
        }
    }
}
