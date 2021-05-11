using System;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class AtivarMoradorCommand : MoradorCommand
    {
        public AtivarMoradorCommand(Guid moradorId)
        {
            Id = moradorId;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtivarMoradorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtivarMoradorCommandValidation : MoradorValidation<AtivarMoradorCommand>
        {
            public AtivarMoradorCommandValidation()
            {
                ValidateId();                
            }
        }

    }
}