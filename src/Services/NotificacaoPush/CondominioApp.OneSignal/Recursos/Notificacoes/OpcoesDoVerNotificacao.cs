using Newtonsoft.Json;
using System;

namespace CondominioApp.OneSignal.Recursos.Notificacoes
{
   public class OpcoesDoVerNotificacao
    {
        /// <summary><br/>
        /// Your OneSignal application ID, which can be found on our dashboard at onesignal.com under App Settings > Keys &amp; IDs. <br/>
        /// It is a UUID and looks similar to 8250eaf6-1a58-489e-b136-7c74a864b434.<br/>
        /// </summary>
        [JsonProperty("app_id")]
        public Guid AppId { get; set; }


        /// <summary><br/>
        /// Notification ID 
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
