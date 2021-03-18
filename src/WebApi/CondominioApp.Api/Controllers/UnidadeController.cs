using CondominioApp.Core.Mediator;
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
using System.Linq;

namespace CondominioApp.Api.Controllers
{
    [Route("api/unidade")]
    public class UnidadeController : MainController
    {

        private readonly IMediatorHandler _mediatorHandler;
        private readonly IPrincipalQuery _principalQuery;

        public UnidadeController(IMediatorHandler mediatorHandler, IPrincipalQuery principalQuery)
        {
            _mediatorHandler = mediatorHandler;
            _principalQuery = principalQuery;
        }



        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<UnidadeFlat>> ObterUnidadePorId(Guid id)
        {
            var unidade = await _principalQuery.ObterUnidadePorId(id);
            if (unidade == null)
            {
                AdicionarErroProcessamento("Unidade não encontrada.");
                return CustomResponse();
            }
            return unidade;
        }

        [HttpGet("por-grupo/{grupoId:Guid}")]
        public async Task<ActionResult<IEnumerable<UnidadeFlat>>> ObterUnidadesPorGrupo(Guid grupoId)
        {            
            var unidades = await _principalQuery.ObterUnidadesPorGrupo(grupoId);
            if (unidades.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }
            return unidades.ToList();
        }

        [HttpGet("por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<UnidadeFlat>>> ObterUnidadesPorCondominio(Guid condominioId)
        {            
            var unidades = await _principalQuery.ObterUnidadesPorCondominio(condominioId);
            if (unidades.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }
            return unidades.ToList();
        }

        [HttpGet("por-codigo/{codigo}")]
        public async Task<ActionResult<UnidadeFlat>> ObterUnidadesPorCodigo(string codigo)
        {
            var unidade = await _principalQuery.ObterUnidadePorCodigo(codigo);
            if (unidade == null)
            {
                AdicionarErroProcessamento("Unidade não encontrada.");
                return CustomResponse();
            }
            return unidade;
        }


        [HttpPost]
        public async Task<ActionResult> Post(CadastraUnidadeViewModel unidadeVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
                        
            for (int i = unidadeVM.NumeroInicial; i <= unidadeVM.NumeroFinal; i++)
            {
                var comando = new CadastrarUnidadeCommand(
                 unidadeVM.Codigo, i.ToString(), unidadeVM.Andar,
                 unidadeVM.Vagas, unidadeVM.Telefone, unidadeVM.Ramal,
                 unidadeVM.Complemento, unidadeVM.GrupoId);

                var resultado = await _mediatorHandler.EnviarComando(comando);

                if (!resultado.IsValid)
                    CustomResponse(resultado);
            }            

            return CustomResponse();
            
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