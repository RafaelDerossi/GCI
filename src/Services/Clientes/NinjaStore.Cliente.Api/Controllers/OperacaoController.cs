using GCI.Core.Mediator;
using GCI.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GCI.Acoes.Aplication.Query;
using GCI.Acoes.Aplication.Commands;
using GCI.Acoes.Domain.FlatModel;
using GCI.Core.Enumeradores;

namespace GCI.Acoes.Api.Controllers
{
    [Route("api/operacao")]
    public class OperacaoController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;

        private readonly IOperacaoQuery _operacaoQuery;        

        public OperacaoController(IMediatorHandler mediatorHandler, IOperacaoQuery operacaoQuery)
        {
            _mediatorHandler = mediatorHandler;
            _operacaoQuery = operacaoQuery;
        }
       
        /// <summary>
        /// Retorna operações por código
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("por-codigo/{codigo}")]
        public async Task<ActionResult<IEnumerable<OperacaoViewModel>>> ObterOperacoesPorCodigo(string codigo)
        {
            var operacoes = await _operacaoQuery.ObterPorCodigo(codigo);
            if (operacoes == null)
                return CustomResponse("Nenhuma operação encontrada.");

            return operacoes.Select(OperacaoViewModel.Mapear).ToList();
        }

        /// <summary>
        /// Retorna todas as operações
        /// </summary>        
        [HttpGet("todas")]
        public async Task<ActionResult<IEnumerable<OperacaoViewModel>>> ObterTodasOperacoes()
        {
            var operacoes = await _operacaoQuery.ObterTodas();
            if (operacoes == null)
                return CustomResponse("Nenhuma operação encontrada.");

            return operacoes.Select(OperacaoViewModel.Mapear).ToList();
        }


        /// <summary>
        /// Adiciona uma nova operação de compra
        /// </summary>
        /// <param name="viewModel">
        /// CodigoDaAcao: Código da Ação (Obrigatório);                     
        /// Preco: Preço da Ação (Obrigatório);   
        /// Quantidade: (Obrigatório);   
        /// Data da Compra: (Obrigatório);   
        /// </param>        
        [HttpPost("compra")]
        public async Task<ActionResult> PostCompra(AdicionaOperacaoViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AdicionarOperacaoCommand
                (viewModel.CodigoDaAcao, viewModel.Preco, viewModel.Quantidade,
                 viewModel.DataDaOperacao, TipoOperacao.COMPRA);

            return CustomResponse(await _mediatorHandler.EnviarComando(comando));
        }

        /// <summary>
        /// Adiciona uma nova operação de venda
        /// </summary>
        /// <param name="viewModel">
        /// CodigoDaAcao: Código da Ação (Obrigatório);                     
        /// Preco: Preço da Ação (Obrigatório);   
        /// Quantidade: (Obrigatório);   
        /// Data da Venda: (Obrigatório);   
        /// </param>        
        [HttpPost("venda")]
        public async Task<ActionResult> PostVenda(AdicionaOperacaoViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AdicionarOperacaoCommand
                (viewModel.CodigoDaAcao, viewModel.Preco, viewModel.Quantidade,
                 viewModel.DataDaOperacao, TipoOperacao.VENDA);

            return CustomResponse(await _mediatorHandler.EnviarComando(comando));
        }
    }
}
