using Newtonsoft.Json;

namespace CondominioApp.OneSignal.Recursos.Notificacoes
{  
    public class OpcoesDoCancelarNotificacao
    {
        /// <summary>
        /// id  String  Required Notification id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// app_id  String  Required App id
        /// </summary>
        [JsonProperty("app_id")]
        public string AppId { get; set; }
    }
}
