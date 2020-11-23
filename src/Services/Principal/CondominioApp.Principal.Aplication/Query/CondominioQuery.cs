using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.Principal.Domain.Interfaces;

namespace CondominioApp.Principal.Aplication.Query
{
    public class CondominioQuery : ICondominioQuery
    {
        private ICondominioQueryRepository _condominioQueryRepository;

        public CondominioQuery(ICondominioQueryRepository condominioQueryRepository)
        {
            _condominioQueryRepository = condominioQueryRepository;
        }

        public async Task<CondominioFlat> ObterPorId(Guid Id)
        {
            return await _condominioQueryRepository.ObterPorId(Id);
        }

        public async Task<IEnumerable<CondominioFlat>> ObterTodos()
        {
            return await _condominioQueryRepository.ObterTodos();
        }

        public async Task<IEnumerable<CondominioFlat>> ObterRemovidos()
        {
            return await _condominioQueryRepository.Obter(c => c.Lixeira);
        }

        public void Dispose()
        {
            _condominioQueryRepository?.Dispose();
        }
    }
}