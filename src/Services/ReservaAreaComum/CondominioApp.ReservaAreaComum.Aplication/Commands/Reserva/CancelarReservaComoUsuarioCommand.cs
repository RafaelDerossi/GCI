

using CondominioApp.Principal.Aplication.Commands.Validations;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
   public class CancelarReservaComoUsuarioCommand : ReservaCommand
    {

        public CancelarReservaComoUsuarioCommand
            (Guid reservaId, string justificatica)
        {            
            Id = reservaId;
            Justificativa = justificatica;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CancelarReservaComoUsuarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CancelarReservaComoUsuarioCommandValidation : ReservaValidation<CancelarReservaComoUsuarioCommand>
        {
            public CancelarReservaComoUsuarioCommandValidation()
            {
                ValidateId();
                ValidateJustificativa();
            }
        }

    }
}
