

using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
   public class AdicionarFotoDeAreaComumCommand : FotoDaAreaComumCommand
    {

        public AdicionarFotoDeAreaComumCommand(Guid areaComumId, Guid condominioId, string nomeOriginalFoto)
        {
            AreaComumId = areaComumId;
            CondominioId = condominioId;
            SetFoto(nomeOriginalFoto);
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarFotoDeAreaComumCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarFotoDeAreaComumCommandValidation : FotoDaAreaComumValidation<AdicionarFotoDeAreaComumCommand>
        {
            public AdicionarFotoDeAreaComumCommandValidation()
            {
                ValidateAreaComumId();
                ValidateCondominioId();
                ValidateFoto();
            }
        }

    }
}
