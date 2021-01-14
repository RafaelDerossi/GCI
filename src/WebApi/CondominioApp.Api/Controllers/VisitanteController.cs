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
        public async Task<ActionResult> Post(CadastraVisitanteViewModel visitante)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = CadastrarVisitanteCommandFactory(visitante);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        //[HttpPut]
        //public async Task<ActionResult> Put(EditaAreaComumViewModel areaComumVM)
        //{
        //    if (!ModelState.IsValid) return CustomResponse(ModelState);

        //    var comando = EditarAreaComumCommandFactory(areaComumVM);

        //    var Resultado = await _mediatorHandler.EnviarComando(comando);

        //    return CustomResponse(Resultado);
        //}

        //[HttpDelete("{Id:Guid}")]
        //public async Task<ActionResult> Delete(Guid Id)
        //{
        //    var comando = new RemoverAreaComumCommand(Id);

        //    var Resultado = await _mediatorHandler.EnviarComando(comando);

        //    return CustomResponse(Resultado);
        //}


        //[HttpPut("ativar/{Id:Guid}")]
        //public async Task<ActionResult> AtivarAreaComum(Guid Id)
        //{
        //    var comando = new AtivarAreaComumCommand(Id);

        //    var Resultado = await _mediatorHandler.EnviarComando(comando);

        //    return CustomResponse(Resultado);
        //}

        //[HttpPut("desativar/{Id:Guid}")]
        //public async Task<ActionResult> DesativarAreaComum(Guid Id)
        //{
        //    var comando = new DesativarAreaComumCommand(Id);

        //    var Resultado = await _mediatorHandler.EnviarComando(comando);

        //    return CustomResponse(Resultado);
        //}




        private CadastrarVisitanteCommand CadastrarVisitanteCommandFactory(CadastraVisitanteViewModel viewModel)
        {
            return new CadastrarVisitanteCommand(
                  viewModel.Nome, viewModel.Documento, viewModel.Email, viewModel.Foto,
                  viewModel.NomeOriginalFoto, viewModel.CondominioId, viewModel.NomeCondominio,
                  viewModel.UnidadeId, viewModel.NumeroUnidade, viewModel.AndarUnidade,
                  viewModel.GrupoUnidade, viewModel.VisitantePermanente, viewModel.QrCode,
                  viewModel.TipoDeVisitante, viewModel.NomeEmpresa, viewModel.TemVeiculo, 
                  viewModel.Placa, viewModel.Modelo, viewModel.Cor);
        }

        private EditarVisitanteCommand EditarVisitanteCommandFactory(EditaVisitanteViewModel viewModel)
        {
            return new EditarVisitanteCommand(
                   viewModel.Id, viewModel.Nome, viewModel.Documento, viewModel.Email, viewModel.Foto,
                   viewModel.NomeOriginalFoto, viewModel.VisitantePermanente, viewModel.TipoDeVisitante,
                   viewModel.NomeEmpresa, viewModel.TemVeiculo, viewModel.Placa, viewModel.Modelo, viewModel.Cor);
        }
    }
}
