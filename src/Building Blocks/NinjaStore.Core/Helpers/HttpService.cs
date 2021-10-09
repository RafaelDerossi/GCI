using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NinjaStore.Core.Helpers
{
    public abstract class HttpService
    {
        protected readonly HttpClient _httpClient;

        public HttpService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void ConfigurarBaseUrl(string urlBaseService)
        {
            _httpClient.BaseAddress = new Uri(urlBaseService);
        }

        protected StringContent ObterConteudo(object dado)
        {
            return new StringContent(
                JsonConvert.SerializeObject(dado),
                Encoding.UTF8,
                "application/json");
        }

        protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
        {
            return JsonConvert.DeserializeObject<T>(await responseMessage.Content.ReadAsStringAsync());
        }
    }
}