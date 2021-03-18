using CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations;
using FluentValidation;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class AlterarPastaDoArquivoCommand : ArquivoCommand
    {

        public AlterarPastaDoArquivoCommand
            (Guid id, Guid pastaId)
        {
            Id = id;
            PastaId = pastaId;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AlterarPastaDoArquivoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AlterarPastaDoArquivoCommandValidation : ArquivoValidation<AlterarPastaDoArquivoCommand>
        {
            public AlterarPastaDoArquivoCommandValidation()
            {
                ValidateId();
                ValidatePastaId();
            }
        }

    }
}
