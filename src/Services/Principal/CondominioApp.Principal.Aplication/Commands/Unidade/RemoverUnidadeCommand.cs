using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
    public class RemoverUnidadeCommand : UnidadeCommand
    {
        public RemoverUnidadeCommand(Guid unidadeId)
        {
            UnidadeId = unidadeId;          
        }

        public override bool EstaValido()
        {
            ValidationResult = new RemoverUnidadeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class RemoverUnidadeCommandValidation : UnidadeValidation<RemoverUnidadeCommand>
        {
            public RemoverUnidadeCommandValidation()
            {
                ValidateId();                                    
            }
        }

    }
}
