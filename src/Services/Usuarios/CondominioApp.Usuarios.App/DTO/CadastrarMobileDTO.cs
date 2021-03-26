using System;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class CadastrarMobileDTO
    {       
        public string DeviceKey { get; set; }

        public string MobileId { get; set; }

        public string Modelo { get; set; }

        public string Plataforma { get; set; }

        public string Versao { get; set; }

        public Guid MoradorFuncionarioId { get; set; }

        public CadastrarMobileDTO(string deviceKey, string mobileId, string modelo, string plataforma, string versao, Guid usuarioId)
        {
            DeviceKey = deviceKey;
            MobileId = mobileId;
            Modelo = modelo;
            Plataforma = plataforma;
            Versao = versao;
            MoradorFuncionarioId = usuarioId;
        }

    }
}