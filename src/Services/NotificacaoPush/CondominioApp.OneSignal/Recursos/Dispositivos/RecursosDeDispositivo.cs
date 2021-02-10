using CondominioApp.OneSignal.Serializador;
using RestSharp;
using System.Threading.Tasks;

namespace CondominioApp.OneSignal.Recursos.Dispositivos
{
  public class RecursosDeDispositivo : RecursoBase, IRecursosDeDispositivo
    {
        public RecursosDeDispositivo(string apiKey, string apiUri) : base(apiKey, apiUri)
        {
        }


        public RetornoDoAdicionarDispositivo Adicionar(OpcoesDoAdicionarDispositvo opcoes)
        {
            var restRequest = new RestRequest("players", Method.POST);

            restRequest.AddHeader("Authorization", string.Format("Basic {0}", base.ApiKey));

            restRequest.RequestFormat = DataFormat.Json;
            restRequest.JsonSerializer = new SerializadorJsonNewtonsoft();
            restRequest.AddJsonBody(opcoes);

            var restResponse =  base.RestClient.Execute<RetornoDoAdicionarDispositivo>(restRequest);

            if (restResponse.ErrorException != null)
            {
                throw restResponse.ErrorException;
            }

            return restResponse.Data;
        }


        public void Editar(string id, OpcoesDoEditarDispositivo opcoes)
        {
            RestRequest restRequest = new RestRequest("players/{id}", Method.PUT);

            restRequest.AddHeader("Authorization", string.Format("Basic {0}", base.ApiKey));

            restRequest.AddUrlSegment("id", id);

            restRequest.RequestFormat = DataFormat.Json;           
            restRequest.AddJsonBody(opcoes);

            IRestResponse restResponse = base.RestClient.Execute(restRequest);

            if (restResponse.ErrorException != null)
            {
                throw restResponse.ErrorException;
            }
        }

    }
}
