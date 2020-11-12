using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CondominioApp.Principal.Aplication.Commands;
using CondominioApp.Principal.Aplication.ViewModels;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using CondominioApp.Core.Mediator;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CondominioApp.Api.Controllers
{
    [Route("api/principal")]
    [ApiController]
    public class CondominioController : MainController
    {

        private readonly IMediatorHandler _mediatorHandler;

        public CondominioController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }



        // GET: api/<CondominioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CondominioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }



        // POST api/Novo-condominio
        [HttpPost("Novo-condominio")]
        public async Task<ActionResult> Post(CondominioViewModel condominioVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);


            var comando = CadastrarCondominioCommandFactory(condominioVM);

            if (!OperacaoValida())
            {
                return CustomResponse();
            }

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            if (!Resultado.IsValid)
            {                
                return CustomResponse(Resultado);
            }
            
            foreach (var error in Resultado.Errors)
            {
                AdicionarErroProcessamento(error.ErrorMessage);
            }

            return CustomResponse();
        }

        // POST api/Novo-grupo
        [HttpPost("Novo-grupo")]
        public async Task<ActionResult> Post(GrupoViewModel grupoVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);


            var comando = CadastrarGrupoCommandFactory(grupoVM);

            if (!OperacaoValida())
            {
                return CustomResponse();
            }

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            if (!Resultado.IsValid)
            {
                return CustomResponse(Resultado);
            }

            foreach (var error in Resultado.Errors)
            {
                AdicionarErroProcessamento(error.ErrorMessage);
            }

            return CustomResponse();
        }



        private CadastrarCondominioCommand CadastrarCondominioCommandFactory(CondominioViewModel condominioVM)
        {
            try
            {
                return new CadastrarCondominioCommand(
                 condominioVM.Cnpj, condominioVM.Nome, condominioVM.Descricao, condominioVM.LogoMarca,
                 condominioVM.NomeOriginal, condominioVM.Telefone, condominioVM.RefereciaId, condominioVM.LinkGeraBoleto,
                 condominioVM.BoletoFolder, condominioVM.UrlWebServer, condominioVM.Portaria, condominioVM.PortariaMorador,
                 condominioVM.Classificado, condominioVM.ClassificadoMorador, condominioVM.Mural, condominioVM.MuralMorador,
                 condominioVM.Chat, condominioVM.ChatMorador, condominioVM.Reserva, condominioVM.ReservaNaPortaria,
                 condominioVM.Ocorrencia, condominioVM.OcorrenciaMorador, condominioVM.Correspondencia, 
                 condominioVM.CorrespondenciaNaPortaria, condominioVM.LimiteTempoReserva);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return null;
            }
        }

        private CadastrarGrupoCommand CadastrarGrupoCommandFactory(GrupoViewModel grupoVM)
        {
            try
            {
                return new CadastrarGrupoCommand(
                 grupoVM.Descricao, grupoVM.CondominioId);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return null;
            }
        }
    }
}
