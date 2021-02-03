using CondominioApp.Automacao.Models.Credencial;
using CondominioApp.Automacao.Models.Dispositivo;
using CondominioApp.Automacao.Services.Interfaces;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("api/automacao")]
    public class AutomacaoController : MainController
    {
        private readonly IAutomacaoService _automacaoService;

        public AutomacaoController(IAutomacaoService automacaoService)
        {
            _automacaoService = automacaoService;
        }

        [HttpGet("obter-credencial")]
        public async Task<ActionResult<Credencial>> ObterCredencial(string email, string senha)
        {
            try
            {
                var credencial = await _automacaoService.ObterCredencial(email, senha);                
                                
                return credencial;
            }
            catch (Exception e)
            {
                AdicionarErroProcessamento(e.Message);
                return CustomResponse();                
            }
        }

        [HttpGet("obter-dispositivos")]
        public async Task<ActionResult<IEnumerable<Dispositivo>>> ObterDispositivos(string email, string senha)
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

        [HttpGet("ligar-desligar-dispositivo")]
        public async Task<ActionResult> LigarDesligarDispositivo(string email, string senha, string deviceId)
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
    }
}