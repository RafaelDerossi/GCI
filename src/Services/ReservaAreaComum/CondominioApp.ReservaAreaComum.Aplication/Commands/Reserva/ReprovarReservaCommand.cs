

using CondominioApp.Principal.Aplication.Commands.Validations;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
   public class ReprovarReservaCommand : ReservaCommand
    {

        public ReprovarReservaCommand
            (Guid reservaId, string justificativa)
        {            
            Id = reservaId;
            Justificativa = justificativa;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new ReprovarReservaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ReprovarReservaCommandValidation : ReservaValidation<ReprovarReservaCommand>
        {
            public ReprovarReservaCommandValidation()
            {
                ValidateId();                
            }
        }

    }
}
