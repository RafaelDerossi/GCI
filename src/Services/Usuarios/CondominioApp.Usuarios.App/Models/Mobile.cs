using CondominioApp.Core.DomainObjects;

namespace CondominioApp.Usuarios.App.Models
{
    public class Mobile : Entity
    {
        public string DeviceKey { get; private set; }

        public string MobileId { get; private set; }

        public string Modelo { get; private set; }

        public string Plataforma { get; private set; }

        public string Versao { get; private set; }

        //EF
        public Usuario Usuario { get; set; }

        protected Mobile() { }

        public Mobile(string deviceKey, string mobileId, string modelo, string plataforma, string versao, Usuario usuario)
        {
            DeviceKey = deviceKey;
            MobileId = mobileId;
            Modelo = modelo;
            Plataforma = plataforma;
            Versao = versao;
            Usuario = usuario;
        }
    }
}