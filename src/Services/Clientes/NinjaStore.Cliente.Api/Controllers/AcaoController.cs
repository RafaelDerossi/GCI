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

        private readonly ICotacaoDeAcaoQuery _cotacaoDeAcaoQuery;

        public AcaoController(IMediatorHandler mediatorHandler, IAcaoQuery acaoQuery, ICotacaoDeAcaoQuery cotacaoDeAcaoQuery)
        {
            _mediatorHandler = mediatorHandler;
            _acaoQuery = acaoQuery;
            _cotacaoDeAcaoQuery = cotacaoDeAcaoQuery;
        }

        [HttpGet("cotacao-por-codigo/{codigo}")]
        public async Task<ActionResult<IEnumerable<CotacaoViewModel>>> ObterCotacaoPorCodigo(string codigo)
        {
            var response = await _cotacaoDeAcaoQuery.ObterPorCodigo(codigo);
            if (response == null || response.QuoteResponse == null || response.QuoteResponse.Result.Count == 0)
                return CustomResponse("Nenhuma cotação encontrada.");                        

            return response.QuoteResponse.Result.Select(CotacaoViewModel.Mapear).ToList();
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
        /// Retorna todas as ações cadastradas;
        /// </summary>
        /// <response code="200">
        /// Id: Guid do ação;   
        /// DataDeCadastro: Data em que a ação foi cadastrada;   
        /// DataDeCadastroFormatada: Data formatada para exibição em que a ação foi cadastrada;   
        /// DataDeAlteracao:  Data em que a ação foi alterada;   
        /// DataDeAlteracaoFormatada: Data formatada para exibição em que a ação foi alterada;           
        /// Codigo: Código da ação;           
        /// RazaoSocial: Razão Social;   
        /// </response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcaoViewModel>>> ObterTodos()
        {
            var acoes = await _acaoQuery.ObterTodos();
            if (acoes.Count() == 0)
                return CustomResponse("Nenhuma ação encontrada.");

            return acoes.Select(AcaoViewModel.Mapear).ToList();
        }

        /// <summary>
        /// Retorna operações por código
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("operacoes-por-codigo/{codigo}")]
        public async Task<ActionResult<IEnumerable<OperacaoViewModel>>> ObterOperacoesPorCodigo(string codigo)
        {
            var operacoes = await _acaoQuery.ObterOperacoesPorCodigo(codigo);
            if (operacoes == null)
                return CustomResponse("Nenhuma operação encontrada.");

            return operacoes.Select(OperacaoViewModel.Mapear).ToList();
        }

        /// <summary>
        /// Retorna todas as operações
        /// </summary>        
        [HttpGet("operacoes-todas/{codigo}")]
        public async Task<ActionResult<IEnumerable<OperacaoViewModel>>> ObterTodasOperacoes()
        {
            var operacoes = await _acaoQuery.ObterTodasAsOperacoes();
            if (operacoes == null)
                return CustomResponse("Nenhuma operação encontrada.");

            return operacoes.Select(OperacaoViewModel.Mapear).ToList();
        }


        /// <summary>
        /// Adiciona uma nova ação
        /// </summary>
        /// <param name="viewModel">
        /// Codigo: Código da Ação (Obrigatório)(De 2 a 50 caracteres);                     
        /// Razão Social: Razão Social (Obrigatório)(De 2 a 300 caracteres);   
        /// </param>        
        [HttpPost]
        public async Task<ActionResult> Post(AdicionaAcaoViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AdicionarAcaoCommand
                (viewModel.Codigo, viewModel.RazaoSocial);           

            return CustomResponse(await _mediatorHandler.EnviarComando(comando));
        }        
    }
}
