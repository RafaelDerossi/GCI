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
    [Route("api/Contrato")]
    public class ContratoController : MainController
    {

        private readonly IMediatorHandler _mediatorHandler;
        private readonly ICondominioQuery _condominioQuery; 
        public ContratoController(IMediatorHandler mediatorHandler, ICondominioQuery condominioQuery)
        {
            _mediatorHandler = mediatorHandler;
            _condominioQuery = condominioQuery;
        }



        //[HttpGet]
        //public async Task<IEnumerable<CondominioFlat>> ObterTodos()
        //{
        //    return await _condominioQuery.ObterTodos();
        //}

        //[HttpGet("{Id:Guid}")]
        //public async Task<CondominioFlat> ObterPorId(Guid Id)
        //{
        //    return await _condominioQuery.ObterPorId(Id);
        //}
          
        //[HttpGet("Removidos")]
        //public async Task<IEnumerable<CondominioFlat>> ObterRemovidos()
        //{
        //    return await _condominioQuery.ObterRemovidos();
        //}
                



        [HttpPost]
        public async Task<ActionResult> Post(CadastraContratoViewModel contratoVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new CadastrarContratoCommand(
                 contratoVM.CondominioId, contratoVM.DataDaAssinatura, contratoVM.TipoPlano, contratoVM.Descricao,
                 contratoVM.Ativo, contratoVM.LinkContrato);
                       

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);          
        }

        [HttpPut]
        public async Task<ActionResult> Put(EditaContratoViewModel editaContratoVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new EditarContratoCommand
                (editaContratoVM.Id, editaContratoVM.DataDaAssinatura, editaContratoVM.TipoPlano,
                editaContratoVM.Descricao, editaContratoVM.Ativo, editaContratoVM.LinkContrato);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpDelete("{Id:Guid}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            var comando = new RemoverContratoCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

    }
}
