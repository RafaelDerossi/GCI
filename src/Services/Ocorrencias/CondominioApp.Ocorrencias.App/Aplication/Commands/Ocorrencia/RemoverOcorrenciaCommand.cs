using CondominioApp.Ocorrencias.App.Aplication.Commands.Validations;
using CondominioApp.Ocorrencias.App.ValueObjects;
using System;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands
{
    public class RemoverOcorrenciaCommand : OcorrenciaCommand
    {
        public RemoverOcorrenciaCommand
            (Guid id)
        {
            Id = id;            
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new ExcluirOcorrenciaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ExcluirOcorrenciaCommandValidation : OcorrenciaValidation<RemoverOcorrenciaCommand>
        {
            public ExcluirOcorrenciaCommandValidation()
            {
                ValidateId();
            }
        }
    }
}
