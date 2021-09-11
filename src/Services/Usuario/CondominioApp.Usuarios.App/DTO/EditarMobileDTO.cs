using System;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;
using CondominioApp.Usuarios.App.Models;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class EditarMobileDTO
    {
        public Guid Id { get; set; }

        public string DeviceKey { get; set; }

        public string MobileId { get; set; }

        public string Modelo { get; set; }

        public string Plataforma { get; set; }

        public string Versao { get; set; }

        public Guid MoradorFuncionarioId { get; set; }

        public Mobile Mobile { get; set; }

        public EditarMobileDTO(string deviceKey, string mobileId, string modelo, string plataforma, string versao, Guid moradorIdFuncionarioId, Mobile mobile )
        {
            Mobile = mobile;
            DeviceKey = deviceKey;
            MobileId = mobileId;
            Modelo = modelo;
            Plataforma = plataforma;
            Versao = versao;
            MoradorFuncionarioId = moradorIdFuncionarioId;
        }

    }
}