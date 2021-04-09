using CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations;
using FluentValidation;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class RemoverArquivoCommand : ArquivoCommand
    {

        public RemoverArquivoCommand
            (Guid id)
        {
            Id = id;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new RemoverArquivoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class RemoverArquivoCommandValidation : ArquivoValidation<RemoverArquivoCommand>
        {
            public RemoverArquivoCommandValidation()
            {             
                ValidateId();
            }
        }

    }
}
