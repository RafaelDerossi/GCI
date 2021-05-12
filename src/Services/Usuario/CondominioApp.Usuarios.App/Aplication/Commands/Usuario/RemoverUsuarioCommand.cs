using System;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class RemoverUsuarioCommand : UsuarioCommand
    {
        public RemoverUsuarioCommand(Guid usuarioId)
        {
            UsuarioId = usuarioId;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new RemoverUsuarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class RemoverUsuarioCommandValidation : UsuarioValidation<RemoverUsuarioCommand>
        {
            public RemoverUsuarioCommandValidation()
            {
                ValidateId();                
            }
        }

    }
}