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
using System;
using CondominioApp.NotificacaoPush.App.Aplication.Commands;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("api/notificacaoPush")]
    public class NotificacaoPushController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly INotificacaoPushService _notificacaoPushService;

        public NotificacaoPushController(IMediatorHandler mediatorHandler, INotificacaoPushService notificacaoPushService)
        {
            _mediatorHandler = mediatorHandler;
            _notificacaoPushService = notificacaoPushService;
        }        

        [HttpPost("criar-notificacao")]
        public ActionResult CriarNotificacao(NotificacaoPushViewModel notificacaoVM)
        {
            var notificacaoDTO = new NotificacaoPushDTO();            

            var AppMorador = new MoradorOneSignalApp();
            var AppSindico = new SindicoOneSignalApp();

            if (notificacaoVM.ApiKey == AppMorador.ApiKey)
                notificacaoDTO.AppOneSignal = AppMorador;

            if (notificacaoVM.ApiKey == AppSindico.ApiKey)
                notificacaoDTO.AppOneSignal = AppSindico;

            if (notificacaoVM.ApiKey == null)
            {
                AdicionarErroProcessamento("ApiKey não identificada.");
                return CustomResponse();
            }                

            notificacaoDTO.Titulos.Add(CodigosDeLingua.English, notificacaoVM.Titulo);
                        
            notificacaoDTO.Conteudo.Add(CodigosDeLingua.English, notificacaoVM.Conteudo);
                        
            notificacaoDTO.DispositivosIds = notificacaoVM.DispositivosIds;
                       
            return CustomResponse(_notificacaoPushService.CriarNotificacao(notificacaoDTO));
            
        }

        [HttpPost("notificar-todos-por-condominio")]
        public async Task<ActionResult> NotificarTodosPorCondominio(NotificarTodosPorCondominioViewModel notificacaoVM)
        {
            if (notificacaoVM.CondominioId == Guid.Empty)
            {
                AdicionarErroProcessamento("Informe um condomínio.");
                return CustomResponse();
            }

            var comando = new EnviarNotificacaoParaTodosNoCondominioCommand
                (notificacaoVM.Titulo, notificacaoVM.Conteudo, notificacaoVM.CondominioId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);            
            if (!Resultado.IsValid)
                return CustomResponse();

            return CustomResponse(Resultado);
        }

    }
}