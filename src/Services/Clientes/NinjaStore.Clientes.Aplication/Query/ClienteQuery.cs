using NinjaStore.Clientes.Domain.FlatModel;
using NinjaStore.Clientes.Domain.Interfaces;
using NinjaStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaStore.Clientes.Aplication.Query
{
    public class ClienteQuery : IClienteQuery
    {
        private readonly IMongoRepository<ClienteFlat> _clienteFlatRepository;

        public ClienteQuery(IMongoRepository<ClienteFlat> clienteFlatRepository)
        {
            _clienteFlatRepository = clienteFlatRepository;
        }


        public async Task<ClienteFlat> ObterPorId(Guid Id)
        {
            return await _clienteFlatRepository.ObterDocumentoAsync(x => x.ClienteId == Id);
        }

        public async Task<IEnumerable<ClienteFlat>> ObterTodos()
        {
            return await Task.Run(() =>
                _clienteFlatRepository.AsQueryable());
        }     
    }
}