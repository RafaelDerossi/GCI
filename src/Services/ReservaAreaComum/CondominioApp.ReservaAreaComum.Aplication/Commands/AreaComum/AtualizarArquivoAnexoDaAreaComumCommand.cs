

using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
   public class AtualizarArquivoAnexoDaAreaComumCommand : AreaComumCommand
    {

        public AtualizarArquivoAnexoDaAreaComumCommand(Guid areaComumId, string nomeOriginalFoto)
        {
            Id = areaComumId;            
            SetNomeArquivoAnexo(nomeOriginalFoto);
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtualizarArquivoAnexoDaAreaComumCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtualizarArquivoAnexoDaAreaComumCommandValidation : AreaComumValidation<AtualizarArquivoAnexoDaAreaComumCommand>
        {
            public AtualizarArquivoAnexoDaAreaComumCommandValidation()
            {
                ValidateId();
                ValidateArquivoAnexo();
            }
        }

    }
}
