using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Correspondencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Correspondencias.App.Aplication.Commands
{
    public class RemoverCorrespondenciaCommand : CorrespondenciaCommand
    {
        public RemoverCorrespondenciaCommand(Guid correspondenciaId)
        {
            CorrespondenciaId = correspondenciaId;           
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new RemoverCorrespondenciaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class RemoverCorrespondenciaCommandValidation : CorrespondenciaValidation<RemoverCorrespondenciaCommand>
        {
            public RemoverCorrespondenciaCommandValidation()
            {
                ValidateId();               
            }
        }
    }
}
