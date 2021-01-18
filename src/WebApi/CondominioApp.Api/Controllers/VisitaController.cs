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


        //[HttpGet("{id:Guid}")]
        //public async Task<AreaComumFlat> ObterPorId(Guid id)
        //{
        //    return await _portariaQuery.ObterPorId(id);
        //}

        //[HttpGet("por-condominio/{condominioId:Guid}")]
        //public async Task<IEnumerable<AreaComumFlat>> ObterPorCondominio(Guid condominioId)
        //{
        //    return await _portariaQuery.ObterPorCondominio(condominioId);                  
        //}



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

        //[HttpDelete("{Id:Guid}")]
        //public async Task<ActionResult> Delete(Guid Id)
        //{
        //    var comando = new RemoverVisitanteCommand(Id);

        //    var Resultado = await _mediatorHandler.EnviarComando(comando);

        //    return CustomResponse(Resultado);
        //}






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
