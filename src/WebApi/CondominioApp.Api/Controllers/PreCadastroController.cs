using CondominioApp.Core.Mediator;
using CondominioApp.WebApi.Core.Controllers;
using CondominioAppPreCadastro.App.Aplication.Commands;
using CondominioAppPreCadastro.App.Aplication.Query;
using CondominioAppPreCadastro.App.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("/api/precadastro")]
    public class PreCadastroController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IQueryLead _queryLead;

        public PreCadastroController(IMediatorHandler mediatorHandler, IQueryLead queryLead)
        {
            _mediatorHandler = mediatorHandler;
            _queryLead = queryLead;
        }


        [HttpGet]
        public async Task<IEnumerable<LeadViewModel>> ObterTodos()
        {
            return await _queryLead.ObterTodos();
        }

        [HttpGet("{Id:Guid}")]
        public async Task<LeadViewModel> ObterPorId(Guid Id)
        {
            return await _queryLead.ObterPorId(Id);
        }

        [HttpGet("Intervalo")]
        public async Task<IEnumerable<LeadViewModel>> Intervalo(DateTime DataInicio, DateTime DataFim)
        {
            return await _queryLead.ObterPorDatas(DataInicio, DataFim);
        }

        [HttpGet("Pendentes")]
        public async Task<IEnumerable<LeadViewModel>> Pendentes()
        {
            return await _queryLead.ObterPendentes();
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

        [HttpPost("transferir")]
        public async Task<IActionResult> Transferir(TransferenciaModel model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new TransferirCondominioCommand(model.LeadId,model.CondominioId);

            var resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(resultado);
        }
    }
}