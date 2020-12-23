

using CondominioApp.Principal.Aplication.Commands.Validations;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
   public class AprovarReservaCommand : ReservaCommand
    {

        public AprovarReservaCommand
            (Guid reservaId)
        {            
            Id = reservaId;           
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AprovarReservaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AprovarReservaCommandValidation : ReservaValidation<AprovarReservaCommand>
        {
            public AprovarReservaCommandValidation()
            {
                ValidateId();                
            }
        }

    }
}
