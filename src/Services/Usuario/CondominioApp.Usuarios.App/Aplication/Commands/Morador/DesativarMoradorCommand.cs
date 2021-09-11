using System;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class DesativarMoradorCommand : MoradorCommand
    {
        public DesativarMoradorCommand(Guid moradorId)
        {
            Id = moradorId;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new DesativarMoradorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class DesativarMoradorCommandValidation : MoradorValidation<DesativarMoradorCommand>
        {
            public DesativarMoradorCommandValidation()
            {
                ValidateId();                
            }
        }

    }
}