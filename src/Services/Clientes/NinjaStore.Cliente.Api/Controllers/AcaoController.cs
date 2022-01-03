using GCI.Core.Mediator;
using GCI.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GCI.Acoes.Aplication.Query;
using GCI.Acoes.Aplication.ViewModels;
using GCI.Acoes.Aplication.Commands;
using GCI.Acoes.Domain.FlatModel;

namespace GCI.Acoes.Api.Controllers
{
    [Route("api/acao")]
    public class AcaoController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;

        private readonly IAcaoQuery _acaoQuery;

        public AcaoController
            (IMediatorHandler mediatorHandler, IAcaoQuery acaoQuery)
        {
            _mediatorHandler = mediatorHandler;
            _acaoQuery = acaoQuery;
        }


        /// <summary>
        /// Retorna ação por código;
        /// </summary>
        /// <param name="codigo">Código da ação</param>
        /// <response code="200">
        /// Id: Guid do ação;   
        /// DataDeCadastro: Data em que a ação foi cadastrada;   
        /// DataDeCadastroFormatada: Data formatada para exibição em que a ação foi cadastrada;   
        /// DataDeAlteracao:  Data em que a ação foi alterada;   
        /// DataDeAlteracaoFormatada: Data formatada para exibição em que a ação foi alterada;           
        /// Codigo: Código da ação;           
        /// RazaoSocial: Razão Social;   
        /// </response>
        [HttpGet("por-codigo/{codigo}")]
        public async Task<ActionResult<AcaoViewModel>> ObterPorCodigo(string codigo)
        {
            var acao = await _acaoQuery.ObterPorCodigo(codigo);
            if (acao == null)
                return CustomResponse("Nenhuma ação encontrada.");

            return AcaoViewModel.Mapear(acao);
        }

        /// <summary>
        /// Retorna todos os cliente cadastrados;
        /// </summary>
        /// <response code="200">
        /// Id: Guid do cliente;   
        /// DataDeCadastro: Data em que o cliente foi cadastrado;   
        /// DataDeCadastroFormatada: Data formatada para exibição em que o cliente foi cadastrado;   
        /// DataDeAlteracao:  Data em que o cliente foi alterado;   
        /// DataDeAlteracaoFormatada: Data formatada para exibição em que o cliente foi alterado;   
        /// Lixeira: Informa se o cliente esta na lixeira;   
        /// Nome: Nome do cliente;   
        /// Email: Endereço de e-mail do cliente;   
        /// Aldeia: Aldeia do cliente;   
        /// </response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcaoViewModel>>> ObterTodos()
        {
            var clientes = await _acaoQuery.ObterTodos();
            if (clientes.Count() == 0)
                return CustomResponse("Nenhum cliente encontrado.");

            return clientes.Select(AcaoViewModel.Mapear).ToList();
        }


        /// <summary>
        /// Adiciona um novo cliente
        /// </summary>
        /// <param name="viewModel">
        /// Nome: Nome do cliente (Obrigatório)(De 1 a 200 caracteres);             
        /// Email: Endereço de e-mail do cliente (Obrigatório);   
        /// Aldeia: Aldeia do cliente (Obrigatório)(De 1 a 200 caracteres);   
        /// </param>        
        [HttpPost]
        public async Task<ActionResult> Post(AdicionaAcaoViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AdicionarAcaoCommand
                (viewModel.Codigo, viewModel.Email, viewModel.RazaoSocial);           

            return CustomResponse(await _mediatorHandler.EnviarComando(comando));
        }        
    }
}
