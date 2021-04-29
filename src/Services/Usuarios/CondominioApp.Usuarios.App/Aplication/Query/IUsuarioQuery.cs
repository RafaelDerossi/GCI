﻿using CondominioApp.Usuarios.App.FlatModel;
using CondominioApp.Usuarios.App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CondominioApp.Usuarios.App.Aplication.Query
{
    public interface IUsuarioQuery : IDisposable
    {
        #region Usuario
        Task<Usuario> ObterPorId(Guid Id);
        #endregion

        #region Morador
        Task<MoradorFlat> ObterMoradorPorId(Guid id);
        Task<IEnumerable<MoradorFlat>> ObterMoradoresPorUsuarioId(Guid usuarioId);
        Task<IEnumerable<MoradorFlat>> ObterMoradoresPorCondominioId(Guid condominioId);
        Task<IEnumerable<MoradorFlat>> ObterMoradoresPorUnidadeId(Guid unidadeId);
        Task<IEnumerable<MoradorFlat>> ObterProprietariosPorCondominioId(Guid condominioId);
        Task<IEnumerable<MoradorFlat>> ObterProprietariosPorUnidadeId(Guid unidadeId);
        #endregion

        #region Funcionario

        Task<FuncionarioFlat> ObterFuncionarioPorId(Guid id);
        Task<IEnumerable<FuncionarioFlat>> ObterFuncionariosPorUsuarioId(Guid usuarioId);
        Task<IEnumerable<FuncionarioFlat>> ObterFuncionariosPorCondominioId(Guid condominioId);
        Task<Funcionario> ObterSindicoPorCondominioId(Guid condominioId);

        #endregion

        #region Veiculo
        Task<VeiculoFlat> ObterVeiculoPorId(Guid id);

        Task<VeiculoFlat> ObterVeiculoPorPlacaECondominio(string placa, Guid condominioId);

        Task<IEnumerable<VeiculoFlat>> ObterVeiculosPorCondominio(Guid condominioId);        

        Task<IEnumerable<VeiculoFlat>> ObterVeiculosPorUsuario(Guid usuarioId);

        Task<VeiculoFlat> ObterVeiculoPorPlacaOuModeloECondominio(string pesquisa, Guid condominioId);

        Task<IEnumerable<VeiculoFlat>> ObterVeiculosPorUnidade(Guid UnidadaId);
        #endregion

        #region Mobile
        Task<IEnumerable<Mobile>> ObterMobilesPorMoradorFuncionarioId(Guid usuarioId);

        Task<IEnumerable<Mobile>> ObterTodosOsMobiles();

        #endregion

    }
}