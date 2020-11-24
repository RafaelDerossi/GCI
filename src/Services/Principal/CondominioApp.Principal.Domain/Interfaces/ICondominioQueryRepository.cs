using CondominioApp.Core.Data;
using CondominioApp.Principal.Domain.FlatModel;
using System;
using System.Threading.Tasks;

namespace CondominioApp.Principal.Domain.Interfaces
{
    public interface ICondominioQueryRepository : IRepository<CondominioFlat>
    {
        void AdicionarGrupo(GrupoFlat entity);

        void AtualizarGrupo(GrupoFlat entity);

        Task<GrupoFlat> ObterGrupoPorId(Guid Id);

        Task<GrupoFlat> ObterGruposPorCondominio(Guid condominioId);


        void AdicionarUnidade(UnidadeFlat entity);

        void AtualizarUnidade(UnidadeFlat entity);

        Task<UnidadeFlat> ObterUnidadePorId(Guid Id);

        Task<UnidadeFlat> ObterUnidadesPorGrupo(Guid grupoId);

        Task<UnidadeFlat> ObterUnidadesPorCondominio(Guid condominioId);
    }
}