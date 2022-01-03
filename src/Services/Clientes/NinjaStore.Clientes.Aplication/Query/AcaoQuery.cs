using GCI.Acoes.Domain.FlatModel;
using GCI.Acoes.Domain.Interfaces;
using GCI.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCI.Acoes.Aplication.Query
{
    public class AcaoQuery : IAcaoQuery
    {
        private readonly IMongoRepository<AcaoFlat> _acaoFlatRepository;

        public AcaoQuery(IMongoRepository<AcaoFlat> acaoFlatRepository)
        {
            _acaoFlatRepository = acaoFlatRepository;
        }


        public async Task<AcaoFlat> ObterPorId(Guid Id)
        {
            return await _acaoFlatRepository.ObterDocumentoAsync(x => x.AcaoId == Id);
        }

        public async Task<AcaoFlat> ObterPorCodigo(string codigo)
        {
            return await _acaoFlatRepository.ObterDocumentoAsync(x => x.Codigo == codigo && !x.Lixeira);
        }

        public async Task<IEnumerable<AcaoFlat>> ObterTodos()
        {
            return await Task.Run(() =>
                _acaoFlatRepository.AsQueryable());
        }     
    }
}