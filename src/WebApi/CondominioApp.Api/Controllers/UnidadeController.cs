﻿using CondominioApp.Core.Mediator;
using CondominioApp.Principal.Aplication.Commands;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Principal.Aplication.ViewModels;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace CondominioApp.Api.Controllers
{
    [Route("api/unidade")]
    public class UnidadeController : MainController
    {

        private readonly IMediatorHandler _mediatorHandler;
        private readonly ICondominioQuery _condominioQuery;

        public UnidadeController(IMediatorHandler mediatorHandler, ICondominioQuery condominioQuery)
        {
            _mediatorHandler = mediatorHandler;
            _condominioQuery = condominioQuery;
        }



        [HttpGet("{id:Guid}")]
        public async Task<UnidadeFlat> ObterUnidadePorId(Guid id)
        {
            return await _condominioQuery.ObterUnidadePorId(id);
        }

        [HttpGet("por-grupo/{grupoId:Guid}")]
        public async Task<IEnumerable<UnidadeFlat>> ObterUnidadesPorGrupo(Guid grupoId)
        {
            return await _condominioQuery.ObterUnidadesPorGrupo(grupoId);
        }

        [HttpGet("por-condominio/{condominioId:Guid}")]
        public async Task<IEnumerable<UnidadeFlat>> ObterUnidadesPorCondominio(Guid condominioId)
        {
            return await _condominioQuery.ObterUnidadesPorCondominio(condominioId);
        }



        [HttpPost]
        public async Task<ActionResult> Post(CadastraUnidadeViewModel unidadeVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var Resultado = new ValidationResult();
            for (int i = unidadeVM.NumeroInicial; i <= unidadeVM.NumeroFinal; i++)
            {
                var comando = new CadastrarUnidadeCommand(
                 unidadeVM.Codigo, i.ToString(), unidadeVM.Andar,
                 unidadeVM.Vagas, unidadeVM.Telefone, unidadeVM.Ramal,
                 unidadeVM.Complemento, unidadeVM.GrupoId);

                Resultado = await _mediatorHandler.EnviarComando(comando);

                if (!Resultado.IsValid)
                    CustomResponse(Resultado);
            }            

            return CustomResponse(Resultado);
            
        }


        [HttpPut("{Id:Guid}")]
        public async Task<ActionResult> Put(Guid Id, EditaUnidadeViewModel unidadeVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (Id != unidadeVM.Id)
            {
                AdicionarErroProcessamento("Id não confere!");
                return CustomResponse();
            }

            var comando = new EditarUnidadeCommand(
            unidadeVM.Id, unidadeVM.Numero, unidadeVM.Andar,
            unidadeVM.Vagas, unidadeVM.Telefone, unidadeVM.Ramal, unidadeVM.Complemento);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }


        [HttpPut("atualizar-codigo/{Id:Guid}")]
        public async Task<ActionResult> Put(Guid Id)
        {
            var comando = new ResetCodigoUnidadeCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }


        [HttpDelete("{Id:Guid}")]
        public async Task<ActionResult> DeleteUnidade(Guid Id)
        {
            var comando = new RemoverUnidadeCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

    }
}