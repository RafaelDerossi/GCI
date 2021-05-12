using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class ApagarMoradorCommand : MoradorCommand
    {
        public ApagarMoradorCommand(Guid moradorId)
        {
            Id = moradorId;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new ApagarMoradorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ApagarMoradorCommandValidation : MoradorValidation<ApagarMoradorCommand>
        {
            public ApagarMoradorCommandValidation()
            {
                ValidateId();                
            }
        }

    }
}