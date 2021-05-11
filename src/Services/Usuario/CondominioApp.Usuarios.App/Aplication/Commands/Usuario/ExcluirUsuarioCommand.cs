using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class ExcluirUsuarioCommand : UsuarioCommand
    {
        public ExcluirUsuarioCommand(Guid usuarioId)
        {
            UsuarioId = usuarioId;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new ExcluirUsuarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ExcluirUsuarioCommandValidation : UsuarioValidation<ExcluirUsuarioCommand>
        {
            public ExcluirUsuarioCommandValidation()
            {
                ValidateId();                
            }
        }

    }
}