using CondominioApp.Automacao.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Automacao.App.Aplication.Commands
{
    public class ApagarDispositivoWebhookCommand : DispositivoWebhookCommand
    {
        public ApagarDispositivoWebhookCommand(Guid id)
        {
            Id = id;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new ApagarDispositivoWebhookCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ApagarDispositivoWebhookCommandValidation : DispositivoWebhookValidation<ApagarDispositivoWebhookCommand>
        {
            public ApagarDispositivoWebhookCommandValidation()
            {
                ValidateId();
            }
        }
    }
}
