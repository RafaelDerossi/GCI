using CondominioApp.Core.Enumeradores;
using CondominioApp.Ocorrencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands
{
    public class MarcarRespostaOcorrenciaComoVistaCommand : RespostaOcorrenciaCommand
    {
        public MarcarRespostaOcorrenciaComoVistaCommand(Guid id)
        {
            Id = id;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new MarcarRespostaOcorrenciaComoVistoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class MarcarRespostaOcorrenciaComoVistoCommandValidation : RespostaOcorrenciaValidation<MarcarRespostaOcorrenciaComoVistaCommand>
        {
            public MarcarRespostaOcorrenciaComoVistoCommandValidation()
            {
                ValidateId();
            }
        }
    }
}
