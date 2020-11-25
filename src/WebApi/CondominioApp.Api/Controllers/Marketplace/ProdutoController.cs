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

        [HttpGet("Vitrine")]
        public async Task<IEnumerable<ItemDaVitrineViewModel>> Vitrine()
        {
            return await _AppServiceItemDeVenda.ObterTodos();
        }

        [HttpGet("Obter-Produto-Da-Vitrine/{itemDeVendaId:Guid}")]
        public async Task<ItemDaVitrineViewModel> ObterProdutoDaVitrine(Guid itemDeVendaId)
        {
            return await _AppServiceItemDeVenda.ObterItemDaVitrine(itemDeVendaId);
        }

        [HttpGet("Vitrine-Do-Parceiro/{parceiroId:Guid}")]
        public async Task<IEnumerable<ItemDaVitrineViewModel>> VitrineDoParceiro(Guid parceiroId)
        {
            return await _AppServiceItemDeVenda.ObterPorParceiroId(parceiroId);
        }

        [HttpGet("Vitrine-Do-Vendedor/{vendedorId:Guid}")]
        public async Task<IEnumerable<ItemDaVitrineViewModel>> VitrineDoVendedor(Guid vendedorId)
        {
            return await _AppServiceItemDeVenda.ObterPorVendedorId(vendedorId);
        }     

        [HttpGet("Produto-Aleatorio-Da-Vitrine")]
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

        [HttpPost("Expor-Produto-Na-Vitrine")]
        public async Task<IActionResult> ExporProdutoNaVitrine([FromBody] ItemDeVendaViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _AppServiceItemDeVenda.ExporItemNaVitrine(viewModel));
        }

        [HttpPost("Marcar-Foto-Principal")]
        public async Task<IActionResult> MarcarFotoPrincipal([FromBody] FotoPrincipalViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _AppServiceProduto.MarcarFotoPrincipal(viewModel));
        }



        [HttpPut("Contabilizar-Cliques/{itemDeVendaId:Guid}")]
        public async Task<IActionResult> ContabilizarCliques(Guid itemDeVendaId)
        {
            return CustomResponse(await _AppServiceItemDeVenda.ContarClique(itemDeVendaId));
        }

        [HttpPut("Remover-Produto-Da-Vitrine/{itemDeVendaId:Guid}")]
        public async Task<IActionResult> RemoverProdutoDaVitrine(Guid itemDeVendaId)
        {
            return CustomResponse(await _AppServiceItemDeVenda.RemoverDaVitrine(itemDeVendaId));
        }

        [HttpPut("Restaurar-Produtos-Da-Vitrine/{parceiroId:Guid}")]
        public async Task<IActionResult> RestauraProdutosDaVitrine(Guid parceiroId)
        {
            return CustomResponse(await _AppServiceItemDeVenda.RestauraProdutosDaVitrine(parceiroId));            
        } 

    }
}
