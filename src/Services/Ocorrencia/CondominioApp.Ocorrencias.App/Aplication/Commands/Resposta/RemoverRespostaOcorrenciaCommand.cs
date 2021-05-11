using CondominioApp.Core.Enumeradores;
using CondominioApp.Ocorrencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands
{
    public class RemoverRespostaOcorrenciaCommand : RespostaOcorrenciaCommand
    {
        public RemoverRespostaOcorrenciaCommand(Guid id)
        {
            Id = id;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new RemoverRespostaOcorrenciaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class RemoverRespostaOcorrenciaCommandValidation : RespostaOcorrenciaValidation<RemoverRespostaOcorrenciaCommand>
        {
            public RemoverRespostaOcorrenciaCommandValidation()
            {
                ValidateId();
            }
        }
    }
}
