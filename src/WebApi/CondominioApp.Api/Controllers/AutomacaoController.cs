using CondominioApp.Automacao.ViewModel;
using CondominioApp.Automacao.Services.Interfaces;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CondominioApp.Core.Mediator;
using CondominioApp.Automacao.App.Aplication.Commands;
using CondominioApp.Core.Enumeradores;

namespace CondominioApp.Api.Controllers
{
    [Route("api/automacao")]
    public class AutomacaoController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IAutomacaoService _automacaoService;

        public AutomacaoController(IMediatorHandler mediatorHandler, IAutomacaoService automacaoService)
        {
            _mediatorHandler = mediatorHandler;
            _automacaoService = automacaoService;
        }

       

        [HttpGet("obter-dispositivos-ewelink/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<DispositivoViewModel>>> ObterDispositivosEwelink(Guid condominioId)
        {
            try
            {
                var dispositivos = await _automacaoService.ObterDispositivos(condominioId, TipoApiAutomacao.EWELINK);

                return dispositivos.ToList();
            }
            catch (Exception e)
            {
                AdicionarErroProcessamento(e.Message);
                return CustomResponse();
            }
        }

        [HttpGet("ligar-desligar-dispositivo-ewelink")]
        public async Task<ActionResult> LigarDesligarDispositivoEwelink(Guid condominioId, string deviceId)
        {
            try
            {
                var retorno = await _automacaoService.LigarDesligarDispositivo(condominioId, deviceId);

                return CustomResponse(retorno);
            }
            catch (Exception e)
            {
                AdicionarErroProcessamento(e.Message);
                return CustomResponse();
            }
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

            var comando = new RemoverCondominioCredencialCommand(id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }
    }
}