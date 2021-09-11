using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class RemoverMoradorCommand : MoradorCommand
    {
        public RemoverMoradorCommand(Guid moradorId)
        {
            Id = moradorId;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new ExcluirMoradorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ExcluirMoradorCommandValidation : MoradorValidation<RemoverMoradorCommand>
        {
            public ExcluirMoradorCommandValidation()
            {
                ValidateId();                
            }
        }

    }
}