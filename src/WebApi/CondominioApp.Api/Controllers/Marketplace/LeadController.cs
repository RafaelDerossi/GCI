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
    [Route("api/marketplace/lead")]
    [ApiController]
    public class LeadController : MainController
    {
        private readonly IAppServiceLead _AppService;

        public LeadController(IAppServiceLead appService)
        {
            _AppService = appService;
        }

        [HttpGet]
        public async Task<IEnumerable<LeadMarketplaceViewModel>> ObterTodos()
        {
            return await _AppService.ObterTodos();
        }

        [HttpGet("Obter-Por-Vendedor/{vendedorId:Guid}")]
        public async Task<IEnumerable<LeadMarketplaceViewModel>> ObterPorVendedor(Guid vendedorId)
        {
            return await _AppService.ObterPorVendedor(vendedorId);
        }

        [HttpGet("Obter-Por-Parceiro/{parceiroId:Guid}")]
        public async Task<IEnumerable<LeadMarketplaceViewModel>> ObterPorParceiroId(Guid parceiroId)
        {
            return await _AppService.ObterPorParceiro(parceiroId);
        }

        [HttpPost]
        public async Task<IActionResult> EnviarLead(LeadNovoViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _AppService.EnviarLead(viewModel));           
        }
    }
}
