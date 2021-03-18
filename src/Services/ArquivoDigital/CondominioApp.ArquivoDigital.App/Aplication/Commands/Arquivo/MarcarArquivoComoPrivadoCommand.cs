using CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations;
using FluentValidation;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class MarcarArquivoComoPrivadoCommand : ArquivoCommand
    {

        public MarcarArquivoComoPrivadoCommand
            (Guid id)
        {
            Id = id;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new MarcarComoArquivoPrivadoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class MarcarComoArquivoPrivadoCommandValidation : ArquivoValidation<MarcarArquivoComoPrivadoCommand>
        {
            public MarcarComoArquivoPrivadoCommandValidation()
            {             
                ValidateId();
            }
        }

    }
}
