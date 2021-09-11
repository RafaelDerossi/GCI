using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
   public class IniciarVisitaCommand : VisitaCommand
    {
        public IniciarVisitaCommand(Guid id)
        {
            Id = id;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new IniciarVisitaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class IniciarVisitaCommandValidation : VisitaValidation<IniciarVisitaCommand>
        {
            public IniciarVisitaCommandValidation()
            {
                ValidateId();
            }
        }

    }
}
