using RestSharp;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Automacao.Webhook
{
    public static class RestWebhook
    {
        public static async Task<string> Acao(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);                        
            request.RequestFormat = DataFormat.Json;

            var cancellationTokenSource = new CancellationTokenSource();
            var response = await client.ExecuteAsync(request, cancellationTokenSource.Token);
            return response.Content;
        }       
    }
}
