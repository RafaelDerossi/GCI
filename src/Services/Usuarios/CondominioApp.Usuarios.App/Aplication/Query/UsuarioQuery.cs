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

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }

        
    }
}