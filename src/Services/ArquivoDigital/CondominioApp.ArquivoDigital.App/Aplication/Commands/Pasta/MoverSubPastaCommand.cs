using CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations;
using FluentValidation;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class MoverSubPastaCommand : PastaCommand
    {

        public MoverSubPastaCommand(Guid id, Guid? pastaMaeId)
        {
            Id = id;
            PastaMaeId = pastaMaeId;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new MoverSubPastaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class MoverSubPastaCommandValidation : PastaValidation<MoverSubPastaCommand>
        {
            public MoverSubPastaCommandValidation()
            {
                ValidateId();
                ValidatePastaMae();
            }
        }

    }
}
