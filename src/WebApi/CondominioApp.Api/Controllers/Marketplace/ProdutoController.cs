using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CondominioApp.WebApi.Core.Controllers;
using CondominioAppMarketplace.App.Interfaces;
using CondominioAppMarketplace.App.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CondominioApp.Api.Controllers.Marketplace
{
    [Route("api/marketplace/produto")]
    [ApiController]
    public class ProdutoController : MainController
    {
        private readonly IAppServiceItemDeVenda _AppServiceItemDeVenda;
        private readonly IAppServiceProduto _AppServiceProduto;

        public ProdutoController(IAppServiceItemDeVenda AppServiceItemDeVenda,
                                 IAppServiceProduto AppServiceProduto)
        {
            _AppServiceItemDeVenda = AppServiceItemDeVenda;
            _AppServiceProduto = AppServiceProduto;
        }


        [HttpGet]
        public async Task<IEnumerable<ProdutoViewModel>> Listar()
        {
            return await _AppServiceProduto.ExibirCatalogo();
        }

        [HttpGet("{Id:Guid}")]
        public async Task<ProdutoViewModel> ObterPorId(Guid Id)
        {
            return await _AppServiceProduto.ObterPorId(Id);
        }

        [HttpGet("produtos-do-parceiro/{Id:Guid}")]
        public async Task<IEnumerable<ProdutoViewModel>> ObterProdutoDoParceiro(Guid Id)
        {
            return await _AppServiceProduto.ObterProdutoDoParceiro(Id);
        }

        [HttpGet("vitrine")]
        public async Task<IEnumerable<ItemDaVitrineViewModel>> Vitrine()
        {
            return await _AppServiceItemDeVenda.ObterTodos();
        }

        [HttpGet("obter-produto-da-vitrine/{itemDeVendaId:Guid}")]
        public async Task<ItemDaVitrineViewModel> ObterProdutoDaVitrine(Guid itemDeVendaId)
        {
            return await _AppServiceItemDeVenda.ObterItemDaVitrine(itemDeVendaId);
        }

        [HttpGet("vitrine-do-parceiro/{parceiroId:Guid}")]
        public async Task<IEnumerable<ItemDaVitrineViewModel>> VitrineDoParceiro(Guid parceiroId)
        {
            return await _AppServiceItemDeVenda.ObterPorParceiroId(parceiroId);
        }

        [HttpGet("vitrine-do-vendedor/{vendedorId:Guid}")]
        public async Task<IEnumerable<ItemDaVitrineViewModel>> VitrineDoVendedor(Guid vendedorId)
        {
            return await _AppServiceItemDeVenda.ObterPorVendedorId(vendedorId);
        }     

        [HttpGet("produto-aleatorio-da-vitrine")]
        public async Task<ItemDaVitrineViewModel> ProdutoAleatorioDaVitrine()
        {
            return await _AppServiceItemDeVenda.ProdutoAleatorioDaVitrine();
        }



        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] ProdutoViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _AppServiceProduto.Adicionar(viewModel));
        }

        [HttpPost("expor-produto-na-vitrine")]
        public async Task<IActionResult> ExporProdutoNaVitrine([FromBody] ItemDeVendaViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _AppServiceItemDeVenda.ExporItemNaVitrine(viewModel));
        }

        [HttpPost("marcar-foto-principal")]
        public async Task<IActionResult> MarcarFotoPrincipal([FromBody] FotoPrincipalViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _AppServiceProduto.MarcarFotoPrincipal(viewModel));
        }



        [HttpPut("contabilizar-cliques/{itemDeVendaId:Guid}")]
        public async Task<IActionResult> ContabilizarCliques(Guid itemDeVendaId)
        {
            return CustomResponse(await _AppServiceItemDeVenda.ContarClique(itemDeVendaId));
        }

        [HttpPut("remover-produto-da-vitrine/{itemDeVendaId:Guid}")]
        public async Task<IActionResult> RemoverProdutoDaVitrine(Guid itemDeVendaId)
        {
            return CustomResponse(await _AppServiceItemDeVenda.RemoverDaVitrine(itemDeVendaId));
        }

        [HttpPut("restaurar-produtos-da-vitrine/{parceiroId:Guid}")]
        public async Task<IActionResult> RestauraProdutosDaVitrine(Guid parceiroId)
        {
            return CustomResponse(await _AppServiceItemDeVenda.RestauraProdutosDaVitrine(parceiroId));            
        }

        [HttpPut("atualizar-produto")]
        public async Task<IActionResult> AtualizarProduto([FromBody] ProdutoViewModel viewModel)
        {
            return CustomResponse(await _AppServiceProduto.Atualizar(viewModel));
        }
    }
}
