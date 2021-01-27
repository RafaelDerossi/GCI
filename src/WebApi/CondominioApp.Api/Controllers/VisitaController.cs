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
using CondominioApp.Core.Enumeradores;

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



        [HttpPost("por-morador")]
        public async Task<ActionResult> PostPorMorador(CadastraVisitaMoradorViewModel visitaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var dias = (visitaVM.DataDeEntradaFim.Date - visitaVM.DataDeEntradaInicio.Date).Days + 1;

            for (int i = 0; i < dias; i++)
            {
                var cadastrarVisitaComando = 
                    CadastrarVisitaPorMoradorCommandFactory(visitaVM, visitaVM.DataDeEntradaInicio.AddDays(i).Date);

                var resultado = await _mediatorHandler.EnviarComando(cadastrarVisitaComando);

                if (!resultado.IsValid)
                    return CustomResponse(resultado);

            }            

            return CustomResponse();
        }

        [HttpPost("por-porteiro")]
        public async Task<ActionResult> PostPorPorteiro(CadastraVisitaPorteiroViewModel visitaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);


            if (visitaVM.VisitanteId == Guid.Empty)
            {
                visitaVM.VisitanteId = Guid.NewGuid();

                var cadastrarVisitanteComando = CadastrarVisitantePorPorteiroCommandFactory(visitaVM);

                var retorno = await _mediatorHandler.EnviarComando(cadastrarVisitanteComando);

                if (!retorno.IsValid)
                    return CustomResponse(retorno);

                var comando = CadastrarVisitaPorPorteiroCommandFactory(visitaVM);

                retorno = await _mediatorHandler.EnviarComando(comando);

                return CustomResponse(retorno);
            }
           

            var editarVisitanteComando = EditarVisitantePorPorteiroCommandFactory(visitaVM);
            var result = await _mediatorHandler.EnviarComando(editarVisitanteComando);
            if (!result.IsValid)
                return CustomResponse(result);

            var cadastrarVisitaComando = CadastrarVisitaPorPorteiroCommandFactory(visitaVM);
            result = await _mediatorHandler.EnviarComando(cadastrarVisitaComando);
          

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



        private CadastrarVisitaPorPorteiroCommand CadastrarVisitaPorPorteiroCommandFactory(CadastraVisitaPorteiroViewModel viewModel)
        {
            return new CadastrarVisitaPorPorteiroCommand(
                  viewModel.DataDeEntrada,viewModel.Observacao, StatusVisita.PENDENTE, viewModel.VisitanteId,
                  viewModel.NomeVisitante, viewModel.TipoDoDocumento, viewModel.Documento, viewModel.EmailVisitante, viewModel.FotoVisitante,
                  viewModel.NomeOriginalFotoVisitante, viewModel.TipoDeVisitante, viewModel.NomeEmpresaVisitante,
                  viewModel.CondominioId, viewModel.NomeCondominio, viewModel.UnidadeId, viewModel.NumeroUnidade,
                  viewModel.AndarUnidade, viewModel.GrupoUnidade, viewModel.TemVeiculo, viewModel.PlacaVeiculo, 
                  viewModel.ModeloVeiculo, viewModel.CorVeiculo, viewModel.UsuarioId, viewModel.NomeUsuario);
        }

        private CadastrarVisitaPorMoradorCommand CadastrarVisitaPorMoradorCommandFactory(CadastraVisitaMoradorViewModel viewModel, DateTime dataDeEntrada)
        {
            return new CadastrarVisitaPorMoradorCommand(
                  dataDeEntrada, viewModel.Observacao, StatusVisita.APROVADA, viewModel.VisitanteId,
                  viewModel.CondominioId, viewModel.NomeCondominio, viewModel.UnidadeId, viewModel.NumeroUnidade,
                  viewModel.AndarUnidade, viewModel.GrupoUnidade, viewModel.UsuarioId, viewModel.NomeUsuario);
        }

        private EditarVisitaCommand EditarVisitaCommandFactory(EditaVisitaViewModel viewModel)
        {
            return new EditarVisitaCommand(
                   viewModel.Id,viewModel.Observacao, viewModel.NomeVisitante,viewModel.TipoDoDocumento, viewModel.Documento,
                   viewModel.EmailVisitante, viewModel.FotoVisitante, viewModel.NomeOriginalFotoVisitante,
                   viewModel.TipoDeVisitante, viewModel.NomeEmpresaVisitante,viewModel.UnidadeId, viewModel.NumeroUnidade,
                   viewModel.AndarUnidade, viewModel.GrupoUnidade, viewModel.TemVeiculo, viewModel.PlacaVeiculo,
                   viewModel.ModeloVeiculo, viewModel.CorVeiculo, viewModel.UsuarioId, viewModel.NomeUsuario);
        }




        private CadastrarVisitantePorPorteiroCommand CadastrarVisitantePorPorteiroCommandFactory(CadastraVisitaPorteiroViewModel visitaVM)
        {
            return new CadastrarVisitantePorPorteiroCommand(
                  visitaVM.VisitanteId, visitaVM.NomeVisitante, visitaVM.TipoDoDocumento, visitaVM.Documento,
                  visitaVM.EmailVisitante, visitaVM.FotoVisitante, visitaVM.NomeOriginalFotoVisitante,
                  visitaVM.CondominioId, visitaVM.NomeCondominio, visitaVM.UnidadeId, visitaVM.NumeroUnidade,
                  visitaVM.AndarUnidade, visitaVM.GrupoUnidade, visitaVM.TipoDeVisitante, visitaVM.NomeEmpresaVisitante,
                  visitaVM.TemVeiculo);
        }
       
        private EditarVisitantePorPorteiroCommand EditarVisitantePorPorteiroCommandFactory(CadastraVisitaPorteiroViewModel visitaVM)
        {
           return new EditarVisitantePorPorteiroCommand(
                  visitaVM.VisitanteId, visitaVM.NomeVisitante,visitaVM.TipoDoDocumento, visitaVM.Documento,
                  visitaVM.EmailVisitante, visitaVM.FotoVisitante, visitaVM.NomeOriginalFotoVisitante,
                  visitaVM.TipoDeVisitante, visitaVM.NomeEmpresaVisitante, visitaVM.TemVeiculo);
        }

        private EditarVisitantePorPorteiroCommand EditarVisitantePorPorteiroCommandFactory(EditaVisitaViewModel visitaVM)
        {
            return new EditarVisitantePorPorteiroCommand(
                  visitaVM.VisitanteId, visitaVM.NomeVisitante, visitaVM.TipoDoDocumento, visitaVM.Documento,
                  visitaVM.EmailVisitante, visitaVM.FotoVisitante, visitaVM.NomeOriginalFotoVisitante,
                  visitaVM.TipoDeVisitante, visitaVM.NomeEmpresaVisitante, visitaVM.TemVeiculo);
        }

    }
}
