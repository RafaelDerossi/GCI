using CondominioApp.Core.Data;
using CondominioApp.Principal.Domain.FlatModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.Principal.Domain.Interfaces
{
    public interface ICondominioQueryRepository : IRepository<CondominioFlat>
    {
        void AdicionarGrupo(GrupoFlat entity);

        void AtualizarGrupo(GrupoFlat entity);

        Task<GrupoFlat> ObterGrupoPorId(Guid Id);

        Task<CondominioFlat> ObterPorContratoId(Guid contratoId);

        Task<IEnumerable<GrupoFlat>> ObterGruposPorCondominio(Guid condominioId);       

        void AdicionarUnidade(UnidadeFlat entity);

        void AtualizarUnidade(UnidadeFlat entity);

        Task<UnidadeFlat> ObterUnidadePorId(Guid Id);

        Task<IEnumerable<UnidadeFlat>> ObterUnidadesPorGrupo(Guid grupoId);

        Task<IEnumerable<UnidadeFlat>> ObterUnidadesPorCondominio(Guid condominioId);

       

    }
}