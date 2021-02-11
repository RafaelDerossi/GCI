using RestSharp.Deserializers;


namespace CondominioApp.OneSignal.Recursos.Notificacoes
{
   public class RetornoDoCriarNotificacao : RetornoBase
    {        
        [DeserializeAs(Name = "recipients")]
        public int Destinatarios { get; set; }

        
        [DeserializeAs(Name = "id")]
        public string Id { get; set; }

    }
}
