using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CondominioApp.WebApi.Core.Controllers;
using CondominioAppMarketplace.App.Interfaces;
using CondominioAppMarketplace.App.Model;
using CondominioAppMarketplace.App.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CondominioApp.Api.Controllers.Marketplace
{
    [Route("api/marketplace/parceiro")]
    [ApiController]
    public class ParceiroController : MainController
    {
        private readonly IAppServiceParceiro _AppService;

        public ParceiroController(IAppServiceParceiro AppService)
        {
            _AppService = AppService;
        }

        [HttpGet]
        public async Task<IEnumerable<ParceiroViewModel>> Listar()
        {
            return await _AppService.ObterTodos();
        }

        [HttpGet("Obter-Ativos")]
        public async Task<IEnumerable<ParceiroViewModel>> ObterAtivos()
        {
            return await _AppService.ObterAtivos();
        }



        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] ParceiroViewModel ViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _AppService.Adicionar(ViewModel));           
        }

        [HttpPost("Contratar-Vendedor")]
        public async Task<IActionResult> ContratarVendedor(VendedorViewModel ViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _AppService.ContratarVendedor(ViewModel));
        }    

       


        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] ParceiroViewModel ViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _AppService.Atualizar(ViewModel));           
        }

        [HttpPut("Limpar-LogoMarca/{Id:Guid}")]
        public async Task<IActionResult> LimparLogoMarca(Guid Id)
        {
            return CustomResponse(await _AppService.LimparLogoMarca(Id));
        }

        [HttpPut("Desativar-PreCadastro/{Id:Guid}")]
        public async Task<IActionResult> DesativarPreCadastro(Guid Id)
        {
            return CustomResponse(await _AppService.DesativarPreCadastro(Id));
        }

        [HttpPut("Atualizar-Cnpj")]
        public async Task<IActionResult> AtualizarCnpj([FromBody] ParceiroCnpjModel Model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _AppService.AtualizarCnpj(Model));
           
        }

        [HttpPut("Atualizar-LogoMarca")]
        public async Task<IActionResult> AtualizarLogoMarca([FromBody] ParceiroLogoMarcaModel Model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _AppService.AtualizarLogoMarca(Model));
           
        }        

        [HttpPut("Atualizar-Contrato")]
        public async Task<IActionResult> AtualizarContrato([FromBody] ContratoModel Model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _AppService.AtualizarContrato(Model));
           
        }
        


        [HttpDelete("{Id:Guid}")]
        public async Task<IActionResult> RemoverParceiro(Guid Id)
        {
            return CustomResponse(await _AppService.RemoverParceiro(Id));
        }
    }
}
