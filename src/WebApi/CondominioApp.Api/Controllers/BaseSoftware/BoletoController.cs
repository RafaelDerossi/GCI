using System;
using System.Threading.Tasks;
using CondominioApp.BS.App.Model;
using CondominioApp.BS.App.Services.Interfaces;
using CondominioApp.BS.CompiladorDeDados.ValueObjects;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CondominioApp.Api.Controllers.BaseSoftware
{
    [Route("api/bs/boleto")]
    public class BoletoController : MainController
    {
        private readonly IBoletoService _boletoService;

        private readonly IHostingEnvironment _hostingEnvironment;

        public BoletoController(IBoletoService boletoService, IHostingEnvironment hostingEnvironment)
        {
            _boletoService = boletoService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("{cpf}")]
        public IActionResult ObterPorCpf(string cpf, string Administradora)
        {
            try
            {
                var Caminho = _hostingEnvironment.ContentRootPath;

                var Cpf = new Cpf(cpf);
                var boleto = _boletoService.ObterBoletosDoCpf(Caminho,Cpf.ObterNumeroFormatado(), Administradora);
                var modelBoleto = new SegundaViaDeBoletoModel();

                modelBoleto.BOLETO.Add(new BoletoModel(boleto.Id.ToString(), Caminho, boleto.ValorDoc,
                    boleto.CodeBarra, boleto.Beneficiario,
                    boleto.BeneficiarioCnpj, boleto.Pagador, boleto.DataDoc, boleto.Mensagem, boleto.UrlBoleto));
                
                return Ok(modelBoleto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}