using CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations;
using FluentValidation;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class MarcarPastaComoPublicaCommand : PastaCommand
    {

        public MarcarPastaComoPublicaCommand(Guid id)
        {
            Id = id;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new MarcarPastaComoPublicaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class MarcarPastaComoPublicaCommandValidation : PastaValidation<MarcarPastaComoPublicaCommand>
        {
            public MarcarPastaComoPublicaCommandValidation()
            {
                ValidateId();                
            }
        }

    }
}
