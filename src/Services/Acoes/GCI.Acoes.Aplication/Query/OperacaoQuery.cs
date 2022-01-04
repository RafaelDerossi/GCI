using GCI.Acoes.Domain.FlatModel;
using GCI.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GCI.Acoes.Aplication.Query
{
    public class OperacaoQuery : IOperacaoQuery
    {        
        private readonly IMongoRepository<OperacaoFlat> _operacaoFlatRepository;

        public OperacaoQuery
            (IMongoRepository<OperacaoFlat> operacaoFlatRepository)
        {            
            _operacaoFlatRepository = operacaoFlatRepository;
        }
       
        public async Task<IEnumerable<OperacaoFlat>> ObterPorCodigo(string codigo)
        {
            return await _operacaoFlatRepository.ObterPorAsync(x => x.CodigoDaAcao == codigo && !x.Lixeira);
        }

        public async Task<IEnumerable<OperacaoFlat>> ObterTodas()
        {
            return await Task.Run(() =>
                _operacaoFlatRepository.AsQueryable());
        }
    }
}