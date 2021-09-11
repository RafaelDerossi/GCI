using CondominioApp.NotificacaoPush.App.OneSignalApps;
using CondominioApp.OneSignal.Recursos;
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

        public NotificacaoPushDTO(IOneSignalApp appOneSignal, IList<string> dispositivosIds)
        {
            Conteudo = new Dictionary<string, string>();
            Titulos = new Dictionary<string, string>();
            AppOneSignal = appOneSignal;
            DispositivosIds = dispositivosIds;
        }

        public void AdicionarMensagem(string lingua, string titulo, string conteudo)
        {
            Titulos.Add(lingua, titulo);
            Conteudo.Add(lingua, conteudo);
        }
    }
}
