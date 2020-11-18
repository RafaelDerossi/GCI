using CondominioApp.Core.DomainObjects;
using System;

namespace CondominioApp.Usuarios.App.Models.FlatModel
{
    public class MobileFlat : Entity
    {
        public Guid Id { get; set; }

        public string DeviceKey { get; private set; }

        public string MobileId { get; private set; }

        public string Modelo { get; private set; }

        public string Plataforma { get; private set; }

        public string Versao { get; private set; }

        public Guid UsuarioId { get; set; }

        public string UsuarioNome { get; set; }

        public string UsuarioEmail { get; set; }

        public string UsuarioFoto { get; set; }

        public string TpUsuario { get; set; }

        public string UsuarioPermissao { get; set; }

        public bool UsuarioAtivo { get; private set; }

        public string UsuarioAtribuicao { get; private set; }

        public string UsuarioFuncao { get; private set; }
    }
}