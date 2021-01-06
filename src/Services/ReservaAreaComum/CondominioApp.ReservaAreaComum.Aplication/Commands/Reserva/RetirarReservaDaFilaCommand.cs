

using CondominioApp.Principal.Aplication.Commands.Validations;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
   public class RetirarReservaDaFilaCommand : ReservaCommand
    {

        public RetirarReservaDaFilaCommand
            (Guid reservaCanceladaId)
        {            
            Id = reservaCanceladaId;           
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new RetirarReservaDaFilaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class RetirarReservaDaFilaCommandValidation : ReservaValidation<RetirarReservaDaFilaCommand>
        {
            public RetirarReservaDaFilaCommandValidation()
            {
                ValidateId();                
            }
        }

    }
}
