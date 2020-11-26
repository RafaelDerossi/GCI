using CondominioApp.Core.Mediator;
using CondominioApp.Principal.Aplication.Commands;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Principal.Aplication.ViewModels;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("api/condominio")]
    public class CondominioController : MainController
    {

        private readonly IMediatorHandler _mediatorHandler;
        private readonly ICondominioQuery _condominioQuery; 
        public CondominioController(IMediatorHandler mediatorHandler, ICondominioQuery condominioQuery)
        {
            _mediatorHandler = mediatorHandler;
            _condominioQuery = condominioQuery;
        }



        [HttpGet]
        public async Task<IEnumerable<CondominioFlat>> ObterTodos()
        {
            return await _condominioQuery.ObterTodos();
        }

        [HttpGet("{Id:Guid}")]
        public async Task<CondominioFlat> ObterPorId(Guid Id)
        {
            return await _condominioQuery.ObterPorId(Id);
        }
          
        [HttpGet("Removidos")]
        public async Task<IEnumerable<CondominioFlat>> ObterRemovidos()
        {
            return await _condominioQuery.ObterRemovidos();
        }

                



        [HttpPost]
        public async Task<ActionResult> Post(CadastraCondominioViewModel condominioVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new CadastrarCondominioCommand(
                 condominioVM.Cnpj, condominioVM.Nome, condominioVM.Descricao, condominioVM.LogoMarca,
                 condominioVM.NomeOriginal, condominioVM.Telefone, condominioVM.Logradouro, condominioVM.Complemento,
                 condominioVM.Numero, condominioVM.Cep, condominioVM.Bairro, condominioVM.Cidade, condominioVM.Estado,
                 condominioVM.RefereciaId, condominioVM.LinkGeraBoleto, condominioVM.BoletoFolder, condominioVM.UrlWebServer,
                 condominioVM.Portaria, condominioVM.PortariaMorador, condominioVM.Classificado, condominioVM.ClassificadoMorador,
                 condominioVM.Mural, condominioVM.MuralMorador, condominioVM.Chat, condominioVM.ChatMorador, condominioVM.Reserva,
                 condominioVM.ReservaNaPortaria, condominioVM.Ocorrencia, condominioVM.OcorrenciaMorador, condominioVM.Correspondencia,
                 condominioVM.CorrespondenciaNaPortaria, condominioVM.LimiteTempoReserva);
                       

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);          
        }

        [HttpPut]
        public async Task<ActionResult> Put(AlteraCondominioViewModel AlteraCondominioVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AlterarCondominioCommand(
                 AlteraCondominioVM.CodominioId, AlteraCondominioVM.Cnpj, AlteraCondominioVM.Nome,
                 AlteraCondominioVM.Descricao, AlteraCondominioVM.LogoMarca, AlteraCondominioVM.NomeOriginal,
                 AlteraCondominioVM.Telefone, AlteraCondominioVM.Logradouro, AlteraCondominioVM.Complemento,
                 AlteraCondominioVM.Numero, AlteraCondominioVM.Cep, AlteraCondominioVM.Bairro, 
                 AlteraCondominioVM.Cidade, AlteraCondominioVM.Estado);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);                      
        }

        [HttpPut("Configuracao")]
        public async Task<ActionResult> Put(AlteraConfiguracaoCondominioViewModel AlteraCondominioVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);


            var comando = new AlterarConfiguracaoCondominioCommand(
                 AlteraCondominioVM.CodominioId, AlteraCondominioVM.Portaria, AlteraCondominioVM.PortariaMorador,
                 AlteraCondominioVM.Classificado, AlteraCondominioVM.ClassificadoMorador, AlteraCondominioVM.Mural,
                 AlteraCondominioVM.MuralMorador, AlteraCondominioVM.Chat, AlteraCondominioVM.ChatMorador, 
                 AlteraCondominioVM.Reserva, AlteraCondominioVM.ReservaNaPortaria, AlteraCondominioVM.Ocorrencia,
                 AlteraCondominioVM.OcorrenciaMorador, AlteraCondominioVM.Correspondencia, 
                 AlteraCondominioVM.CorrespondenciaNaPortaria, AlteraCondominioVM.LimiteTempoReserva);          
                    

            return CustomResponse(await _mediatorHandler.EnviarComando(comando));
        }

        [HttpDelete("{Id:Guid}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
           var comando = new RemoverCondominioCommand(Id);

           var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }       



    }
}
