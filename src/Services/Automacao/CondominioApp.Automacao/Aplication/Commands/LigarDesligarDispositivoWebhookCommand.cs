using CondominioApp.Automacao.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Automacao.App.Aplication.Commands
{
    public class LigarDesligarDispositivoWebhookCommand : DispositivoWebhookCommand
    {
        public LigarDesligarDispositivoWebhookCommand(Guid id)
        {
            Id = id;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new LigarDesligarDispositivoWebhookCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class LigarDesligarDispositivoWebhookCommandValidation : DispositivoWebhookValidation<LigarDesligarDispositivoWebhookCommand>
        {
            public LigarDesligarDispositivoWebhookCommandValidation()
            {
                ValidateId();
            }
        }
    }
}
