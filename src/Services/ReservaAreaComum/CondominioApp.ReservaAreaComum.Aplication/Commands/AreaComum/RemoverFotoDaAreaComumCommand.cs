using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
    public class RemoverFotoDaAreaComumCommand : FotoDaAreaComumCommand
    {
        public RemoverFotoDaAreaComumCommand(Guid fotoId)
        {
            Id = fotoId;           
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new RemoverFotoDaAreaComumCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class RemoverFotoDaAreaComumCommandValidation : FotoDaAreaComumValidation<RemoverFotoDaAreaComumCommand>
        {
            public RemoverFotoDaAreaComumCommandValidation()
            {
                ValidateId();               
            }
        }
    }
}
