using NinjaStore.Core.Data;
using NinjaStore.Produtos.Domain.FlatModel;
using NinjaStore.Produtos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaStore.Produtos.Aplication.Query
{
    public class ProdutoQuery : IProdutoQuery
    {        
        private readonly IMongoRepository<ProdutoFlat> _produtoFlatRepository;

        public ProdutoQuery(IMongoRepository<ProdutoFlat> produtoFlatRepository)
        {
            _produtoFlatRepository = produtoFlatRepository;
        }

        public async Task<ProdutoFlat> ObterPorId(Guid Id)
        {
            return await _produtoFlatRepository.ObterDocumentoAsync(x => x.ProdutoId == Id);
        }

        public async Task<IEnumerable<ProdutoFlat>> ObterTodos()
        {
            return await _produtoFlatRepository.ObterPorAsync(x => !x.Lixeira);
        }

       
        public void Dispose()
        {            
        }

    }
}