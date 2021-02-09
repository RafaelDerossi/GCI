using RestSharp.Deserializers;

namespace CondominioApp.OneSignal.Recursos.Dispositivos
{
   public class RetornoDoAdicionarDispositivo
    {
        /// <summary>
        /// Returns true if operation is successfull.
        /// </summary>
        [DeserializeAs(Name = "success")]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Returns id of the result operation.
        /// </summary>
        [DeserializeAs(Name = "id")]
        public string Id { get; set; }
    }
}
