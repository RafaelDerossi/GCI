using CondominioApp.Comunicados.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Comunicados.App.Aplication.Commands
{
    public class ApagarComunicadoCommand : ComunicadoCommand
    {
        public ApagarComunicadoCommand(Guid comunicadoId)
        {
            ComunicadoId = comunicadoId;           
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new ApagarComunicadoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ApagarComunicadoCommandValidation : ComunicadoValidation<ApagarComunicadoCommand>
        {
            public ApagarComunicadoCommandValidation()
            {
                ValidateId();               
            }
        }
    }
}
