using CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations;
using FluentValidation;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class ApagarArquivoCommand : ArquivoCommand
    {

        public ApagarArquivoCommand
            (Guid id)
        {
            Id = id;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new ApagarArquivoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ApagarArquivoCommandValidation : ArquivoValidation<ApagarArquivoCommand>
        {
            public ApagarArquivoCommandValidation()
            {             
                ValidateId();
            }
        }

    }
}
