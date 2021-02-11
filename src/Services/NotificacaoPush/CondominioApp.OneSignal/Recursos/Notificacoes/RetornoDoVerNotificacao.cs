using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp.Deserializers;

namespace CondominioApp.OneSignal.Recursos.Notificacoes
{
   public class RetornoDoVerNotificacao : RetornoBase
    {        
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The number of devices that received notification.
        /// </summary>
        [JsonProperty("successful")]
        public int BemSucedida { get; set; }

        /// <summary>
        /// The number of devices that failed to receive notification.
        /// </summary>
        [JsonProperty("failed")]
        public int Falhou { get; set; }

        /// <summary>
        /// The number of users who clicked notification.
        /// </summary>
        [JsonProperty("converted")]
        public int Convertida { get; set; }

        /// <summary>
        /// The number of remaining devices where notification will be delivered
        /// </summary>
        [JsonProperty("remaining")]
        public int Remanescente { get; set; }

        
        [JsonProperty("queued_at")]
        [JsonConverter(typeof(ConversorJasonDeUnixDateTime))]
        public int EnfileiradoEm { get; set; }

        
        [JsonProperty("send_after")]
        [JsonConverter(typeof(ConversorJasonDeUnixDateTime))]
        public int EnviarDepois { get; set; }

        /// <summary><br/>
        /// The URL to open in the browser when a user clicks on the notification.<br/>
        /// <code>Example: http://www.google.com</code><br/>
        /// This field supports<see cref="!:https://documentation.onesignal.com/docs/notification-content#section-notification-content-substitution">inline substitutions</see>.<br/>
        /// Platforms: ALL<br/>
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary><br/>
        /// The notification's content (excluding the title), a map of language codes to text for each language.<br/>
        /// Each hash must have a language code string for a key, mapped to the localized text you would like users to receive for that language.<br/>
        /// English must be included in the hash.<br/>
        /// <code>Example: {"en": "English Message", "es": "Spanish Message"}</code><br/>
        /// See the language codes you can use <see cref="!:https://documentation.onesignal.com/docs/language-localization">here</see>.<br/>
        /// </summary>
        [JsonProperty("contents")]
        [JsonExtensionData]
        public Dictionary<string, string> Conteudo { get; set; }

        /// <summary><br/>
        /// The notification's title, a map of language codes to text for each language.<br/>
        /// Each hash must have a language code string for a key, mapped to the localized text you would like users to receive for that language.<br/>
        /// A default title may be displayed if a title is not provided. <br/>
        /// <code>Example: {"en": "English Title", "es": "Spanish Title"}</code><br/>
        /// See the language codes you can use <see cref="!:https://documentation.onesignal.com/docs/language-localization">here</see>. <br/>
        /// </summary>
        [JsonProperty("headings")]
        [JsonExtensionData]
        public Dictionary<string, string> Titulos { get; set; }

        /// <summary><br/>
        /// A custom map of data that is passed back to your app.<br/>
        /// <code>Example: {"abc": "123", "foo": "bar"}</code><br/>
        /// See the language codes you can use <see cref="!:https://documentation.onesignal.com/docs/language-localization">here</see>. <br/>
        /// </summary>
        [JsonProperty("data")]
        [JsonExtensionData]
        public Dictionary<string, string> Dados { get; set; }

        
        [JsonProperty("canceled")]
        public bool Cancelado { get; set; }
    }
}
