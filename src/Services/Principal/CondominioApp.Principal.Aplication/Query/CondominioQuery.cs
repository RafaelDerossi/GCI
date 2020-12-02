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


        #region Condominio
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
        #endregion


        #region Grupo
        public async Task<GrupoFlat> ObterGrupoPorId(Guid Id)
        {
            return await _condominioQueryRepository.ObterGrupoPorId(Id);
        }

        public async Task<IEnumerable<GrupoFlat>> ObterGruposPorCondominio(Guid condominioId)
        {
            return await _condominioQueryRepository.ObterGruposPorCondominio(condominioId);
        }
        #endregion


        #region Unidade
        public async Task<UnidadeFlat> ObterUnidadePorId(Guid Id)
        {
            return await _condominioQueryRepository.ObterUnidadePorId(Id);
        }

        public async Task<IEnumerable<UnidadeFlat>> ObterUnidadesPorGrupo(Guid grupoId)
        {
            return await _condominioQueryRepository.ObterUnidadesPorGrupo(grupoId);
        }

        public async Task<IEnumerable<UnidadeFlat>> ObterUnidadesPorCondominio(Guid condominioId)
        {
            return await _condominioQueryRepository.ObterUnidadesPorCondominio(condominioId);
        }

        #endregion


        public void Dispose()
        {
            _condominioQueryRepository?.Dispose();
        }
    }
}