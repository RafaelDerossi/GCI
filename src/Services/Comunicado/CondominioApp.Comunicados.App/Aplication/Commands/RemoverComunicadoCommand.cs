using CondominioApp.Comunicados.App.Aplication.Commands.Validations;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using System;

namespace CondominioApp.Comunicados.App.Aplication.Commands
{
    public class RemoverComunicadoCommand : ComunicadoCommand
    {
        public RemoverComunicadoCommand(Guid comunicadoId)
        {
            ComunicadoId = comunicadoId;           
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new RemoverComunicadoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class RemoverComunicadoCommandValidation : ComunicadoValidation<RemoverComunicadoCommand>
        {
            public RemoverComunicadoCommandValidation()
            {
                ValidateId();               
            }
        }
    }
}
