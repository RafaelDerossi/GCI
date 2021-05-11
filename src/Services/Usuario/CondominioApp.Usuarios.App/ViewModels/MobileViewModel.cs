using System;

namespace CondominioApp.Usuarios.App.ViewModels
{
    public class MobileViewModel
    {
        public Guid Id { get; set; }

        public string DataDeCadastro { get; set; }

        public string DataDeAlteracao { get; set; }

        public string DeviceKey { get; set; }

        public string MobileId { get; set; }

        public string Modelo { get; set; }

        public string Plataforma { get; set; }

        public string Versao { get; set; }

        public Guid UsuarioId { get; set; }

        //EF
        public UsuarioViewModel Usuario { get; set; }

    }
}