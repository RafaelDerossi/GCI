using CondominioApp.Core.Data;
using CondominioApp.Principal.Domain.ValueObjects;
using System;
using System.Threading.Tasks;

namespace CondominioApp.Principal.Domain.Interfaces
{
    public interface ICondominioRepository : IRepository<Condominio>
    {
        void AdicionarGrupo(Grupo entity);

        void AdicionarUnidade(Unidade entity);

        Task<bool> CnpjCondominioJaCadastrado(Cnpj cnpj, Guid condominioId);

        Task<Grupo> ObterGrupoPorId(Guid Id);

        Task<Unidade> ObterUnidadePorId(Guid Id);

        Task<bool> CodigoDaUnidadeJaExiste(string codigo, Guid unidadeId);

        Task<bool> CondominioExiste(Guid condominioId);
    }
}
