using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class AtualizarUltimoLoginUsuarioCommand : UsuarioCommand
    {

        public AtualizarUltimoLoginUsuarioCommand(Guid usuarioId)
        {
            UsuarioId = usuarioId;
        }
        
        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new EditarUltimoLoginUsuarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        

        public class EditarUltimoLoginUsuarioCommandValidation : UsuarioValidation<AtualizarUltimoLoginUsuarioCommand>
        {
            public EditarUltimoLoginUsuarioCommandValidation()
            {
                ValidateId();                
            }
        }
    }
}