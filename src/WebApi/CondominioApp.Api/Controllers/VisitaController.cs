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



        [HttpPost("criar-por-morador")]
        public async Task<ActionResult> PostPorMorador(CadastraVisitaMoradorViewModel visitaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
           
            foreach (DateTime dataDeEntrada in visitaVM.DatasDeEntrada)
            {
                var cadastrarVisitaComando = CadastrarVisitaCommandFactory(visitaVM, dataDeEntrada);

                var resultado = await _mediatorHandler.EnviarComando(cadastrarVisitaComando);

                if (!resultado.IsValid)
                    return CustomResponse(resultado);
            }          

            return CustomResponse();
        }

        [HttpPost("criar-por-porteiro")]
        public async Task<ActionResult> PostPorPorteiro(CadastraVisitaPorteiroViewModel visitaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);


            if (visitaVM.VisitanteId == Guid.Empty)
            {
                visitaVM.VisitanteId = Guid.NewGuid();

                var cadastrarVisitanteComando = CadastrarVisitantePorPorteiroCommandFactory(visitaVM);

                var resultado = await _mediatorHandler.EnviarComando(cadastrarVisitanteComando);

                if (!resultado.IsValid)
                    return CustomResponse(resultado);

                var comando = CadastrarVisitaCommandFactory(visitaVM);

                resultado = await _mediatorHandler.EnviarComando(comando);

                return CustomResponse(resultado);
            }


            var cadastrarVisitaComando = CadastrarVisitaCommandFactory(visitaVM);

            var result = await _mediatorHandler.EnviarComando(cadastrarVisitaComando);
            if (!result.IsValid)
                return CustomResponse(result);

            var editarVisitanteComando = EditarVisitantePorPorteiroCommandFactory(visitaVM);

            result = await _mediatorHandler.EnviarComando(editarVisitanteComando);            

            return CustomResponse(result);
        }


        [HttpPut]
        public async Task<ActionResult> Put(EditaVisitaViewModel visitaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = EditarVisitaCommandFactory(visitaVM);

            var resultado = await _mediatorHandler.EnviarComando(comando);

            if (!resultado.IsValid)
                return CustomResponse(resultado);


            var editarVisitanteComando = EditarVisitantePorPorteiroCommandFactory(visitaVM);

            resultado = await _mediatorHandler.EnviarComando(editarVisitanteComando);

            return CustomResponse(resultado);
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



        private CadastrarVisitaCommand CadastrarVisitaCommandFactory(CadastraVisitaPorteiroViewModel viewModel)
        {
            return new CadastrarVisitaCommand(
                  viewModel.DataDeEntrada,viewModel.Observacao, viewModel.Status,viewModel.VisitanteId,
                  viewModel.NomeVisitante, viewModel.Documento, viewModel.EmailVisitante, viewModel.FotoVisitante,
                  viewModel.NomeOriginalFotoVisitante, viewModel.TipoDeVisitante, viewModel.NomeEmpresaVisitante,
                  viewModel.CondominioId, viewModel.NomeCondominio, viewModel.UnidadeId, viewModel.NumeroUnidade,
                  viewModel.AndarUnidade, viewModel.GrupoUnidade, viewModel.TemVeiculo, viewModel.PlacaVeiculo, 
                  viewModel.ModeloVeiculo, viewModel.CorVeiculo, viewModel.UsuarioId, viewModel.NomeUsuario);
        }

        private CadastrarVisitaCommand CadastrarVisitaCommandFactory(CadastraVisitaMoradorViewModel viewModel, DateTime dataDeEntrada)
        {
            return new CadastrarVisitaCommand(
                  dataDeEntrada, viewModel.Observacao, viewModel.Status, viewModel.VisitanteId,
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




        private CadastrarVisitantePorPorteiroCommand CadastrarVisitantePorPorteiroCommandFactory(CadastraVisitaPorteiroViewModel visitaVM)
        {
            return new CadastrarVisitantePorPorteiroCommand(
                  visitaVM.VisitanteId, visitaVM.NomeVisitante, visitaVM.Documento, visitaVM.EmailVisitante, visitaVM.FotoVisitante,
                  visitaVM.NomeOriginalFotoVisitante, visitaVM.CondominioId, visitaVM.NomeCondominio,
                  visitaVM.UnidadeId, visitaVM.NumeroUnidade, visitaVM.AndarUnidade, visitaVM.GrupoUnidade,
                  visitaVM.TipoDeVisitante, visitaVM.NomeEmpresaVisitante, visitaVM.TemVeiculo, visitaVM.PlacaVeiculo,
                  visitaVM.ModeloVeiculo, visitaVM.CorVeiculo);
        }
       
        private EditarVisitantePorPorteiroCommand EditarVisitantePorPorteiroCommandFactory(CadastraVisitaPorteiroViewModel visitaVM)
        {
           return new EditarVisitantePorPorteiroCommand(
                  visitaVM.VisitanteId, visitaVM.NomeVisitante, visitaVM.Documento, visitaVM.EmailVisitante, visitaVM.FotoVisitante,
                  visitaVM.NomeOriginalFotoVisitante, visitaVM.TipoDeVisitante, visitaVM.NomeEmpresaVisitante,
                  visitaVM.TemVeiculo, visitaVM.PlacaVeiculo, visitaVM.ModeloVeiculo, visitaVM.CorVeiculo);
        }

        private EditarVisitantePorPorteiroCommand EditarVisitantePorPorteiroCommandFactory(EditaVisitaViewModel visitaVM)
        {
            return new EditarVisitantePorPorteiroCommand(
                  visitaVM.VisitanteId, visitaVM.NomeVisitante, visitaVM.Documento, visitaVM.EmailVisitante, visitaVM.FotoVisitante,
                  visitaVM.NomeOriginalFotoVisitante, visitaVM.TipoDeVisitante, visitaVM.NomeEmpresaVisitante,
                  visitaVM.TemVeiculo, visitaVM.PlacaVeiculo, visitaVM.ModeloVeiculo, visitaVM.CorVeiculo);
        }

    }
}
