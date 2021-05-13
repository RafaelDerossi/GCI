﻿using AutoMapper;
using CondominioApp.Core.Mediator;
using CondominioApp.Principal.Aplication;
using CondominioApp.Principal.Aplication.Commands;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Principal.Aplication.ViewModels;
using CondominioApp.Principal.Domain;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("api/Contrato")]
    public class ContratoController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IPrincipalQuery _principalQuery;
        public readonly IMapper _mapper;
        public ContratoController(IMediatorHandler mediatorHandler, IPrincipalQuery principalQuery, IMapper mapper)
        {
            _mediatorHandler = mediatorHandler;
            _principalQuery = principalQuery;
            _mapper = mapper;
        }



        [HttpGet("{Id:Guid}")]
        public async Task<ActionResult<ContratoViewModel>> ObterPorId(Guid Id)
        {
            var contrato = await _principalQuery.ObterContratoPorId(Id);
            if (contrato == null)
            {
                AdicionarErroProcessamento("Contrato não encontrado.");
                return CustomResponse();
            }
            return _mapper.Map<ContratoViewModel>(contrato);
        }

        [HttpGet("por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<ContratoViewModel>>> ObterPorCondominio(Guid condominioId)
        {
            var contratos = await _principalQuery.ObterContratosPorCondominio(condominioId);
            if (contratos.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }
            var contratosVM = new List<ContratoViewModel>();
            foreach (Contrato item in contratos)
            {
                var contratoVM = _mapper.Map<ContratoViewModel>(item);
                contratosVM.Add(contratoVM);
            }
            return contratosVM;           
        }




        [HttpPost]
        public async Task<ActionResult> Post(AdicionaContratoViewModel contratoVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AdicionarContratoCommand(
                 contratoVM.CondominioId, contratoVM.DataDaAssinatura, contratoVM.TipoPlano, contratoVM.Descricao,
                 contratoVM.Ativo, contratoVM.LinkContrato);
                       

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);          
        }

        [HttpPut]
        public async Task<ActionResult> Put(AtualizaContratoViewModel editaContratoVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AtualizarContratoCommand
                (editaContratoVM.Id, editaContratoVM.DataDaAssinatura, editaContratoVM.TipoPlano,
                editaContratoVM.Descricao, editaContratoVM.Ativo, editaContratoVM.LinkContrato);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpDelete("{Id:Guid}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            var comando = new ApagarContratoCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

    }
}
