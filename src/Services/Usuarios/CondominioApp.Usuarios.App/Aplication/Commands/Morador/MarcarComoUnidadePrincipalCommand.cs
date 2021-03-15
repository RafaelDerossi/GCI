using System;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class MarcarComoUnidadePrincipalCommand : MoradorCommand
    {
        public MarcarComoUnidadePrincipalCommand(Guid moradorId)
        {
            Id = moradorId;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new MarcarUnidadeComoPrincipalCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class MarcarUnidadeComoPrincipalCommandValidation : MoradorValidation<MarcarComoUnidadePrincipalCommand>
        {
            public MarcarUnidadeComoPrincipalCommandValidation()
            {
                ValidateId();                
            }
        }

    }
}