using CondominioApp.OneSignal.Recursos.Notificacoes.Enuns;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CondominioApp.OneSignal.Recursos.Notificacoes
{
   public class CampoFiltroDeNotificacao : IFiltroDeNotificacao
    {
        [JsonProperty("field")]
        [JsonConverter(typeof(ConversorDeCampoDeFiltroDeTipoDeNotificacao))]
        public CampoTipoDeFiltroDeNotificacao Field { get; set; }

        /// <summary>
        /// The key used for comparison.
        /// </summary>
		[JsonProperty("key")]
        public string Chave { get; set; }

        /// <summary>
        /// The relation between key and value.
        /// </summary>
		[JsonProperty("relation")]
        public string Relacao { get; set; }

        /// <summary>
        /// The value.
        /// </summary>
		[JsonProperty("value")]
        public string Valor { get; set; }
    }
}
