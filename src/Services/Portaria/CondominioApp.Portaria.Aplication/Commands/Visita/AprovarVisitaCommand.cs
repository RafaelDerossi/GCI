using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
   public class AprovarVisitaCommand : VisitaCommand
    {
        public AprovarVisitaCommand(Guid id)
        {
            Id = id;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AprovarVisitaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AprovarVisitaCommandValidation : VisitaValidation<AprovarVisitaCommand>
        {
            public AprovarVisitaCommandValidation()
            {
                ValidateId();
            }
        }

    }
}
