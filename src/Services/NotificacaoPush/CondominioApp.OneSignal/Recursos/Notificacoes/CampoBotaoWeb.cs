using Newtonsoft.Json;

namespace CondominioApp.OneSignal.Recursos.Notificacoes
{
   public class CampoBotaoWeb
    {
        /// <summary>
        /// Web button ID. This is required field.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Web button text.
        /// </summary>
        [JsonProperty("text")]
        public string Texto { get; set; }

        /// <summary>
        /// Web button icon.
        /// </summary>
        [JsonProperty("icon")]
        public string Icone { get; set; }

        /// <summary>
        /// Web button url.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
