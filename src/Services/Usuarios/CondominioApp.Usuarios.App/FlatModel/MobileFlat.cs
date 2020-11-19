using CondominioApp.Core.DomainObjects;
using System;

namespace CondominioApp.Usuarios.App.Models.FlatModel
{
    public class MobileFlat 
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

        public MobileFlat(Guid id, string deviceKey, string mobileId, string modelo, string plataforma,
            string versao, Guid usuarioId, string usuarioNome, string usuarioEmail, string usuarioFoto,
            string tpUsuario, string usuarioPermissao, bool usuarioAtivo, string usuarioAtribuicao, 
            string usuarioFuncao)
        {
            Id = id;
            DeviceKey = deviceKey;
            MobileId = mobileId;
            Modelo = modelo;
            Plataforma = plataforma;
            Versao = versao;
            UsuarioId = usuarioId;
            UsuarioNome = usuarioNome;
            UsuarioEmail = usuarioEmail;
            UsuarioFoto = usuarioFoto;
            TpUsuario = tpUsuario;
            UsuarioPermissao = usuarioPermissao;
            UsuarioAtivo = usuarioAtivo;
            UsuarioAtribuicao = usuarioAtribuicao;
            UsuarioFuncao = usuarioFuncao;
        }
    }
}