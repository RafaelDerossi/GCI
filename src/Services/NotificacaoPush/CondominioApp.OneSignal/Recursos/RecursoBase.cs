using RestSharp;

namespace CondominioApp.OneSignal.Recursos
{
   public abstract class RecursoBase
    {
        protected RestClient RestClient { get; set; }

        protected string ApiKey { get; set; }

        protected RecursoBase(string apiKey, string apiUri)
        {
            ApiKey = apiKey;
            RestClient = new RestClient(apiUri);
        }
    }
}
