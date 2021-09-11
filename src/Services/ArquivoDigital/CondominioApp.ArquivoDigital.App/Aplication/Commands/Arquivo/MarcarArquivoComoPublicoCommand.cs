using CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations;
using FluentValidation;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class MarcarArquivoComoPublicoCommand : ArquivoCommand
    {

        public MarcarArquivoComoPublicoCommand
            (Guid id)
        {
            Id = id;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new MarcarComoArquivoPublicoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class MarcarComoArquivoPublicoCommandValidation : ArquivoValidation<MarcarArquivoComoPublicoCommand>
        {
            public MarcarComoArquivoPublicoCommandValidation()
            {             
                ValidateId();
            }
        }

    }
}
