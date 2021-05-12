using CondominioApp.Core.Data;
using CondominioApp.Principal.Domain.FlatModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.Principal.Domain.Interfaces
{
    public interface IPrincipalQueryRepository : IRepository<CondominioFlat>
    {
        Task<CondominioFlat> ObterPorContratoId(Guid contratoId);

        #region Grupo
        void AdicionarGrupo(GrupoFlat entity);

        void AtualizarGrupo(GrupoFlat entity);

        void ApagarGrupo(Func<GrupoFlat, bool> predicate);



        Task<GrupoFlat> ObterGrupoPorId(Guid Id);

        Task<IEnumerable<GrupoFlat>> ObterGruposPorCondominio(Guid condominioId);
        #endregion


        #region Unidade
        void AdicionarUnidade(UnidadeFlat entity);

        void AtualizarUnidade(UnidadeFlat entity);

        void ApagarUnidade(Func<UnidadeFlat, bool> predicate);


        Task<UnidadeFlat> ObterUnidadePorId(Guid Id);

        Task<UnidadeFlat> ObterUnidadePorCodigo(string codigo);

        Task<IEnumerable<UnidadeFlat>> ObterUnidadesPorGrupo(Guid grupoId);

        Task<IEnumerable<UnidadeFlat>> ObterUnidadesPorCondominio(Guid condominioId);
        #endregion
    }
}