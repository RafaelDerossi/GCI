using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CondominioApp.Principal.Domain.FlatModel;

namespace CondominioApp.Principal.Aplication.Query.Interfaces
{
    public interface ICondominioQuery : IDisposable
    {
        Task<CondominioFlat> ObterPorId(Guid Id);

        Task<IEnumerable<CondominioFlat>> ObterTodos();

        Task<IEnumerable<CondominioFlat>> ObterRemovidos();



        Task<GrupoFlat> ObterGrupoPorId(Guid Id);

        Task<IEnumerable<GrupoFlat>> ObterGruposPorCondominio(Guid condominioId);


        Task<UnidadeFlat> ObterUnidadePorId(Guid Id);

        Task<IEnumerable<UnidadeFlat>> ObterUnidadesPorGrupo(Guid grupoId);

        Task<IEnumerable<UnidadeFlat>> ObterUnidadesPorCondominio(Guid condominioId);
    }
}