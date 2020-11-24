using System;

namespace CondominioApp.Identidade.Api.Models
{
    public class UsuarioDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}