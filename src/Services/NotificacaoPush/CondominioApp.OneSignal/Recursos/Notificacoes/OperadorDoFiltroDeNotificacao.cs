using Newtonsoft.Json;

namespace CondominioApp.OneSignal.Recursos.Notificacoes
{
   public class OperadorDoFiltroDeNotificacao : IFiltroDeNotificacao
    {
        /// <summary>
        /// Can be AND or OR operator
        /// </summary>
        [JsonProperty("operator")]
        public string Operador { get; set; }
    }
}
