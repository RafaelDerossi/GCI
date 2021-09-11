﻿using CondominioApp.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CondominioApp.Usuarios.App.Models
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        #region Usuario
        void Remover(Usuario entity);
        #endregion


        #region Morador
        Task<Morador> ObterMoradorPorId(Guid Id);
        Task<Morador> ObterMoradorPorUsuarioIdEUnidadeId(Guid usuarioId, Guid unidadeId);
        Task<IEnumerable<Morador>> ObterMoradoresPorUsuarioId(Guid usuarioId);
        Task<IEnumerable<Morador>> ObterMoradores(Expression<Func<Morador, bool>> expression, bool OrderByDesc = false, int take = 0);
        Task<int> ContaMoradorePorUsuarioIdEUnidadeId(Guid usuarioid, Guid unidadeId);

        void AdicionarMorador(Morador morador);
        void AtualizarMorador(Morador entity);
        void ApagarMorador(Func<Morador, bool> predicate);
        void RemoverMorador(Morador entity);
        #endregion


        #region Funcionario
        Task<Funcionario> ObterFuncionarioPorId(Guid id);
        Task<Funcionario> ObterFuncionarioPorUsuarioIdECondominioId(Guid usuarioId, Guid condominioId);
        Task<IEnumerable<Funcionario>> ObterFuncionariosPorUsuarioId(Guid usuarioId);
        Task<IEnumerable<Funcionario>> ObterFuncionario(Expression<Func<Funcionario, bool>> expression, bool OrderByDesc = false, int take = 0);
        void AdicionarFuncionario(Funcionario funcionario);
        void AtualizarFuncionario(Funcionario entity);
        void ApagarFuncionario(Func<Funcionario, bool> predicate);
        void RemoverFuncionario(Funcionario entity);
        #endregion


        #region Mobile

        Task<Mobile> ObterMobilePorId(Guid id);

        Task<IEnumerable<Mobile>> ObterMobile(Expression<Func<Mobile, bool>> expression, bool OrderByDesc = false, int take = 0);

        Task<IEnumerable<Mobile>> ObterTodosOsMobiles();

        Task<IEnumerable<Mobile>> ObterMobilePorMoradorIdFuncionarioId(Guid id);

        void AdicionarMobile(Mobile mobile);

        void AtualizarMobile(Mobile mobile);

        #endregion


        #region Veiculo
        Task<Veiculo> ObterVeiculoPorId(Guid Id);

        Task<IEnumerable<Veiculo>> ObterVeiculo(Expression<Func<Veiculo, bool>> expression, bool OrderByDesc = false, int take = 0);

        Task<Veiculo> ObterVeiculoPorPlaca(string placa);

        Task<VeiculoCondominio> ObterVeiculoCondominioPorId(Guid veiculoCondominioId);


        void AdicionarVeiculo(Veiculo veiculo);

        void AtualizarVeiculo(Veiculo entity);

        void AtualizarVeiculoCondominio(VeiculoCondominio entity);

        void AdicionarVeiculoCondominio(VeiculoCondominio veiculo);

        void ApagarVeiculo(Func<Veiculo, bool> predicate);

        void RemoverVeiculoCondominio(VeiculoCondominio unidade);

        #endregion

    }
}