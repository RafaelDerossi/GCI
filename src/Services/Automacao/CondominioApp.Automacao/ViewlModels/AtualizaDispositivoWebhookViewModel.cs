using System;

namespace CondominioApp.Automacao.ViewModel
{
   public class AtualizaDispositivoWebhookViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }        
        public string UrlLigar { get; set; }
        public string UrlDesligar { get; set; }        
    }
}
