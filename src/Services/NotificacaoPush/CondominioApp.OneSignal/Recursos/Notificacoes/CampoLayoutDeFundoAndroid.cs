using Newtonsoft.Json;

namespace CondominioApp.OneSignal.Recursos.Notificacoes
{
   public class CampoLayoutDeFundoAndroid
    {
        /// <summary>
        /// Background image.
        /// </summary>
        [JsonProperty("image")]
        public string Imagem { get; set; }

        /// <summary>
        /// Background heading color.
        /// </summary>
        [JsonProperty("headings_color")]
        public string CorDosTitulos { get; set; }

        /// <summary>
        /// Background content color.
        /// </summary>
        [JsonProperty("contents_color")]
        public string CorDoConteudo { get; set; }
    }
}
