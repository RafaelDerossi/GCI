

using CondominioApp.Principal.Aplication.Commands.Validations;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
   public class AguardarAprovacaoDaReservaPelaAdmCommand : ReservaCommand
    {

        public AguardarAprovacaoDaReservaPelaAdmCommand
            (Guid reservaId, string justificativa)
        {            
            Id = reservaId;
            Justificativa = justificativa;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AguardarAprovacaoDaReservaPelaAdmCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AguardarAprovacaoDaReservaPelaAdmCommandValidation : ReservaValidation<AguardarAprovacaoDaReservaPelaAdmCommand>
        {
            public AguardarAprovacaoDaReservaPelaAdmCommandValidation()
            {
                ValidateId();                
            }
        }

    }
}
