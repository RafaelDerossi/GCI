using CondominioApp.Usuarios.App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.Usuarios.App.Aplication.Query
{
    public class UsuarioQuery : IUsuarioQuery
    {
        private IUsuarioRepository _usuarioRepository;       

        public UsuarioQuery(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;            
        }

        public async Task<Usuario> ObterPorId(Guid Id)
        {
           return await _usuarioRepository.ObterPorId(Id);
        }



        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }

        
    }
}