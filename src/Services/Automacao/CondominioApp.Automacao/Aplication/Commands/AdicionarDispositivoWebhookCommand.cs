using CondominioApp.Automacao.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Automacao.App.Aplication.Commands
{
    public class AdicionarDispositivoWebhookCommand : DispositivoWebhookCommand
    {
        public AdicionarDispositivoWebhookCommand
            (string nome, Guid condominioId, string urlLigar, string urlDesligar)
        {
            SetNome(nome);            
            SetCondominioId(condominioId);
            SetUrlLigar(urlLigar);
            SetUrlDesligar(urlDesligar);
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarDispositivoWebhookCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarDispositivoWebhookCommandValidation : DispositivoWebhookValidation<AdicionarDispositivoWebhookCommand>
        {
            public AdicionarDispositivoWebhookCommandValidation()
            {
                ValidateCondominioId();
                ValidateNome();
                ValidateUrlLigar();
                ValidateUrlDesligar();
            }
        }
    }
}
