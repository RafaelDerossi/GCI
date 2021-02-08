using EwelinkNet;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.Results;
using System.Linq;
using CondominioApp.Automacao.ViewModel;
using CondominioApp.Automacao.Models;
using CondominioApp.Automacao.App.Services.Interfaces;

namespace CondominioApp.Automacao.Services
{
   public class DispositivosEwelinkService : ServiceBase, IDispositivosService
    {
        private string Regiao = "us";

        CondominioCredencial _credencial;

        public DispositivosEwelinkService()
        {
        }
        public DispositivosEwelinkService(CondominioCredencial credencial)
        {
            _credencial = credencial;            
        }


        public async Task<IEnumerable<DispositivoViewModel>> ObterDispositivos()
        {
            var ewelink = new Ewelink(_credencial.Email.Endereco, _credencial.SenhaDescriptografa, Regiao);
            await ewelink.GetCredentials();
            await ewelink.GetDevices();

            var dispositivos = new List<DispositivoViewModel>();
            if (ewelink.Devices.Length > 0)
            {
                for (int i = 0; i < ewelink.Devices.Length; i++)
                {
                    var dispositivo = new DispositivoViewModel()
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
                        State = ewelink.Devices[i].GetParameter("switch"),
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
    

        public async Task<ValidationResult> LigarDesligarDispositivo(string dispositivoId)
        {            
            if (_credencial == null)
            {
                AdicionarErrosDeProcessamento("Credencial não encontrada no banco de dados.");
                return ValidationResult;
            }

            var ewelink = new Ewelink(_credencial.Email.Endereco, _credencial.SenhaDescriptografa, Regiao);            

            await ewelink.GetCredentials();

            if (ewelink.at == null)
            {
                AdicionarErrosDeProcessamento("Credencial não encontrada na API.");
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
