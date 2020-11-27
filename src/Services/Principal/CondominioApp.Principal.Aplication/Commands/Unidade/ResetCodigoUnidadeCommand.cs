using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
    public class ResetCodigoUnidadeCommand : UnidadeCommand
    {
        public ResetCodigoUnidadeCommand(Guid unidadeId)
        {
            UnidadeId = unidadeId;          
        }

        public override bool EstaValido()
        {
            if (!base.EstaValido())
                return ValidationResult.IsValid;

            ValidationResult = new ResetCodigoUnidadeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ResetCodigoUnidadeCommandValidation : UnidadeValidation<ResetCodigoUnidadeCommand>
        {
            public ResetCodigoUnidadeCommandValidation()
            {
                ValidateId();                                    
            }
        }

    }
}
