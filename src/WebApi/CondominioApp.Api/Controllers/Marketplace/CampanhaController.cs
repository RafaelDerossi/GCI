using System;
using CondominioApp.WebApi.Core.Controllers;
using CondominioAppMarketplace.App.Interfaces;
using CondominioAppMarketplace.App.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers.Marketplace
{
    [Route("/api/marketplace/campanha")]
    public class CampanhaController : MainController
    {
        private readonly IAppServiceCampanha _AppService;

        public CampanhaController(IAppServiceCampanha appServiceCampanha)
        {
            _AppService = appServiceCampanha;
        }

        [HttpGet]
        public async Task<IEnumerable<CampanhaViewModel>> ObterCampanhas()
        {
            return await _AppService.CampanhasAtivas();
        }

        [HttpGet("expiradas")]
        public async Task<IEnumerable<CampanhaViewModel>> CampanhasExpiradas()
        {
            return await _AppService.CampanhasExpiradas();
        }

        [HttpGet("futuras")]
        public async Task<IEnumerable<CampanhaViewModel>> CampanhasFuturas()
        {
            return await _AppService.CampanhasFuturas();
        }


        [HttpGet("ativas-do-parceiro/{parceiroId:Guid}")]
        public async Task<IEnumerable<CampanhaViewModel>> CampanhasAtivasDoParceiro(Guid parceiroId)
        {
            return await _AppService.CampanhasAtivasDoParceiro(parceiroId);
        }

        [HttpGet("expiradas-do-parceiro/{parceiroId:Guid}")]
        public async Task<IEnumerable<CampanhaViewModel>> CampanhasExpiradasDoParceiro(Guid parceiroId)
        {
            return await _AppService.CampanhasExpiradasDoParceiro(parceiroId);
        }

        [HttpGet("futuras-do-parceiro/{parceiroId:Guid}")]
        public async Task<IEnumerable<CampanhaViewModel>> CampanhasFuturasDoParceiro(Guid parceiroId)
        {
            return await _AppService.CampanhasFuturasDoParceiro(parceiroId);
        }

        [HttpPost]
        public async Task<IActionResult> IniciarCampanha(CampanhaNovaViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _AppService.IniciarCampanha(viewModel));
        }

        [HttpPut("contabilizar-cliques/{Id:Guid}")]
        public async Task<IActionResult> ContabilizarCliques(Guid Id)
        {
            return Ok(await _AppService.ContabilizarCliques(Id));
        }

        [HttpPut("declinar-campanha/{Id:Guid}")]
        public async Task<IActionResult> DeclinarCampanha(Guid Id)
        {
            return Ok(await _AppService.DeclinarCampanha(Id));
        }

        [HttpPut("reconfigurar-intervalo/{Id:Guid}")]
        public async Task<IActionResult> ReconfigurarIntervalo(Guid Id, IntervaloDeCampanhaViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (Id != viewModel.CampanhaId) AdicionarErroProcessamento("Ids informados são diferentes!");

            return CustomResponse(await _AppService.ReconfigurarIntervalos(viewModel));
        }
    }
}