using GCI.Core.Helpers;
using Microsoft.Extensions.Options;
using GCI.Core.Messages;
using GCI.Acoes.Domain;
using GCI.WebApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using GCI.Acoes.Domain.YhFinance;

namespace GCI.Acoes.Aplication.Query
{
    public class CotacaoDeAcaoQuery : HttpService, ICotacaoDeAcaoQuery
    {
        public CotacaoDeAcaoQuery(IOptions<AppSettings> options)
        {
            ConfigurarBaseUrl(options.Value.UrlYahooFinanceApi);
        }


        public async Task<Cotacao> ObterPorCodigo(string codigo)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_httpClient.BaseAddress}/get-quotes?region=US&symbols={codigo}"),
                Headers =
                {
                  { "x-rapidapi-host", "yh-finance.p.rapidapi.com" },
                  { "x-rapidapi-key", ""},
                },
            };
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();                
                return await DeserializarObjetoResponse<Cotacao>(response);
            }           
        }      

       
        public void Dispose()
        {
        }

    }
}