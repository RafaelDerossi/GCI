﻿using CondominioApp.Core.Mediator;
using CondominioApp.Principal.Aplication.Commands;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Principal.Aplication.ViewModels;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("api/grupo")]
    public class GrupoController : MainController
    {

        private readonly IMediatorHandler _mediatorHandler;
        private readonly IPrincipalQuery _principalQuery;

        public GrupoController(IMediatorHandler mediatorHandler, IPrincipalQuery principalQuery)
        {
            _mediatorHandler = mediatorHandler;
            _principalQuery = principalQuery;
        }


        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<GrupoFlat>> ObterGrupoPorId(Guid id)
        {
            var grupo = await _principalQuery.ObterGrupoPorId(id);
            if (grupo == null)
            {
                AdicionarErroProcessamento("Grupo não encontrado.");
                return CustomResponse();
            }
            return grupo;
        }

        [HttpGet("por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<GrupoFlat>>> ObterGruposPorCondominio(Guid condominioId)
        {
            var grupos = await _principalQuery.ObterGruposPorCondominio(condominioId);
            if (grupos.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }
            return grupos.ToList();
        }



        [HttpPost]
        public async Task<ActionResult> Post(AdicionaGrupoViewModel grupoVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AdicionarGrupoCommand(
                 grupoVM.Descricao, grupoVM.CondominioId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        [HttpPut]
        public async Task<ActionResult> Put(AtualizaGrupoViewModel grupoVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AtualizarGrupoCommand(
                grupoVM.Id, grupoVM.Descricao);


            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        [HttpDelete("{Id:Guid}")]
        public async Task<ActionResult> DeleteGrupo(Guid Id)
        {
            var comando = new ApagarGrupoCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

       
    }
}
