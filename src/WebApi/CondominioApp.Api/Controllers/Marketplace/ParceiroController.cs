using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CondominioApp.WebApi.Core.Controllers;
using CondominioAppMarketplace.App.Interfaces;
using CondominioAppMarketplace.App.Model;
using CondominioAppMarketplace.App.ViewModel;
using CondominioAppMarketplace.Domain;
using FluentValidation.Results;
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

        [HttpGet("criar-identidade")]
        public async Task<ValidationResult> criarIdentidade()
        {
            var parceiros = await _AppService.ObterAtivos();

            var listaDeDtos = new List<UsuarioDTO>();

            foreach (var parceiro in parceiros)
            {
                listaDeDtos.Add(new UsuarioDTO()
                {
                    Email = parceiro.EmailDoResponsavel,
                    Id = parceiro.ParceiroId,
                    UserName = parceiro.NomeDoResponsavel
                });
            }

            var Http = new HttpClient();

            var conteudo = ObterConteudo(listaDeDtos);
            
            var response = await Http.PostAsync("https://localhost:5001/api/identidade/nova-identidade", conteudo);

            return await DeserializarObjetoResponse<ValidationResult>(response);
        }


        [HttpGet("obter-ativos")]
        public async Task<IEnumerable<ParceiroViewModel>> ObterAtivos()
        {
            return await _AppService.ObterAtivos();
        }


        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] ParceiroViewModel ViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _AppService.Atualizar(ViewModel));           
        }

        [HttpPut("limpar-logoMarca/{Id:Guid}")]
        public async Task<IActionResult> LimparLogoMarca(Guid Id)
        {
            return CustomResponse(await _AppService.LimparLogoMarca(Id));
        }

        [HttpPut("desativar-precadastro/{Id:Guid}")]
        public async Task<IActionResult> DesativarPreCadastro(Guid Id)
        {
            return CustomResponse(await _AppService.DesativarPreCadastro(Id));
        }

        [HttpPut("atualizar-cnpj")]
        public async Task<IActionResult> AtualizarCnpj([FromBody] ParceiroCnpjModel Model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _AppService.AtualizarCnpj(Model));
           
        }

        [HttpPut("atualizar-logomarca")]
        public async Task<IActionResult> AtualizarLogoMarca([FromBody] ParceiroLogoMarcaModel Model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _AppService.AtualizarLogoMarca(Model));
           
        }        

        [HttpPut("atualizar-contrato")]
        public async Task<IActionResult> AtualizarContrato([FromBody] ContratoModel Model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _AppService.AtualizarContrato(Model));
           
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] ParceiroViewModel ViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _AppService.Adicionar(ViewModel));
        }

        [HttpPost("contratar-vendedor")]
        public async Task<IActionResult> ContratarVendedor(VendedorViewModel ViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _AppService.ContratarVendedor(ViewModel));
        }

        [HttpDelete("{Id:Guid}")]
        public async Task<IActionResult> RemoverParceiro(Guid Id)
        {
            return CustomResponse(await _AppService.RemoverParceiro(Id));
        }
    }
}
