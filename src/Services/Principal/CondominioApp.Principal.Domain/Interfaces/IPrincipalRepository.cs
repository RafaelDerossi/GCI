using CondominioApp.Core.Data;
using CondominioApp.Principal.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.Principal.Domain.Interfaces
{
    public interface IPrincipalRepository : IRepository<Condominio>
    {
        Task<bool> CnpjCondominioJaCadastrado(Cnpj cnpj, Guid condominioId);

        Task<bool> CondominioExiste(Guid condominioId);


        #region Grupo
        void AdicionarGrupo(Grupo entity);

        void AtualizarGrupo(Grupo entity);

        void ApagarGrupo(Func<Grupo, bool> predicate);


        Task<Grupo> ObterGrupoPorId(Guid Id);
        #endregion


        #region Unidade
        void AdicionarUnidade(Unidade entity);

        void AtualizarUnidade(Unidade entity);

        void ApagarUnidade(Func<Unidade, bool> predicate);


        Task<Unidade> ObterUnidadePorId(Guid Id);

        Task<bool> CodigoDaUnidadeJaExiste(string codigo, Guid unidadeId);
        #endregion


        #region Contrato
        void AdicionarContrato(Contrato entity);

        void AtualizarContrato(Contrato entity);

        void ApagarContrato(Func<Contrato, bool> predicate);


        Task<Contrato> ObterContratoPorId(Guid Id);

        Task<IEnumerable<Contrato>> ObterContratosPorCondominio(Guid CondominioId);
        #endregion
      
    }
}
