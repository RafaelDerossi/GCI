using CondominioApp.Core.Data;
using CondominioApp.Principal.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.Principal.Domain.Interfaces
{
    public interface IPrincipalRepository : IRepository<Condominio>
    {
        void AdicionarGrupo(Grupo entity);

        void AtualizarGrupo(Grupo entity);


        void AdicionarUnidade(Unidade entity);

        void AtualizarUnidade(Unidade entity);


        void AdicionarContrato(Contrato entity);

        void AtualizarContrato(Contrato entity);



        Task<bool> CnpjCondominioJaCadastrado(Cnpj cnpj, Guid condominioId);

        Task<Grupo> ObterGrupoPorId(Guid Id);

        Task<Unidade> ObterUnidadePorId(Guid Id);

        Task<Contrato> ObterContratoPorId(Guid Id);

        Task<IEnumerable<Contrato>> ObterContratosPorCondominio(Guid CondominioId);

        Task<bool> CodigoDaUnidadeJaExiste(string codigo, Guid unidadeId);

        Task<bool> CondominioExiste(Guid condominioId);
    }
}
