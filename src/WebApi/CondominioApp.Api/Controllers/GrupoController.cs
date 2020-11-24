using CondominioApp.Core.Mediator;
using CondominioApp.Principal.Aplication.Commands;
using CondominioApp.Principal.Aplication.ViewModels;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("api/grupo")]
    public class GrupoController : MainController
    {

        private readonly IMediatorHandler _mediatorHandler;

        public GrupoController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CadastraGrupoViewModel grupoVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new CadastrarGrupoCommand(
                 grupoVM.Descricao, grupoVM.CondominioId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        [HttpPut]
        public async Task<ActionResult> Put(AlteraGrupoViewModel grupoVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AlterarGrupoCommand(
                grupoVM.GrupoId, grupoVM.Descricao);


            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        [HttpDelete("{Id:Guid}")]
        public async Task<ActionResult> DeleteGrupo(Guid Id)
        {
            var comando = new RemoverGrupoCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

       
    }
}
