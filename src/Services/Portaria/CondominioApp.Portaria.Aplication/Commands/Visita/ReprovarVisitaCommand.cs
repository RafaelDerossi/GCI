using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
   public class ReprovarVisitaCommand : VisitaCommand
    {
        public ReprovarVisitaCommand(Guid id)
        {
            Id = id;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new ReprovarVisitaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ReprovarVisitaCommandValidation : VisitaValidation<ReprovarVisitaCommand>
        {
            public ReprovarVisitaCommandValidation()
            {
                ValidateId();
            }
        }

    }
}
