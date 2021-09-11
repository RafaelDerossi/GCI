

using CondominioApp.Principal.Aplication.Commands.Validations;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
   public class ReprovarReservaAutomaticamenteCommand : ReservaCommand
    {

        public ReprovarReservaAutomaticamenteCommand
            (Guid reservaId, string justificativa)
        {            
            Id = reservaId;
            Justificativa = justificativa;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new ReprovarReservaAutomaticamenteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ReprovarReservaAutomaticamenteCommandValidation : ReservaValidation<ReprovarReservaAutomaticamenteCommand>
        {
            public ReprovarReservaAutomaticamenteCommandValidation()
            {
                ValidateId();
                ValidateJustificativa();
            }
        }

    }
}
