using System;
using System.Net;
using CondominioApp.OneSignal.Serializador;
using RestSharp;

namespace CondominioApp.OneSignal.Recursos.Notificacoes
{
   public class RecursosDeNotificacao : RecursoBase, IRecursosDeNotificacao
    {
        public RecursosDeNotificacao(string apiKey, string apiUri) : base(apiKey, apiUri)
        {
        }


        public RetornoDoCriarNotificacao Criar(OpcoesDoCriarNotificacao options)
        {
            RestRequest restRequest = new RestRequest("notifications", Method.POST);

            restRequest.AddHeader("Authorization", string.Format("Basic {0}", base.ApiKey));

            restRequest.RequestFormat = DataFormat.Json;
            restRequest.JsonSerializer = new SerializadorJsonNewtonsoft();
            restRequest.AddJsonBody(options);

            IRestResponse<RetornoDoCriarNotificacao> restResponse = base.RestClient.Execute<RetornoDoCriarNotificacao>(restRequest);

            if (!(restResponse.StatusCode != HttpStatusCode.Created || restResponse.StatusCode != HttpStatusCode.OK))
            {
                if (restResponse.ErrorException != null)
                {
                    throw restResponse.ErrorException;
                }
                else if (restResponse.StatusCode != HttpStatusCode.OK && restResponse.Content != null)
                {
                    throw new Exception(restResponse.Content);
                }
            }

            return restResponse.Data;
        }

        
        public RetornoDoVerNotificacao Ver(OpcoesDoVerNotificacao options)
        {
            var baseRequestPath = "notifications/{0}?app_id={1}";

            RestRequest restRequest = new RestRequest(string.Format(baseRequestPath, options.Id, options.AppId), Method.GET);

            restRequest.AddHeader("Authorization", string.Format("Basic {0}", base.ApiKey));

            restRequest.RequestFormat = DataFormat.Json;            

            var restResponse = base.RestClient.Execute<RetornoDoVerNotificacao>(restRequest);

            if (!(restResponse.StatusCode != HttpStatusCode.Created || restResponse.StatusCode != HttpStatusCode.OK))
            {
                if (restResponse.ErrorException != null)
                {
                    throw restResponse.ErrorException;
                }
                else if (restResponse.StatusCode != HttpStatusCode.OK && restResponse.Content != null)
                {
                    throw new Exception(restResponse.Content);
                }
            }

            return restResponse.Data;
        }

      
        public RetornoDoCancelarNotificacao Cancelar(OpcoesDoCancelarNotificacao options)
        {
            RestRequest restRequest = new RestRequest("notifications/" + options.Id, Method.DELETE);

            restRequest.AddHeader("Authorization", string.Format("Basic {0}", base.ApiKey));

            restRequest.AddParameter("app_id", options.AppId);

            restRequest.RequestFormat = DataFormat.Json;

            IRestResponse<RetornoDoCancelarNotificacao> restResponse = base.RestClient.Execute<RetornoDoCancelarNotificacao>(restRequest);

            if (restResponse.ErrorException != null)
            {
                throw restResponse.ErrorException;
            }
            else if (restResponse.StatusCode != HttpStatusCode.OK && restResponse.Content != null)
            {
                throw new Exception(restResponse.Content);
            }

            return restResponse.Data;
        }

    }
}
