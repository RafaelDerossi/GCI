using Newtonsoft.Json;
using RestSharp.Deserializers;

namespace CondominioApp.OneSignal.Recursos.Notificacoes
{
   public class RetornoDoCancelarNotificacao : RetornoBase
    {
        [DeserializeAs(Name = "success")]
        public string Success { get; set; }
    }
}
