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
    [Route("api/marketplace/vendedor")]
    [ApiController]
    public class VendedorController : MainController
    {
        private readonly IAppServiceParceiro _AppServiceParceiro;

        public VendedorController(IAppServiceParceiro AppServiceParceiro)
        {
            _AppServiceParceiro = AppServiceParceiro;
        }

        [HttpGet]
        public async Task<IEnumerable<VendedorViewModel>> Listar()
        {
            return await _AppServiceParceiro.ObterTodosVendedores();
        }

        [HttpGet("Obter-Por-Parceiro/{parceiroId:Guid}")]
        public async Task<IEnumerable<VendedorViewModel>> ObterPorParceiro(Guid parceiroId)
        {
            return await _AppServiceParceiro.ObterVendedoresDoParceiro(parceiroId);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] VendedorAlterarViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _AppServiceParceiro.AtualizarVendedor(viewModel));           
        }

    }
}
