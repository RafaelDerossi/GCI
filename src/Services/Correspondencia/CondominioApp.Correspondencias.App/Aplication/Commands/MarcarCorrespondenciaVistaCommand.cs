using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Correspondencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Correspondencias.App.Aplication.Commands
{
    public class MarcarCorrespondenciaVistaCommand : CorrespondenciaCommand
    {
        public MarcarCorrespondenciaVistaCommand(Guid correspondenciaId)
        {
            CorrespondenciaId = correspondenciaId;           
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new MarcarCorrespondenciaVistaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class MarcarCorrespondenciaVistaCommandValidation : CorrespondenciaValidation<MarcarCorrespondenciaVistaCommand>
        {
            public MarcarCorrespondenciaVistaCommandValidation()
            {
                ValidateId();               
            }
        }
    }
}
