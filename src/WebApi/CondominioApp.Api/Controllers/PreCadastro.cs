using CondominioApp.Core.Mediator;
using CondominioAppPreCadastro.App.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CondominioApp.WebApi.Core.Controllers;
using CondominioAppPreCadastro.App.Aplication.Commands;

namespace CondominioApp.Api.Controllers
{
    [Route("/api/precadastro")]
    public class PreCadastro : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;

        public PreCadastro(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpPost]
        public async Task<IActionResult> NovoLead(LeadViewModel model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new InserirNovoLeadCommand(model.nome, model.email, model.telefone, model.plano,
                model.statusPreCadastro, model.motivoStatus, model.condominios);


            var resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(resultado);
        }
    }
}