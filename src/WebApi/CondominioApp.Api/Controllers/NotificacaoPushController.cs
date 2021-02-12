using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CondominioApp.Core.Mediator;
using CondominioApp.NotificacaoPush.App.Services.Interfaces;
using CondominioApp.OneSignal.Recursos;
using CondominioApp.OneSignal.Recursos.Dispositivos.Enuns;
using CondominioApp.NotificacaoPush.App.DTO;
using CondominioApp.NotificacaoPush.App.ViewModel;
using CondominioApp.NotificacaoPush.App.OneSignalApps;

namespace CondominioApp.Api.Controllers
{
    [Route("api/notificacaoPush")]
    public class NotificacaoPushController : MainController
    {        
        private readonly INotificacaoPushService _notificacaoPushService;

        public NotificacaoPushController(INotificacaoPushService notificacaoPushService)
        {     
            _notificacaoPushService = notificacaoPushService;
        }        

        [HttpPost("criar-notificacao")]
        public ActionResult CriarNotificacao(NotificacaoPushViewModel notificacaoVM)
        {
            var notificacaoDTO = new NotificacaoPushDTO();

            notificacaoDTO.AppOneSignal = new CondominioAppOneSignalApp();

            if (notificacaoVM.ApiKey != notificacaoDTO.AppOneSignal.ApiKey)
            {
                AdicionarErroProcessamento("ApiKey invalida!");
                return CustomResponse();
            }
                        
            notificacaoDTO.Titulos.Add(CodigosDeLingua.English, notificacaoVM.Titulo);
                        
            notificacaoDTO.Conteudo.Add(CodigosDeLingua.English, notificacaoVM.Conteudo);
                        
            notificacaoDTO.DispositivosIds = notificacaoVM.DispositivosIds;

            var retorno = _notificacaoPushService.CriarNotificacao(notificacaoDTO);
            if (!retorno.IsValid)
            {
                foreach (var item in retorno.Errors)
                {
                    AdicionarErroProcessamento(item.ErrorMessage);
                }
            }

            notificacaoDTO.AppOneSignal = new CondominioAppV2OneSignalApp();
            retorno = _notificacaoPushService.CriarNotificacao(notificacaoDTO);
            if (!retorno.IsValid)
            {
                foreach (var item in retorno.Errors)
                {
                    AdicionarErroProcessamento(item.ErrorMessage);
                }
            }

            return CustomResponse();
            
        }


        //[HttpPost("criar-notificacao-AppV2")]
        //public ActionResult CriarNotificacaoAppV2(NotificacaoPushViewModel notificacaoVM)
        //{
        //    var notificacaoDTO = new NotificacaoPushDTO();

        //    notificacaoDTO.AppOneSignal = new CondominioAppV2OneSignalApp();

        //    if (notificacaoVM.ApiKey != notificacaoDTO.AppOneSignal.ApiKey)
        //    {
        //        AdicionarErroProcessamento("ApiKey invalida!");
        //        return CustomResponse();
        //    }

        //    //notificacaoDTO.Titulos.Add(CodigosDeLingua.English, "Condominio App");
        //    notificacaoDTO.Titulos.Add(CodigosDeLingua.English, notificacaoVM.Titulo);

        //    //notificacaoDTO.Conteudo.Add(CodigosDeLingua.English, "Hello world 6!");
        //    notificacaoDTO.Conteudo.Add(CodigosDeLingua.English, notificacaoVM.Conteudo);

        //    //notificacaoDTO.DispositivosIds = new List<string> { "159b6c6f-99b2-4e82-9875-3aa5295c5c74" };
        //    notificacaoDTO.DispositivosIds = notificacaoVM.DispositivosIds;

        //    return CustomResponse(_notificacaoPushService.CriarNotificacao(notificacaoDTO));

        //}

    }
}