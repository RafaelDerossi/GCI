using CondominioApp.Ocorrencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands
{
    public class MarcarOcorrenciaComoResolvidaCommand : OcorrenciaCommand
    {
        public MarcarOcorrenciaComoResolvidaCommand
            (Guid ocorrenciaId, string parecer)
        {
            Id = ocorrenciaId;
            MarcarComoResolvida(parecer);
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new MarcarOcorrenciaComoResolvidaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class MarcarOcorrenciaComoResolvidaCommandValidation : OcorrenciaValidation<MarcarOcorrenciaComoResolvidaCommand>
        {
            public MarcarOcorrenciaComoResolvidaCommandValidation()
            {
                ValidateId();
                ValidateParecer();
            }
        }
    }
}
