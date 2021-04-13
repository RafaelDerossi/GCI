

using CondominioApp.Principal.Aplication.Commands.Validations;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
   public class AprovarReservaAutomaticamenteCommand : ReservaCommand
    {

        public AprovarReservaAutomaticamenteCommand
            (Guid reservaId, string justificativa)
        {            
            Id = reservaId;
            Justificativa = justificativa;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AprovarReservaAutomaticamenteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AprovarReservaAutomaticamenteCommandValidation : ReservaValidation<AprovarReservaAutomaticamenteCommand>
        {
            public AprovarReservaAutomaticamenteCommandValidation()
            {
                ValidateId();
                ValidateJustificativa();
            }
        }

    }
}
