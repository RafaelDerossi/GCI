using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
    public class ApagarUnidadeCommand : UnidadeCommand
    {
        public ApagarUnidadeCommand(Guid unidadeId)
        {
            UnidadeId = unidadeId;          
        }

        public override bool EstaValido()
        {
            ValidationResult = new ApagarUnidadeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ApagarUnidadeCommandValidation : UnidadeValidation<ApagarUnidadeCommand>
        {
            public ApagarUnidadeCommandValidation()
            {
                ValidateId();                                    
            }
        }

    }
}
