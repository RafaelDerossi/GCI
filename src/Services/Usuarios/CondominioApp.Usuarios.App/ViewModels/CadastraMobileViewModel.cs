using System;

namespace CondominioApp.Usuarios.App.ViewModels
{
    public class CadastraMobileViewModel
    {
        public string DeviceKey { get; set; }

        public string MobileId { get; set; }

        public string Modelo { get; set; }

        public string Plataforma { get; set; }

        public string Versao { get; set; }
        
        public Guid UsuarioId { get; set; }
    }
}