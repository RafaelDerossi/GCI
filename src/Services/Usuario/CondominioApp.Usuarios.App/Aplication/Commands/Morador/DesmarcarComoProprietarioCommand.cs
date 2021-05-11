using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class DesmarcarComoProprietarioCommand : MoradorCommand
    {
        public DesmarcarComoProprietarioCommand(Guid moradorId)
        {
            Id = moradorId;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new DesmarcarComoProprietarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class DesmarcarComoProprietarioCommandValidation : MoradorValidation<DesmarcarComoProprietarioCommand>
        {
            public DesmarcarComoProprietarioCommandValidation()
            {
                ValidateId();                
            }
        }

    }
}