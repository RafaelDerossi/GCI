using AutoMapper;
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

namespace CondominioApp.Api.Controllers
{
    [Route("api/visitante")]
    public class VisitanteController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;      
        private readonly IPortariaQuery _portariaQuery;

        public VisitanteController(IMediatorHandler mediatorHandler, IPortariaQuery portariaQuery)
        {
            _mediatorHandler = mediatorHandler;           
            _portariaQuery = portariaQuery;
        }


        [HttpGet("{id:Guid}")]
        public async Task<VisitanteFlat> ObterPorId(Guid id)
        {
            return await _portariaQuery.ObterPorId(id);
        }

        [HttpGet("por-condominio/{condominioId:Guid}")]
        public async Task<IEnumerable<VisitanteFlat>> ObterPorCondominio(Guid condominioId)
        {
            return await _portariaQuery.ObterVisitantesPorCondominio(condominioId);
        }

        [HttpGet("por-unidade/{unidadeId:Guid}")]
        public async Task<IEnumerable<VisitanteFlat>> ObterPorUnidade(Guid unidadeId)
        {
            return await _portariaQuery.ObterVisitantesPorUnidade(unidadeId);
        }

        [HttpGet("por-documento/{documento}")]
        public async Task<IEnumerable<VisitanteFlat>> ObterPorDocumento(string documento)
        {
            return await _portariaQuery.ObterVisitantesPorDocumento(documento);
        }



        [HttpPost]
        public async Task<ActionResult> Post(CadastraVisitanteViewModel visitanteVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = CadastrarVisitantePorMoradorCommandFactory(visitanteVM);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut]
        public async Task<ActionResult> Put(EditaVisitanteViewModel visitanteVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = EditarVisitantePorMoradorCommandFactory(visitanteVM);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpDelete("{Id:Guid}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            var comando = new RemoverVisitanteCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }



        private CadastrarVisitantePorMoradorCommand CadastrarVisitantePorMoradorCommandFactory
            (CadastraVisitanteViewModel viewModel)
        {
            return new CadastrarVisitantePorMoradorCommand(
                  viewModel.Nome, viewModel.Documento, viewModel.Email, viewModel.Foto,
                  viewModel.NomeOriginalFoto, viewModel.CondominioId, viewModel.NomeCondominio,
                  viewModel.UnidadeId, viewModel.NumeroUnidade, viewModel.AndarUnidade,
                  viewModel.GrupoUnidade, viewModel.VisitantePermanente, viewModel.QrCode,
                  viewModel.TipoDeVisitante, viewModel.NomeEmpresa, viewModel.TemVeiculo);
        }

        private EditarVisitantePorMoradorCommand EditarVisitantePorMoradorCommandFactory
            (EditaVisitanteViewModel viewModel)
        {
            return new EditarVisitantePorMoradorCommand(
                   viewModel.Id, viewModel.Nome, viewModel.Documento, viewModel.Email, viewModel.Foto,
                   viewModel.NomeOriginalFoto, viewModel.VisitantePermanente, viewModel.TipoDeVisitante,
                   viewModel.NomeEmpresa, viewModel.TemVeiculo);
        }


    }
}
