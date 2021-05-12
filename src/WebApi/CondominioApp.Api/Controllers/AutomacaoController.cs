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

namespace CondominioApp.Api.Controllers
{
    [Route("api/automacao")]
    public class AutomacaoController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IDispositivosServiceFactory _dispositivosServiceFactory;

        public AutomacaoController(IMediatorHandler mediatorHandler, IDispositivosServiceFactory dispositivosServiceFactory)
        {
            _mediatorHandler = mediatorHandler;
            _dispositivosServiceFactory = dispositivosServiceFactory;
        }

       

        [HttpGet("obter-dispositivos")]
        public async Task<ActionResult<IEnumerable<DispositivoViewModel>>> ObterDispositivos(Guid condominioId)
        {
            IDispositivosService dispositivoService = await _dispositivosServiceFactory.Fabricar(TipoApiAutomacao.EWELINK, condominioId);

            var dispositivos = await dispositivoService.ObterDispositivos();

            return dispositivos.ToList();            
        }

        [HttpGet("ligar-desligar-dispositivo")]
        public async Task<ActionResult> LigarDesligarDispositivo(Guid condominioId, string deviceId)
        {
            IDispositivosService dispositivoService = await _dispositivosServiceFactory.Fabricar(TipoApiAutomacao.EWELINK, condominioId);

            var retorno = await dispositivoService.LigarDesligarDispositivo(deviceId);

            return CustomResponse(retorno);           
        }


        
        [HttpPost("credencial-de-api")]
        public async Task<ActionResult> Post(CadastraCondominioCredencialViewModel credencialVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new CadastrarCondominioCredencialCommand(
                credencialVM.Email, credencialVM.Senha, credencialVM.CondominioId, credencialVM.TipoApiAutomacao);

            var Resultado = await _mediatorHandler.EnviarComando(comando);            

            return CustomResponse(Resultado);
        }

        [HttpPut("credencial-de-api")]
        public async Task<ActionResult> Put(EditaCondominioCredencialViewModel credencialVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new EditarCondominioCredencialCommand
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