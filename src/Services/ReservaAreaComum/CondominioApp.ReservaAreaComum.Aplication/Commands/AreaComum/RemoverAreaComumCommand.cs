using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
    public class RemoverAreaComumCommand : AreaComumCommand
    {
        public RemoverAreaComumCommand(Guid areaComumId)
        {
            Id = areaComumId;           
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new RemoverAreaComumCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class RemoverAreaComumCommandValidation : AreaComumValidation<RemoverAreaComumCommand>
        {
            public RemoverAreaComumCommandValidation()
            {
                ValidateId();               
            }
        }
    }
}
