

using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
   public class RemoverArquivoAnexoDaAreaComumCommand : AreaComumCommand
    {

        public RemoverArquivoAnexoDaAreaComumCommand(Guid areaComumId)
        {
            Id = areaComumId;
            SetNomeArquivoAnexo("");
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new RemoverArquivoAnexoDaAreaComumCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class RemoverArquivoAnexoDaAreaComumCommandValidation : AreaComumValidation<RemoverArquivoAnexoDaAreaComumCommand>
        {
            public RemoverArquivoAnexoDaAreaComumCommandValidation()
            {
                ValidateId();
            }
        }

    }
}
