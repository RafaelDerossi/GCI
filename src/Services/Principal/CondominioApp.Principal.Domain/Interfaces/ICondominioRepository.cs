using CondominioApp.Core.Data;
using CondominioApp.Core.ValueObjects;
using System;
using System.Threading.Tasks;

namespace CondominioApp.Principal.Domain.Interfaces
{
    public interface ICondominioRepository : IRepository<Condominio>
    {
        void AdicionarGrupo(Grupo entity);

        void AdicionarUnidade(Unidade entity);

        Task<bool> CondominioJaExiste(Cnpj cnpj);

        Task<bool> GrupoJaExiste(string descricao, Guid condominioId);

        Task<bool> UnidadeJaExiste(string codigo, string numero, string andar, Guid grupoId, Guid condominioId);

        Task<Grupo> ObterGrupoPorId(Guid Id);

        Task<Unidade> ObterUnidadePorId(Guid Id);
        
    }
}
