using CondominioApp.Core.Mediator;
using CondominioApp.Portaria.Aplication.Commands;
using CondominioApp.Portaria.Aplication.ViewModels;
using CondominioApp.Portaria.Aplication.Query;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CondominioApp.Portaria.Domain.FlatModel;
using System.Linq;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Principal.Domain.FlatModel;

namespace CondominioApp.Api.Controllers
{
    [Route("api/visitante")]
    public class VisitanteController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;      
        private readonly IPortariaQuery _portariaQuery;
        private readonly IPrincipalQuery _principalQuery;

        public VisitanteController(IMediatorHandler mediatorHandler, IPortariaQuery portariaQuery, IPrincipalQuery principalQuery)
        {
            _mediatorHandler = mediatorHandler;           
            _portariaQuery = portariaQuery;
            _principalQuery = principalQuery;            
        }


        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<VisitanteFlat>> ObterPorId(Guid id)
        {
            var visitante = await _portariaQuery.ObterPorId(id);
            if (visitante == null)
            {
                AdicionarErroProcessamento("Contrato não encontrado.");
                return CustomResponse();
            }
            return visitante;
        }

        [HttpGet("por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<VisitanteFlat>>> ObterPorCondominio(Guid condominioId)
        {
            var visitantes = await _portariaQuery.ObterVisitantesPorCondominio(condominioId);
            if (visitantes.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }
            return visitantes.ToList();
        }

        [HttpGet("por-unidade/{unidadeId:Guid}")]
        public async Task<ActionResult<IEnumerable<VisitanteFlat>>> ObterPorUnidade(Guid unidadeId)
        {
            var visitantes = await _portariaQuery.ObterVisitantesPorUnidade(unidadeId);
            if (visitantes.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }
            return visitantes.ToList();
        }

        [HttpGet("por-documento/{documento}")]
        public async Task<ActionResult<IEnumerable<VisitanteFlat>>> ObterPorDocumento(string documento)
        {
            var visitantes = await _portariaQuery.ObterVisitantesPorDocumento(documento);
            if (visitantes.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }
            return visitantes.ToList();
        }



        [HttpPost]
        public async Task<ActionResult> Post(AdicionaVisitanteViewModel visitanteVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var unidade = await _principalQuery.ObterUnidadePorId(visitanteVM.UnidadeId);
            if (unidade == null)
            {
                AdicionarErroProcessamento("Unidade não encontrada!");
                return CustomResponse();
            }

            var comando = AdicionarVisitantePorMoradorCommandFactory(visitanteVM, unidade);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut]
        public async Task<ActionResult> Put(AtualizaVisitanteViewModel visitanteVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = AtualizarVisitantePorMoradorCommandFactory(visitanteVM);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpDelete("{Id:Guid}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            var comando = new ApagarVisitanteCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }



        private AdicionarVisitantePorMoradorCommand AdicionarVisitantePorMoradorCommandFactory
            (AdicionaVisitanteViewModel viewModel, UnidadeFlat unidade)
        {
            return new AdicionarVisitantePorMoradorCommand(
                  viewModel.Nome, viewModel.TipoDoDocumento, viewModel.Documento, viewModel.Email, viewModel.Foto,
                  viewModel.NomeOriginalFoto, unidade.CondominioId, unidade.CondominioNome,
                  unidade.Id, unidade.Numero, unidade.Andar, unidade.GrupoDescricao, viewModel.VisitantePermanente,
                  viewModel.QrCode, viewModel.TipoDeVisitante, viewModel.NomeEmpresa, viewModel.TemVeiculo);
        }

        private AtualizarVisitantePorMoradorCommand AtualizarVisitantePorMoradorCommandFactory
            (AtualizaVisitanteViewModel viewModel)
        {
            return new AtualizarVisitantePorMoradorCommand(
                   viewModel.Id, viewModel.Nome, viewModel.TipoDoDocumento, viewModel.Documento, viewModel.Email,
                   viewModel.Foto, viewModel.NomeOriginalFoto, viewModel.VisitantePermanente, viewModel.TipoDeVisitante,
                   viewModel.NomeEmpresa, viewModel.TemVeiculo);
        }


    }
}
