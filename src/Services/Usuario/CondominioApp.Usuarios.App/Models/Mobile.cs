using CondominioApp.Core.DomainObjects;
using System;

namespace CondominioApp.Usuarios.App.Models
{
    public class Mobile : Entity
    {
        public const int Max = 200;

        public string DeviceKey { get; private set; }

        public string MobileId { get; private set; }

        public string Modelo { get; private set; }

        public string Plataforma { get; private set; }

        public string Versao { get; private set; }

        public Guid MoradorIdFuncionadioId { get; private set; }        

        protected Mobile() { }

        public Mobile(string deviceKey, string mobileId, string modelo, string plataforma, string versao, Guid moradorIdFuncionarioId)
        {
            DeviceKey = deviceKey;
            MobileId = mobileId;
            Modelo = modelo;
            Plataforma = plataforma;
            Versao = versao;
            MoradorIdFuncionadioId = moradorIdFuncionarioId;
        }


        public void SetDeviceKey(string deviceKey) => DeviceKey = deviceKey;

        public void SetMobileId(string mobileid) => MobileId = mobileid;

        public void SetModelo(string modelo) => Modelo = modelo;

        public void SetPlataforma(string plataforma) => Plataforma = plataforma;

        public void SetVersao(string versao) => Versao = versao;

        public void SetMoradorIdFuncionarioId(Guid id) => MoradorIdFuncionadioId = id;
    }
}