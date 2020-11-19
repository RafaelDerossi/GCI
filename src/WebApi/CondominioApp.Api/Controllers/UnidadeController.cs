using CondominioApp.Core.Mediator;
using CondominioApp.Principal.Aplication.Commands;
using CondominioApp.Principal.Aplication.ViewModels;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("api/unidade")]
    [ApiController]
    public class UnidadeController : MainController
    {

        private readonly IMediatorHandler _mediatorHandler;

        public UnidadeController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

       
        [HttpPost]
        public async Task<ActionResult> Post(UnidadeViewModel unidadeVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new CadastrarUnidadeCommand(
                unidadeVM.Codigo, unidadeVM.Numero, unidadeVM.Andar,
                unidadeVM.Vagas, unidadeVM.Telefone, unidadeVM.Ramal, unidadeVM.Complemento,
                unidadeVM.GrupoId, unidadeVM.CondominioId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
            
        }


        [HttpPut]
        public async Task<ActionResult> Put(UnidadeViewModel unidadeVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AlterarUnidadeCommand(
            unidadeVM.UnidadeId, unidadeVM.Numero, unidadeVM.Andar,
            unidadeVM.Vagas, unidadeVM.Telefone, unidadeVM.Ramal, unidadeVM.Complemento,
            unidadeVM.GrupoId, unidadeVM.CondominioId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }


        [HttpPut("ResetCodigo/{Id:Guid}")]
        public async Task<ActionResult> Put(Guid Id)
        {
            var comando = new ResetCodigoUnidadeCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }


        [HttpDelete("{Id:Guid}")]
        public async Task<ActionResult> DeleteUnidade(Guid Id)
        {
            var comando = new RemoverUnidadeCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

    }
}
