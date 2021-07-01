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

        
        [HttpGet("obter-dispositivos")]
        public async Task<ActionResult<IEnumerable<DispositivoViewModel>>> ObterDispositivos(Guid condominioId)
        {
            var dispositivoService = await _dispositivosServiceFactory.Fabricar(TipoApiAutomacao.EWELINK, condominioId);

            var dispositivos = await dispositivoService.ObterDispositivos();
            if (!dispositivoService.EstaValido())
            {                
                return CustomResponse(dispositivoService.ValidationResult);
            }
            if (dispositivos == null)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            return dispositivos.ToList();            
        }


        [HttpGet("ligar-desligar-dispositivo")]
        public async Task<ActionResult> LigarDesligarDispositivo(Guid condominioId, string deviceId)
        {
            IDispositivosService dispositivoService = await _dispositivosServiceFactory.Fabricar(TipoApiAutomacao.EWELINK, condominioId);

            var retorno = dispositivoService.LigarDesligarDispositivo(deviceId);

            return CustomResponse(retorno);           
        }


        
        [HttpPost("credencial-de-api")]
        public async Task<ActionResult> Post(AdicionaCondominioCredencialViewModel credencialVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AdicionarCondominioCredencialCommand(
                credencialVM.Email, credencialVM.Senha, credencialVM.CondominioId, credencialVM.TipoApiAutomacao);

            var Resultado = await _mediatorHandler.EnviarComando(comando);            

            return CustomResponse(Resultado);
        }

        [HttpPut("credencial-de-api")]
        public async Task<ActionResult> Put(AtualizaCondominioCredencialViewModel credencialVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AtualizarCondominioCredencialCommand
                (credencialVM.Id, credencialVM.Email, credencialVM.Senha, credencialVM.TipoApiAutomacao);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpDelete("credencial-de-api/{id:Guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new ApagarCondominioCredencialCommand(id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }
    }
}