using CondominioApp.Ocorrencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands
{
    public class ColocarOcorrenciaEmAndamentoCommand : OcorrenciaCommand
    {
        public ColocarOcorrenciaEmAndamentoCommand
            (Guid ocorrenciaId, string parecer)
        {
            Id = ocorrenciaId;
            ColocarEmAndamento(parecer);
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new ColocarOcorrenciaEmAndamentoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ColocarOcorrenciaEmAndamentoCommandValidation : OcorrenciaValidation<ColocarOcorrenciaEmAndamentoCommand>
        {
            public ColocarOcorrenciaEmAndamentoCommandValidation()
            {
                ValidateId();
                ValidateParecer();
            }
        }
    }
}
