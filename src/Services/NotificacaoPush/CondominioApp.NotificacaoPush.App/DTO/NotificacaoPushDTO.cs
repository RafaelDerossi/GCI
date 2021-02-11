using CondominioApp.NotificacaoPush.App.OneSignalApps;
using System.Collections.Generic;

namespace CondominioApp.NotificacaoPush.App.DTO
{
   public class NotificacaoPushDTO
    {
        public IOneSignalApp AppOneSignal { get; set; }
        public IList<string> DispositivosIds { get; set; }
        public IDictionary<string, string> Titulos { get; set; }
        public IDictionary<string, string> Conteudo { get; set; }

        public NotificacaoPushDTO()
        {
            Conteudo = new Dictionary<string, string>();
            Titulos = new Dictionary<string, string>();
        }
    }
}
