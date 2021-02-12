
using CondominioApp.OneSignal.Recursos.Dispositivos;
using CondominioApp.OneSignal.Recursos.Notificacoes;

namespace CondominioApp.OneSignal
{
   public class OneSignalClient :IOneSignalClient
    {
        public IRecursosDeDispositivo Devices { get; private set; }

        public IRecursosDeNotificacao Notifications { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="apiKey">Your OneSignal API key</param>
        /// <param name="apiUri">API uri (default is "https://onesignal.com/api/v1")</param>
        public OneSignalClient(string apiKey, string apiUri = "https://onesignal.com/api/v1")
        {
            this.Devices = new RecursosDeDispositivo(apiKey, apiUri);
            this.Notifications = new RecursosDeNotificacao(apiKey, apiUri);
        }
    }
}
