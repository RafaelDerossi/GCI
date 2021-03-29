using CondominioApp.Usuarios.App.FlatModel;
using CondominioApp.Usuarios.App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CondominioApp.Core.Enumeradores;

namespace CondominioApp.Usuarios.App.Aplication.Query
{
    public class UsuarioQuery : IUsuarioQuery
    {
        private IUsuarioRepository _usuarioRepository;
        private IVeiculoQueryRepository _veiculoQueryRepository;
        private IMoradorQueryRepository _moradorQueryRepository;
        private IFuncionarioQueryRepository _funcionarioQueryRepository;

        public UsuarioQuery(IUsuarioRepository usuarioRepository, IVeiculoQueryRepository veiculoQueryRepository,
            IMoradorQueryRepository moradorQueryRepository, IFuncionarioQueryRepository funcionarioQueryRepository)
        {
            _usuarioRepository = usuarioRepository;
            _veiculoQueryRepository = veiculoQueryRepository;
            _moradorQueryRepository = moradorQueryRepository;
            _funcionarioQueryRepository = funcionarioQueryRepository;
        }


        #region Usuario    
        public async Task<Usuario> ObterPorId(Guid Id)
        {
           return await _usuarioRepository.ObterPorId(Id);
        }
        #endregion


        #region Morador
        public async Task<MoradorFlat> ObterMoradorPorId(Guid id)
        {
            return await _moradorQueryRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<MoradorFlat>> ObterMoradoresPorUsuarioId(Guid usuarioId)
        {
            var moradores = await _moradorQueryRepository.Obter(m => m.UsuarioId == usuarioId && !m.Lixeira);
            return moradores.ToList();
        }

        public async Task<IEnumerable<MoradorFlat>> ObterMoradoresPorCondominioId(Guid condominioId)
        {
            var retorno = await _moradorQueryRepository.Obter(m => m.CondominioId == condominioId && !m.Lixeira);
            return retorno.ToList();
        }

        public async Task<IEnumerable<MoradorFlat>> ObterMoradoresPorUnidadeId(Guid unidadeId)
        {
            var retorno = await _moradorQueryRepository.Obter(m => m.UnidadeId == unidadeId && !m.Lixeira);
            return retorno.ToList();
        }

        public async Task<IEnumerable<MoradorFlat>> ObterProprietariosPorCondominioId(Guid condominioId)
        {
            var retorno = await _moradorQueryRepository.Obter
                (m => m.CondominioId == condominioId &&
                 m.Proprietario &&
                !m.Lixeira);
            return retorno.ToList();
        }

        public async Task<IEnumerable<MoradorFlat>> ObterProprietariosPorUnidadeId(Guid unidadeId)
        {
            var retorno = await _moradorQueryRepository.Obter
                (m => m.UnidadeId == unidadeId &&
                 m.Proprietario && 
                 !m.Lixeira);

            return retorno.ToList();
        }

        #endregion


        #region Funcionario

        public async Task<FuncionarioFlat> ObterFuncionarioPorId(Guid id)
        {
            return await _funcionarioQueryRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<FuncionarioFlat>> ObterFuncionariosPorUsuarioId(Guid usuarioId)
        {
            var funcionarios = await _funcionarioQueryRepository.Obter(m => m.UsuarioId == usuarioId && !m.Lixeira);
            return funcionarios.ToList();
        }

        public async Task<IEnumerable<FuncionarioFlat>> ObterFuncionariosPorCondominioId(Guid condominioId)
        {
            var retorno = await _funcionarioQueryRepository.Obter(m => m.CondominioId == condominioId && !m.Lixeira);
            return retorno.ToList();
        }

        public async Task<Funcionario> ObterSindicoPorCondominioId(Guid condominioId)
        {
            var retorno = await _usuarioRepository.ObterFuncionario(m => m.CondominioId == condominioId && m.Permissao == Permissao.ADMIN && !m.Lixeira);
            return retorno.FirstOrDefault();
        }

        #endregion


        #region Veiculo       

        public async Task<VeiculoFlat> ObterVeiculoPorId(Guid id)
        {
            return await _veiculoQueryRepository.ObterPorId(id);
        }

        public async Task<VeiculoFlat> ObterVeiculoPorPlacaECondominio(string placa, Guid condominioId)
        {
            var retorno = await _veiculoQueryRepository.Obter(v => v.Placa == placa && v.CondominioId == condominioId);
            return retorno.FirstOrDefault(); ;
        }

        public async Task<VeiculoFlat> ObterVeiculoPorPlacaOuModeloECondominio(string pesquisa, Guid condominioId)
        {
            var retorno = await _veiculoQueryRepository.Obter(v => v.CondominioId == condominioId && (v.Placa.Contains(pesquisa) || v.Modelo.Contains(pesquisa)));
            return retorno.FirstOrDefault(); ;
        }

        public async Task<IEnumerable<VeiculoFlat>> ObterVeiculosPorCondominio(Guid condominioId)
        {
            return await _veiculoQueryRepository.Obter(v => v.CondominioId == condominioId);
        }

        public async Task<IEnumerable<VeiculoFlat>> ObterVeiculosPorUsuario(Guid usuarioId)
        {
            return await _veiculoQueryRepository.Obter(v => v.UsuarioId == usuarioId);
        }

        #endregion


        #region Mobile

        public async Task<IEnumerable<Mobile>> ObterMobilesPorMoradorFuncionarioId(Guid moradorIdFuncionarioId)
        {
            return await _usuarioRepository.ObterMobilePorMoradorIdFuncionarioId(moradorIdFuncionarioId);             
        }

        public async Task<IEnumerable<Mobile>> ObterTodosOsMobiles()
        {
            return await _usuarioRepository.ObterTodosOsMobiles();
        }

        #endregion



        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }

        
    }
}