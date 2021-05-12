using CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations;
using FluentValidation;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class ApagarPastaCommand : PastaCommand
    {

        public ApagarPastaCommand(Guid id)
        {
            Id = id;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new ApagarPastaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ApagarPastaCommandValidation : PastaValidation<ApagarPastaCommand>
        {
            public ApagarPastaCommandValidation()
            {
                ValidateId();                
            }
        }

    }
}
