using CondominioApp.Automacao.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Automacao.App.Aplication.Commands
{
    public class AtualizarDispositivoWebhookCommand : DispositivoWebhookCommand
    {
        public AtualizarDispositivoWebhookCommand
            (Guid id, string nome, string urlLigar, string urlDesligar,
             bool pulseLigado, string tempoDoPulse)
        {
            PulseLigado = pulseLigado;
            TempoDoPulse = tempoDoPulse;
            Id = id;
            SetNome(nome);          
            SetUrlLigarDesligar(urlLigar, urlDesligar);            
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtualizarDispositivoWebhookCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtualizarDispositivoWebhookCommandValidation : DispositivoWebhookValidation<AtualizarDispositivoWebhookCommand>
        {
            public AtualizarDispositivoWebhookCommandValidation()
            {
                ValidateId();
                ValidateNome();
                ValidateUrlLigar();                
            }
        }
    }
}
