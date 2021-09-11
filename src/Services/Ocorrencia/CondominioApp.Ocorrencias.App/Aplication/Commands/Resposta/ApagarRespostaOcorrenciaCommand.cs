using CondominioApp.Ocorrencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands
{
    public class ApagarRespostaOcorrenciaCommand : RespostaOcorrenciaCommand
    {
        public ApagarRespostaOcorrenciaCommand(Guid id, Guid autorId)
        {
            Id = id;
            AutorId = autorId;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new ApagarRespostaOcorrenciaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ApagarRespostaOcorrenciaCommandValidation : RespostaOcorrenciaValidation<ApagarRespostaOcorrenciaCommand>
        {
            public ApagarRespostaOcorrenciaCommandValidation()
            {
                ValidateId();
                ValidateAutorId();
            }
        }
    }
}
