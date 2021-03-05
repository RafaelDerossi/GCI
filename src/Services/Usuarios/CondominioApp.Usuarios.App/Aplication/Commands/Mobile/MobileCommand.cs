using CondominioApp.Core.Messages;
using System;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public abstract class MobileCommand : Command
    {
        public Guid Id { get; protected set; }

        public string DeviceKey { get; protected set; }

        public string MobileId { get; protected set; }

        public string Modelo { get; protected set; }

        public string Plataforma { get; protected set; }

        public string Versao { get; protected set; }

        public Guid UsuarioId { get; protected set; }


        public void SetDeviceKey(string deviceKey) => DeviceKey = deviceKey;

        public void SetMobileId(string id) => MobileId = id;

        public void SetModelo(string modelo) => Modelo = modelo;

        public void SetPlataforma(string plataforma) => Plataforma = plataforma;

        public void SetVersao(string versao) => Versao = versao;

        public void SetUsuarioId(Guid id) => UsuarioId = id;

       
    }
}
