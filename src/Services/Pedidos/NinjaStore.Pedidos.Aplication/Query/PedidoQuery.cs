using NinjaStore.Core.Data;
using NinjaStore.Pedidos.Domain.FlatModel;
using NinjaStore.Pedidos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaStore.Pedidos.Aplication.Query
{
    public class PedidoQuery : IPedidoQuery
    {
        private readonly IMongoRepository<PedidoFlat> _pedidoFlatRepository;

        public PedidoQuery(IMongoRepository<PedidoFlat> pedidoFlatRepository)
        {
            _pedidoFlatRepository = pedidoFlatRepository;
        }

        public async Task<PedidoFlat> ObterPorId(Guid Id)
        {
            return await _pedidoFlatRepository.ObterDocumentoAsync(x => x.PedidoId == Id);
        }

        public async Task<IEnumerable<PedidoFlat>> ObterTodos()
        {
            return await _pedidoFlatRepository.ObterPorAsync(x => !x.Lixeira);
        }

       
        public void Dispose()
        {
        }

    }
}