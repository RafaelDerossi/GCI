using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Correspondencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Correspondencias.App.Aplication.Commands
{
    public class ApagarCorrespondenciaCommand : CorrespondenciaCommand
    {
        public ApagarCorrespondenciaCommand(Guid correspondenciaId)
        {
            CorrespondenciaId = correspondenciaId;           
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new ApagarCorrespondenciaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ApagarCorrespondenciaCommandValidation : CorrespondenciaValidation<ApagarCorrespondenciaCommand>
        {
            public ApagarCorrespondenciaCommandValidation()
            {
                ValidateId();               
            }
        }
    }
}
