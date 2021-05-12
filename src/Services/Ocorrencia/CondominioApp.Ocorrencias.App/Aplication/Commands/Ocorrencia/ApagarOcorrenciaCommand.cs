using CondominioApp.Ocorrencias.App.Aplication.Commands.Validations;
using CondominioApp.Ocorrencias.App.ValueObjects;
using System;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands
{
    public class ApagarOcorrenciaCommand : OcorrenciaCommand
    {
        public ApagarOcorrenciaCommand
            (Guid id)
        {
            Id = id;            
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new ApagarOcorrenciaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ApagarOcorrenciaCommandValidation : OcorrenciaValidation<ApagarOcorrenciaCommand>
        {
            public ApagarOcorrenciaCommandValidation()
            {
                ValidateId();
            }
        }
    }
}
