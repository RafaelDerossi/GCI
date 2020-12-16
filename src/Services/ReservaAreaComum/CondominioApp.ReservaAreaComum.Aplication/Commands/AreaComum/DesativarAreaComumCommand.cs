using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
    public class DesativarAreaComumCommand : AreaComumCommand
    {
        public DesativarAreaComumCommand(Guid areaComumId)
        {
            AreaComumId = areaComumId;           
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new DesativarAreaComumCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class DesativarAreaComumCommandValidation : AreaComumValidation<DesativarAreaComumCommand>
        {
            public DesativarAreaComumCommandValidation()
            {
                ValidateId();               
            }
        }
    }
}
