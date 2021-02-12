using CondominioApp.OneSignal.Recursos.Dispositivos.Enuns;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CondominioApp.OneSignal.Recursos.Dispositivos
{
   public class OpcoesDoEditarDispositivo
    {
        [JsonProperty("app_id")]
        public Guid AppId { get; set; }

        [JsonProperty("device_type")]
        public TipoDeDispositivo? TipoDoDispositivo { get; set; }

        [JsonProperty("identifier")]
        public string Identifier { get; set; }
        
        [JsonProperty("language")]
        public string Lingua { get; set; }

        
        [JsonProperty("timezone")]
        public int? Timezone { get; set; }

        
        [JsonProperty("game_version")]
        public string VersaoDoApp { get; set; }

        
        [JsonProperty("device_model")]
        public string ModeloDoDispositivo { get; set; }
        
        [JsonProperty("device_os")]
        public string OSDoDispositivo { get; set; }
       
        [JsonProperty("ad_id")]
        public string AdId { get; set; }
        
        [JsonProperty("sdk")]
        public string SDK { get; set; }
        
        [JsonProperty("session_count")]
        public string ContadorDeSessoes { get; set; }
        
        [JsonProperty("tags")]
        public IDictionary<string, object> Tags { get; set; }
       
        [JsonProperty("amount_spent")]
        public string ValorGasto { get; set; }
        
        [JsonProperty("created_at")]
        public int? DataDeCriacao { get; set; }

        /// <summary>
        /// Unixtime when the player was last active
        /// </summary>
        [JsonProperty("last_active")]
        public int? UltimaUtilizacao { get; set; }

        /// <summary>
        /// This is used in deciding whether to use your iOS Sandbox or Production push certificate when sending a push when both have been uploaded. 
        /// Set to the iOS provisioning profile that was used to build your app. 
        /// 1 = Development
        /// 2 = Ad-Hoc. 
        /// Omit this field for App Store builds.
        /// </summary>
        [JsonProperty("test_type")]
        public TipoDeTeste? TipoDeTeste { get; set; }

        /// <summary>
        /// Longitude of the device, used for geotagging to segment on.
        /// </summary>
        [JsonProperty("long")]
        public double? Longitude { get; set; }

        /// <summary>
        /// Latitude of the device, used for geotagging to segment on.
        /// </summary>
        [JsonProperty("lat")]
        public double? Latitude { get; set; }
    }
}
