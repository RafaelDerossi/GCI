﻿using CondominioApp.BS.App.Model;
using CondominioApp.BS.App.Services.Interfaces;
using CondominioApp.BS.CompiladorDeDados.ValueObjects;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CondominioApp.Api.Controllers.BaseSoftware
{
    [Route("api/bs/boleto")]
    public class BoletoController : MainController
    {
        private readonly IBoletoService _boletoService;

        private readonly IWebHostEnvironment _hostingEnvironment;

        public BoletoController(IBoletoService boletoService, IWebHostEnvironment hostingEnvironment)
        {
            _boletoService = boletoService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult ObterPorCpf(string cpf, string Administradora)
        {
            try
            {
                var Caminho = _hostingEnvironment.ContentRootPath;

                var Cpf = new Cpf(cpf);
                var boleto = _boletoService.ObterBoletosDoCpf(Caminho, Cpf.ObterNumeroFormatado(), Administradora);
                var modelBoleto = new SegundaViaDeBoletoModel();

                modelBoleto.BOLETO.Add(new BoletoModel(boleto.Id.ToString(),boleto.Vencimento, boleto.ValorDoc,
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