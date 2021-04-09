using CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations;
using FluentValidation;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class RemoverPastaCommand : PastaCommand
    {

        public RemoverPastaCommand(Guid id)
        {
            Id = id;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new RemoverPastaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class RemoverPastaCommandValidation : PastaValidation<RemoverPastaCommand>
        {
            public RemoverPastaCommandValidation()
            {
                ValidateId();                
            }
        }

    }
}
