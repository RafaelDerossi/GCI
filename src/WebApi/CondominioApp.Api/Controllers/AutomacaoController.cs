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

       

        [HttpGet("obter-dispositivos-ewelink")]
        public async Task<ActionResult<IEnumerable<DispositivoViewModel>>> ObterDispositivosEwelink(string email, string senha)
        {
            try
            {
                var dispositivos = await _automacaoService.ObterDispositivos(email, senha);

                return dispositivos.ToList();
            }
            catch (Exception e)
            {
                AdicionarErroProcessamento(e.Message);
                return CustomResponse();
            }
        }

        [HttpGet("ligar-desligar-dispositivo-ewelink")]
        public async Task<ActionResult> LigarDesligarDispositivoEwelink(string email, string senha, string deviceId)
        {
            try
            {
                var retorno = await _automacaoService.LigarDesligarDispositivo(email, senha, deviceId);

                return CustomResponse(retorno);
            }
            catch (Exception e)
            {
                AdicionarErroProcessamento(e.Message);
                return CustomResponse();
            }
        }


        
        [HttpPost("cadastrar-credencial-de-api")]
        public async Task<ActionResult> Post(CadastraCondominioCredencialViewModel credencialVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new CadastrarCondominioCredencialCommand(
                credencialVM.Email, credencialVM.Senha, credencialVM.CondominioId, credencialVM.TipoApiAutomacao);

            var Resultado = await _mediatorHandler.EnviarComando(comando);            

            return CustomResponse(Resultado);
        }

    }
}