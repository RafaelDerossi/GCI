using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Correspondencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Correspondencias.App.Aplication.Commands
{
    public class DispararAlertaDeCorrespondenciaCommand : CorrespondenciaCommand
    {
        public DispararAlertaDeCorrespondenciaCommand(Guid correspondenciaId)
        {
            CorrespondenciaId = correspondenciaId;           
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new DispararAlertaDeCorrespondenciaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class DispararAlertaDeCorrespondenciaCommandValidation : CorrespondenciaValidation<DispararAlertaDeCorrespondenciaCommand>
        {
            public DispararAlertaDeCorrespondenciaCommandValidation()
            {
                ValidateId();               
            }
        }
    }
}
