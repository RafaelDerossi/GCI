

using CondominioApp.Principal.Aplication.Commands.Validations;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
   public class EnviarReservaParaFilaCommand : ReservaCommand
    {

        public EnviarReservaParaFilaCommand
            (Guid reservaId, string justificativa)
        {            
            Id = reservaId;
            Justificativa = justificativa;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new EnviarReservaParaFilaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class EnviarReservaParaFilaCommandValidation : ReservaValidation<EnviarReservaParaFilaCommand>
        {
            public EnviarReservaParaFilaCommandValidation()
            {
                ValidateId();                
            }
        }

    }
}
