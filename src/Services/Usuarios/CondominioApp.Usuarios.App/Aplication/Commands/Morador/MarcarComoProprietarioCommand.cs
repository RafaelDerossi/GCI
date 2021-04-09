using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class MarcarComoProprietarioCommand : MoradorCommand
    {
        public MarcarComoProprietarioCommand(Guid moradorId)
        {
            Id = moradorId;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new MarcarComoProprietarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class MarcarComoProprietarioCommandValidation : MoradorValidation<MarcarComoProprietarioCommand>
        {
            public MarcarComoProprietarioCommandValidation()
            {
                ValidateId();                
            }
        }

    }
}