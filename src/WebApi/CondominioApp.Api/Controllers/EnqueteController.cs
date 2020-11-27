using CondominioApp.Core.Mediator;
using CondominioApp.Enquetes.App.Aplication.Commands;
using CondominioApp.Enquetes.App.ViewModels;
using CondominioApp.Principal.Aplication.Commands;
using CondominioApp.Principal.Aplication.ViewModels;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("api/grupo")]
    public class EnqueteController : MainController
    {

        private readonly IMediatorHandler _mediatorHandler;
        

        public EnqueteController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;           
        }


        //[HttpGet("{id:Guid}")]
        //public async Task<GrupoFlat> ObterGrupoPorId(Guid id)
        //{
        //    return await _condominioQuery.ObterGrupoPorId(id);
        //}

        //[HttpGet("por-condominio/{condominioId:Guid}")]
        //public async Task<IEnumerable<GrupoFlat>> ObterGruposPorCondominio(Guid condominioId)
        //{
        //    return await _condominioQuery.ObterGruposPorCondominio(condominioId);
        //}



        [HttpPost]
        public async Task<ActionResult> Post(CadastraEnqueteViewModel enqueteVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new CadastrarEnqueteCommand(
                 enqueteVM.Descricao, enqueteVM.DataInicio, enqueteVM.DataFim,
                 enqueteVM.CondominioId, enqueteVM.CondominioNome,
                 enqueteVM.UsuarioId, enqueteVM.UsuarioNome,
                 enqueteVM.ApenasProprietarios, enqueteVM.Alternativas);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        //[HttpPut]
        //public async Task<ActionResult> Put(AlteraGrupoViewModel grupoVM)
        //{
        //    if (!ModelState.IsValid) return CustomResponse(ModelState);

        //    var comando = new AlterarGrupoCommand(
        //        grupoVM.GrupoId, grupoVM.Descricao);


        //    var Resultado = await _mediatorHandler.EnviarComando(comando);

        //    return CustomResponse(Resultado);

        //}

        //[HttpDelete("{Id:Guid}")]
        //public async Task<ActionResult> DeleteGrupo(Guid Id)
        //{
        //    var comando = new RemoverGrupoCommand(Id);

        //    var Resultado = await _mediatorHandler.EnviarComando(comando);

        //    return CustomResponse(Resultado);
        //}

       
    }
}
