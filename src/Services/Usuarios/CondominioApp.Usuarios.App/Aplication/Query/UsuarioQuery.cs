using CondominioApp.Usuarios.App.FlatModel;
using CondominioApp.Usuarios.App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CondominioApp.Usuarios.App.Aplication.Query
{
    public class UsuarioQuery : IUsuarioQuery
    {
        private IUsuarioRepository _usuarioRepository;
        private IVeiculoQueryRepository _veiculoQueryRepository;

        public UsuarioQuery(IUsuarioRepository usuarioRepository, IVeiculoQueryRepository veiculoQueryRepository)
        {
            _usuarioRepository = usuarioRepository;
            _veiculoQueryRepository = veiculoQueryRepository;
        }

        public async Task<Usuario> ObterPorId(Guid Id)
        {
           return await _usuarioRepository.ObterPorId(Id);
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


        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }

        
    }
}