using System;

namespace CondominioAppMarketplace.Domain
{
    public class UsuarioDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}