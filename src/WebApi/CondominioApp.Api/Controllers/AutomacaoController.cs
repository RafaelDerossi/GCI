using CondominioApp.Automacao.ViewModel;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CondominioApp.Core.Mediator;
using CondominioApp.Automacao.App.Aplication.Commands;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Automacao.App.Factory;
using CondominioApp.Automacao.App.Services.Interfaces;
using CondominioApp.Automacao.App.Aplication.Query;

namespace CondominioApp.Api.Controllers
{
    [Route("api/automacao")]
    public class AutomacaoController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IDispositivosServiceFactory _dispositivosServiceFactory;
        private readonly IAutomacaoQuery _automacaoQuery;

        public AutomacaoController
            (IMediatorHandler mediatorHandler, IDispositivosServiceFactory dispositivosServiceFactory, IAutomacaoQuery automacaoQuery)
        {
            _mediatorHandler = mediatorHandler;
            _dispositivosServiceFactory = dispositivosServiceFactory;
            _automacaoQuery = automacaoQuery;
        }


        /// <summary>
        /// Retorna a credencial Ewelink cadastrada
        /// </summary>
        /// <param name="condominioId">Id(guid) do condominio</param>
        /// <returns></returns>
        [HttpGet("obter-credencial")]
        public async Task<ActionResult<CondominioCredencialViewModel>> ObterCredencial(Guid condominioId)
        {
            var credencial = await _automacaoQuery.ObterPorCondominioETipoApi(condominioId, TipoApiAutomacao.EWELINK);
            if (credencial == null)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var credencialViewModel = new CondominioCredencialViewModel(credencial);

            return credencialViewModel;
        }

        /// <summary>
        /// Retorna todos os dispositivos (Ewelink e Webhooks cadastrados)
        /// </summary>
        /// <param name="condominioId">Id(guid) do condominio</param>
        /// <response code="200">
        /// DispositivoId;   
        /// Nome;  
        /// Online: Informa se o dispositivo esta online(Ewelink);  
        /// OnlineHora: Informa a hora em que o dispositivo ficou online pela última vez (Ewelink);  
        /// DataDeCriacao: Data de criação do dispositivo;  
        /// Ip: Ip do dispositivo (Ewelink);  
        /// OfflineHora: Informa a hora em que o dispositivo ficou offline pela última vez (Ewelink);     
        /// State: Informa se o dispositivo esta ligado(on) ou desligado(off);  
        /// NomeDaMarca: Informa a marca do dispositivo (Ewelink);  
        /// ModeloDoProduto: Informa o modelo do dispositivo (Ewelink);  
        /// Pulse: Informa se o modo pulse do dispositivo esta ligado(on) ou desligado(off);  
        /// PulseWidth: Tempo em milisegundos do pulse;  
        /// TipoAutomacao: Enum (Ewelink = 1, Webhook = 2);  
        /// </response>
        [HttpGet("obter-dispositivos")]
        public async Task<ActionResult<IEnumerable<DispositivoViewModel>>> ObterDispositivos(Guid condominioId)
        {
            var lista = new List<DispositivoViewModel>();

            
            var dispositivoServiceEwelink = await _dispositivosServiceFactory.Fabricar(TipoApiAutomacao.EWELINK, condominioId);

            var dispositivosEwelink = await dispositivoServiceEwelink.ObterDispositivos();

            foreach (var item in dispositivosEwelink)
            {
                lista.Add(item);
            }

            var dispositivoServiceWebhook = await _dispositivosServiceFactory.Fabricar(TipoApiAutomacao.WEBHOOK, condominioId);

            var dispositivosWebhook = await dispositivoServiceWebhook.ObterDispositivos();
            
            foreach (var item in dispositivosWebhook)
            {
                lista.Add(item);
            }

            return lista;
        }

        /// <summary>
        /// Liga o dispositivo se estiver desligado e vice-versa
        /// </summary>
        /// <param name="condominioId">Id(Guid) do condomínio</param>
        /// <param name="deviceId">Id do dispositivo</param>
        /// <param name="tipo">Tipo da automação (Ewelink = 1, Webhook = 2)</param>
        /// <returns></returns>
        [HttpGet("ligar-desligar-dispositivo")]
        public async Task<ActionResult> LigarDesligarDispositivo(Guid condominioId, string deviceId, TipoApiAutomacao tipo)
        {
            IDispositivosService dispositivoService = await _dispositivosServiceFactory.Fabricar(tipo, condominioId);

            var retorno = dispositivoService.LigarDesligarDispositivo(deviceId);

            if (tipo == TipoApiAutomacao.WEBHOOK)
            {
                var comando = new LigarDesligarDispositivoWebhookCommand(Guid.Parse(deviceId));

                var Resultado = await _mediatorHandler.EnviarComando(comando);                
            }

            return CustomResponse(retorno);           
        }


        /// <summary>
        /// Adiciona uma credencial do Ewelink no sistema
        /// </summary>
        /// <param name="credencialVM">
        /// Email: email cadastrado na Ewelink;   
        /// Senha: senha cadastrada na Ewelink;   
        /// CondominioiId: Id(Guid) do condominio;   
        /// </param>
        /// <returns></returns>
        [HttpPost("credencial-de-api")]
        public async Task<ActionResult> Post(AdicionaCondominioCredencialViewModel credencialVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AdicionarCondominioCredencialCommand(
                credencialVM.Email, credencialVM.Senha, credencialVM.CondominioId, TipoApiAutomacao.EWELINK);

            var Resultado = await _mediatorHandler.EnviarComando(comando);            

            return CustomResponse(Resultado);
        }

        /// <summary>
        /// Atualiza uma credencial do Ewelink no sistema
        /// </summary>
        /// <param name="credencialVM">
        /// Id: Id(Guid) da credencial a ser atualizada;   
        /// Email: email cadastrado na Ewelink;   
        /// Senha: senha cadastrada na Ewelink;   
        /// </param>
        /// <returns></returns>
        [HttpPut("credencial-de-api")]
        public async Task<ActionResult> Put(AtualizaCondominioCredencialViewModel credencialVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AtualizarCondominioCredencialCommand
                (credencialVM.Id, credencialVM.Email, credencialVM.Senha, TipoApiAutomacao.EWELINK);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        /// <summary>
        /// Envia uma credencial para a lixeira
        /// </summary>
        /// <param name="id">Id(Guid) da credencial a ser apagada;</param>
        /// <returns></returns>
        [HttpDelete("credencial-de-api/{id:Guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new ApagarCondominioCredencialCommand(id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        /// <summary>
        /// Cadastra um dispositivo webhook
        /// </summary>
        /// <param name="viewModel"></param>
        /// <response code="200">        
        /// Nome: Nome para o dispositivo;   
        /// UrlLigar: Url para ligar o dispositivo;   
        /// UrlDesligar: Url para desligar o dispositivo;   
        /// Pulse: Informa se o modo pulse do dispositivo esta ligado(on) ou desligado(off);  
        /// PulseWidth: Tempo em milisegundos do pulse;    
        /// CondominioiId: Id(Guid) do condominio;
        /// </response>
        [HttpPost("dispositivoWebhook")]
        public async Task<ActionResult> PostDispositivoWenhook(AdicionaDispositivoWebhookViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AdicionarDispositivoWebhookCommand
                (viewModel.Nome, viewModel.CondominioId, viewModel.UrlLigar, viewModel.UrlDesligar,
                 viewModel.PulseLigado, viewModel.TempoDoPulse);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        /// <summary>
        /// Atualiza um dispositivo webhook
        /// </summary>
        /// <param name="viewModel"></param>
        /// <response code="200">        
        /// Id: Id(Guid) do dispositivo;   
        /// Nome: Nome para o dispositivo;          
        /// Pulse: Informa se o modo pulse do dispositivo esta ligado(on) ou desligado(off);   
        /// PulseWidth: Tempo em milisegundos do pulse;   
        /// </response>
        [HttpPut("dispositivoWebhook")]
        public async Task<ActionResult> PutDispositivoWenhook(AtualizaDispositivoWebhookViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AtualizarDispositivoWebhookCommand(
                viewModel.Id, viewModel.Nome, viewModel.UrlLigar, viewModel.UrlDesligar,
                 viewModel.PulseLigado, viewModel.TempoDoPulse);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        /// <summary>
        /// Envia um Dispositivo webhook para a lixeira
        /// </summary>
        /// <param name="id">Id(Guid) do dispositivo a ser apagado</param>
        /// <returns></returns>
        [HttpDelete("dispositivoWebhook/{id:Guid}")]
        public async Task<ActionResult> DeleteDispositivoWebhook(Guid id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new ApagarDispositivoWebhookCommand(id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

    }
}