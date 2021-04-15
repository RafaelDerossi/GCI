

using CondominioApp.Principal.Aplication.Commands.Validations;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
   public class MarcarReservaComoExpiradaCommand : ReservaCommand
    {
        public MarcarReservaComoExpiradaCommand
            (Guid reservaId, string justificativa)
        {            
            Id = reservaId;
            Justificativa = justificativa;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new MarcarReservaComoExpiradaCommandCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class MarcarReservaComoExpiradaCommandCommandValidation : ReservaValidation<MarcarReservaComoExpiradaCommand>
        {
            public MarcarReservaComoExpiradaCommandCommandValidation()
            {
                ValidateId();
                ValidateJustificativa();
            }
        }

    }
}
