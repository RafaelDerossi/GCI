using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
   public class AtualizarLogoDoCondominioCommand : CondominioCommand
    {

        public AtualizarLogoDoCondominioCommand(Guid condominioId, string nomeOriginalArquivoLogo)
        {
            Id = condominioId;
            SetLogo(nomeOriginalArquivoLogo);
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtualizarLogoDoCondominioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtualizarLogoDoCondominioCommandValidation : CondominioValidation<AtualizarLogoDoCondominioCommand>
        {
            public AtualizarLogoDoCondominioCommandValidation()
            {
                ValidateId();
            }
        }

    }
}
