using Microsoft.Extensions.Options;
using NinjaStore.Core.Helpers;
using NinjaStore.Core.Messages;
using NinjaStore.Pedidos.Domain;
using NinjaStore.WebApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaStore.Pedidos.Aplication.Query
{
    public class ClienteQuery : HttpService, IClienteQuery
    {
        public ClienteQuery(IOptions<AppSettings> options)
        {
            ConfigurarBaseUrl(options.Value.UrlNinjaStoreClienteApi);
        }


        public async Task<Cliente> ObterPorId(Guid Id)
        {
            var result = await _httpClient.GetAsync($"/api/cliente/por-id/{Id}");

            return await DeserializarObjetoResponse<Cliente>(result);
        }

        public async Task<IEnumerable<Cliente>> ObterTodos()
        {
            var result = await _httpClient.GetAsync($"/api/cliente");

            return await DeserializarObjetoResponse<IEnumerable<Cliente>>(result);
        }

       
        public void Dispose()
        {
        }

    }
}