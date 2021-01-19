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
    [Route("api/visita")]
    public class VisitaController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;      
        private readonly IPortariaQuery _portariaQuery;

        public VisitaController(IMediatorHandler mediatorHandler, IPortariaQuery portariaQuery)
        {
            _mediatorHandler = mediatorHandler;           
            _portariaQuery = portariaQuery;
        }


        [HttpGet("{id:Guid}")]
        public async Task<VisitaFlat> ObterPorId(Guid id)
        {
            return await _portariaQuery.ObterVisitaPorId(id);
        }

        [HttpGet("por-condominio/{condominioId:Guid}")]
        public async Task<IEnumerable<VisitaFlat>> ObterPorCondominio(Guid condominioId)
        {
            return await _portariaQuery.ObterVisitasPorCondominio(condominioId);
        }

        [HttpGet("por-unidade/{unidadeId:Guid}")]
        public async Task<IEnumerable<VisitaFlat>> ObterPorUnidade(Guid unidadeId)
        {
            return await _portariaQuery.ObterVisitasPorUnidade(unidadeId);
        }

        [HttpGet("por-usuario/{usuarioId:Guid}")]
        public async Task<IEnumerable<VisitaFlat>> ObterPorUsuario(Guid usuarioId)
        {
            return await _portariaQuery.ObterVisitasPorUsuario(usuarioId);
        }



        [HttpPost]
        public async Task<ActionResult> Post(CadastraVisitaViewModel visitaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = CadastrarVisitaCommandFactory(visitaVM);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut]
        public async Task<ActionResult> Put(EditaVisitaViewModel visitaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = EditarVisitaCommandFactory(visitaVM);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpDelete("{Id:Guid}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            var comando = new RemoverVisitaCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("aprovar/{Id:Guid}")]
        public async Task<ActionResult> PutAprovarVisita(Guid Id)
        {
            var comando = new AprovarVisitaCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("reprovar/{Id:Guid}")]
        public async Task<ActionResult> PutReprovarVisita(Guid Id)
        {
            var comando = new ReprovarVisitaCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("iniciar/{Id:Guid}")]
        public async Task<ActionResult> PutIniciarVisita(Guid Id)
        {
            var comando = new IniciarVisitaCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("terminar/{Id:Guid}")]
        public async Task<ActionResult> PutTerminarVisita(Guid Id)
        {
            var comando = new TerminarVisitaCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }



        private CadastrarVisitaCommand CadastrarVisitaCommandFactory(CadastraVisitaViewModel viewModel)
        {
            return new CadastrarVisitaCommand(
                  viewModel.DataDeEntrada,viewModel.Observacao, viewModel.Status,viewModel.VisitanteId,
                  viewModel.NomeVisitante, viewModel.Documento, viewModel.EmailVisitante, viewModel.FotoVisitante,
                  viewModel.NomeOriginalFotoVisitante, viewModel.TipoDeVisitante, viewModel.NomeEmpresaVisitante,
                  viewModel.CondominioId, viewModel.NomeCondominio, viewModel.UnidadeId, viewModel.NumeroUnidade,
                  viewModel.AndarUnidade, viewModel.GrupoUnidade, viewModel.TemVeiculo, viewModel.PlacaVeiculo, 
                  viewModel.ModeloVeiculo, viewModel.CorVeiculo, viewModel.UsuarioId, viewModel.NomeUsuario);
        }

        private EditarVisitaCommand EditarVisitaCommandFactory(EditaVisitaViewModel viewModel)
        {
            return new EditarVisitaCommand(
                   viewModel.Id,viewModel.Observacao, viewModel.NomeVisitante, viewModel.Documento, viewModel.EmailVisitante, viewModel.FotoVisitante,
                   viewModel.NomeOriginalFotoVisitante, viewModel.TipoDeVisitante, viewModel.NomeEmpresaVisitante,
                   viewModel.UnidadeId, viewModel.NumeroUnidade, viewModel.AndarUnidade, viewModel.GrupoUnidade, 
                   viewModel.TemVeiculo, viewModel.PlacaVeiculo, viewModel.ModeloVeiculo, viewModel.CorVeiculo,
                   viewModel.UsuarioId, viewModel.NomeUsuario);
        }

    }
}
