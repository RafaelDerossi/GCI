using System;
using System.Threading.Tasks;
using CondominioApp.BS.App.Model;
using CondominioApp.BS.App.Services.Interfaces;
using CondominioApp.BS.CompiladorDeDados.ValueObjects;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CondominioApp.Api.Controllers.BaseSoftware
{
    [Route("api/bs/boleto")]
    public class BoletoController : MainController
    {
        private readonly IBoletoService _boletoService;

        public BoletoController(IBoletoService boletoService)
        {
            _boletoService = boletoService;
        }

        [HttpGet("{cpf}")]
        public IActionResult ObterPorCpf(string cpf, string Administradora)
        {
            try
            {
                var Cpf = new Cpf(cpf);
                var boleto = _boletoService.ObterBoletosDoCpf(Cpf.ObterNumeroFormatado(), Administradora);
                var modelBoleto = new SegundaViaDeBoletoModel();

                modelBoleto.BOLETO.Add(new BoletoModel(boleto.Id.ToString(), boleto.Vencimento, boleto.ValorDoc,
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