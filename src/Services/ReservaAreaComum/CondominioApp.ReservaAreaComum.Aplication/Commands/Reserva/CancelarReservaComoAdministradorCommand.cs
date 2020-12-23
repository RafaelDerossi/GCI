

using CondominioApp.Principal.Aplication.Commands.Validations;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
   public class CancelarReservaComoAdministradorCommand : ReservaCommand
    {

        public CancelarReservaComoAdministradorCommand
            (Guid reservaId, string justificatica)
        {            
            Id = reservaId;
            Justificativa = justificatica;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CancelarReservaComoAdministradorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CancelarReservaComoAdministradorCommandValidation : ReservaValidation<CancelarReservaComoAdministradorCommand>
        {
            public CancelarReservaComoAdministradorCommandValidation()
            {
                ValidateId();
                ValidateJustificativa();
            }
        }

    }
}
