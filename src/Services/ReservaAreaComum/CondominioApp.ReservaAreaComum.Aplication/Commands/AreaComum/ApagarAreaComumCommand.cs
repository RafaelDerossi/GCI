using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
    public class ApagarAreaComumCommand : AreaComumCommand
    {
        public ApagarAreaComumCommand(Guid areaComumId)
        {
            Id = areaComumId;           
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new ApagarAreaComumCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ApagarAreaComumCommandValidation : AreaComumValidation<ApagarAreaComumCommand>
        {
            public ApagarAreaComumCommandValidation()
            {
                ValidateId();               
            }
        }
    }
}
