using CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations;
using FluentValidation;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class MoverPastaParaRaizCommand : PastaCommand
    {

        public MoverPastaParaRaizCommand(Guid id)
        {
            Id = id;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new MoverPastaParaRaizCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class MoverPastaParaRaizCommandValidation : PastaValidation<MoverPastaParaRaizCommand>
        {
            public MoverPastaParaRaizCommandValidation()
            {
                ValidateId();
            }
        }

    }
}
