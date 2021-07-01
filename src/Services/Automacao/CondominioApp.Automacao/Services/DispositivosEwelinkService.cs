using EwelinkNet;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.Results;
using System.Linq;
using CondominioApp.Automacao.ViewModel;
using CondominioApp.Automacao.Models;
using CondominioApp.Automacao.App.Services.Interfaces;
using CondominioApp.Core.Service;

namespace CondominioApp.Automacao.Services
{
   public class DispositivosEwelinkService : ServiceBase, IDispositivosService
    {
        private readonly string Regiao = "us";

        private readonly CondominioCredencial _credencialDoCondominio;
        

        public DispositivosEwelinkService()
        {
        }

        public DispositivosEwelinkService(CondominioCredencial credencialDoCondominio)
        {
            _credencialDoCondominio = credencialDoCondominio;            
        }


        public async Task<IEnumerable<DispositivoViewModel>> ObterDispositivos()
        {
            if (_credencialDoCondominio == null)
            {
                AdicionarErrosDeProcessamento("Credencial do Condomínio não encontrada no banco de dados.");
                return null;
            }                

            var ewelink = new Ewelink
                (_credencialDoCondominio.Email.Endereco, _credencialDoCondominio.SenhaDescriptografa,
                 _credencialDoCondominio.CondominioId, Regiao);

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
    

        public ValidationResult LigarDesligarDispositivo(string dispositivoId)
        {            
            if (_credencialDoCondominio == null)
            {
                AdicionarErrosDeProcessamento("Credencial do Condomínio não encontrada no banco de dados.");
                return ValidationResult;
            }

            var ewelink = new Ewelink
                (_credencialDoCondominio.Email.Endereco, _credencialDoCondominio.SenhaDescriptografa,
                 _credencialDoCondominio.CondominioId, Regiao);


            ewelink.OpenWebSocket();

            ewelink.ToggleDevice(dispositivoId);

            ewelink.CloseWebSocket();

            return ValidationResult;
        }

       
       
    }
}
