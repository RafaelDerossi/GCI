using CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations;
using FluentValidation;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class MarcarPastaComoPrivadaCommand : PastaCommand
    {

        public MarcarPastaComoPrivadaCommand(Guid id)
        {
            Id = id;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new MarcarPastaComoPrivadaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class MarcarPastaComoPrivadaCommandValidation : PastaValidation<MarcarPastaComoPrivadaCommand>
        {
            public MarcarPastaComoPrivadaCommandValidation()
            {
                ValidateId();                
            }
        }

    }
}
