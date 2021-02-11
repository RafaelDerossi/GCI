using Newtonsoft.Json;

namespace CondominioApp.OneSignal.Recursos.Notificacoes
{
   public class CampoBotaoDeAcao
    {
        /// <summary>
        /// Action button ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Action button text.
        /// </summary>
        [JsonProperty("text")]
        public string Texto { get; set; }

        /// <summary>
        /// Action button icon.
        /// </summary>
        [JsonProperty("icon")]
        public string Icone { get; set; }
    }
}
