using CondominioApp.Automacao.Models.Credencial;
using CondominioApp.Automacao.Models.Dispositivo;
using CondominioApp.Automacao.Services.Interfaces;
using EwelinkNet;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.Results;
using System.Linq;

namespace CondominioApp.Automacao.Services
{
   public class AutomacaoService : ServiceBase, IAutomacaoService
    {
        private string Regiao = "us";

        public async Task<Credencial> ObterCredencial(string email, string senha)
        {            
            var ewelink = new Ewelink(email, senha, Regiao);
            await ewelink.GetCredentials();

            if (ewelink.at == null)
                return null;

            var credencial = new Credencial()
            {
                Token = ewelink.at,
                Regiao = ewelink.region,
                Email = email,
                Senha = senha
            };           

            return credencial;
        }

        public async Task<IEnumerable<Dispositivo>> ObterDispositivos(string email, string senha)
        {
            var ewelink = new Ewelink(email, senha, Regiao);
            await ewelink.GetCredentials();
            await ewelink.GetDevices();

            var dispositivos = new List<Dispositivo>();
            if (ewelink.Devices.Length > 0)
            {
                for (int i = 0; i < ewelink.Devices.Length; i++)
                {
                    var dispositivo = new Dispositivo()
                    {
                        DispositivoId = ewelink.Devices[i].deviceid,                        
                        Nome = ewelink.Devices[i].name,
                        Tipo = ewelink.Devices[i].type,
                        Chave = ewelink.Devices[i].devicekey,
                        Apikey = ewelink.Devices[i].apikey,                        
                        Grupo = ewelink.Devices[i].group,
                        Online = ewelink.Devices[i].online,
                        Localizacao = ewelink.Devices[i].location,
                        OnlineHora = ewelink.Devices[i].onlineTime,
                        DataDeCriacao = ewelink.Devices[i].createdAt,
                        Ip = ewelink.Devices[i].ip,
                        OfflineHora = ewelink.Devices[i].offlineTime,
                        StatusDoDispositivo = ewelink.Devices[i].deviceStatus,
                        UrlDoDispositivo = ewelink.Devices[i].deviceUrl,
                        NomeDaMarca = ewelink.Devices[i].brandName,
                        MostraMarca = ewelink.Devices[i].showBrand,
                        UrlDaLogoDaMarca = ewelink.Devices[i].brandLogoUrl,
                        ModeloDoProduto = ewelink.Devices[i].productModel
                    };

                    dispositivos.Add(dispositivo);
                }
            }            

            return dispositivos;
        }
        
        public async Task<ValidationResult> LigarDesligarDispositivo(string email, string senha, string dispositivoId)
        {
            var ewelink = new Ewelink(email, senha, Regiao);            

            await ewelink.GetCredentials();

            if (ewelink.at == null)
            {
                AdicionarErrosDeProcessamento("Credencial não encontrada.");
                return ValidationResult;
            }                

            await ewelink.GetDevices();

            if (ewelink.Devices == null || ewelink.Devices.Length == 0)
            {
                AdicionarErrosDeProcessamento("Nenhum dispositivo encontrado nesta conta.");
                return ValidationResult;
            }

            if (ewelink.Devices.Count(x => x.deviceid == dispositivoId) == 0)
            {
                AdicionarErrosDeProcessamento("Dispositivo não encontrado.");
                return ValidationResult;
            }

            ewelink.OpenWebSocket();

            ewelink.ToggleDevice(dispositivoId);

            ewelink.CloseWebSocket();

            return ValidationResult;
        }

    }
}
