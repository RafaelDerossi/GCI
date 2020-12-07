using AutoMapper;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Mediator;
using CondominioApp.Correspondencias.App.Aplication.Commands;
using CondominioApp.Correspondencias.App.Aplication.Query;
using CondominioApp.Correspondencias.App.Models;
using CondominioApp.Correspondencias.App.ViewModels;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("api/correspondencia")]
    public class CorrespondenciaController : MainController
    {

        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;
        private readonly ICorrespondenciaQuery _correspondenciaQuery;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CorrespondenciaController(IMediatorHandler mediatorHandler, IMapper mapper, ICorrespondenciaQuery correspondenciaQuery, IWebHostEnvironment webHostEnvironment)
        {
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
            _correspondenciaQuery = correspondenciaQuery;
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpGet("{id:Guid}")]
        public async Task<CorrespondenciaViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<CorrespondenciaViewModel>(await _correspondenciaQuery.ObterPorId(id));
        }

        [HttpGet("por-unidade-e-periodo")]
        public async Task<IEnumerable<CorrespondenciaViewModel>> ObterPorUnidadeEPeriodo(
            Guid unidadeId, DateTime dataInicio, DateTime dataFim)
        {
            var correspondencias = await _correspondenciaQuery.ObterPorUnidadeEPeriodo(
                unidadeId, dataInicio, dataFim);

            var correspondenciasVM = new List<CorrespondenciaViewModel>();
            foreach (Correspondencia item in correspondencias)
            {
                var enqueteVM = _mapper.Map<CorrespondenciaViewModel>(item);
                correspondenciasVM.Add(enqueteVM);
            }
            return correspondenciasVM;
        }

        [HttpGet("por-condominio-periodo-e-status")]
        public async Task<IEnumerable<CorrespondenciaViewModel>> ObterEnquetesAtivasPorCondominio(
            Guid condominioId, DateTime dataInicio, DateTime dataFim, StatusCorrespondencia status)
        {
            var correspondencias = await _correspondenciaQuery.ObterPorCondominioPeriodoEStatus(
                condominioId, dataInicio, dataFim, status);

            var correspondenciasVM = new List<CorrespondenciaViewModel>();
            foreach (Correspondencia item in correspondencias)
            {
                var enqueteVM = _mapper.Map<CorrespondenciaViewModel>(item);
                correspondenciasVM.Add(enqueteVM);
            }
            return correspondenciasVM;
        }



        [HttpPost]
        public async Task<ActionResult> Post(CadastraCorrespondenciaViewModel correspondenciaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new CadastrarCorrespondenciaCommand(
                 correspondenciaVM.CondominioId, correspondenciaVM.UnidadeId, correspondenciaVM.NumeroUnidade, correspondenciaVM.Bloco,
                 correspondenciaVM.Observacao, correspondenciaVM.UsuarioId, correspondenciaVM.NomeUsuario,
                 correspondenciaVM.Foto, correspondenciaVM.NomeOriginal, correspondenciaVM.NumeroRastreamentoCorreio,
                 correspondenciaVM.DataDeChegada, correspondenciaVM.TipoDeCorrespondencia, correspondenciaVM.Status);           

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }


        [HttpPut("marcar-correspondencia-vista/{correspondenciaId:Guid}")]
        public async Task<ActionResult> PutVista(Guid correspondenciaId)
        {           
            var comando = new MarcarCorrespondenciaVistaCommand(correspondenciaId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("marcar-correspondencia-retirada")]
        public async Task<ActionResult> PutRetirada(MarcaCorrespondenciaRetiradaViewModel viewModel)
        {
            var comando = new MarcarCorrespondenciaRetiradaCommand(
                viewModel.Id,viewModel.NomeRetirante, viewModel.Observacao,
                viewModel.UsuarioId, viewModel.NomeUsuario);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("marcar-correspondencia-devolvida")]
        public async Task<ActionResult> PutDevolvida(MarcaCorrespondenciaDevolvidaViewModel viewModel)
        {
            var comando = new MarcarCorrespondenciaDevolvidaCommand(
                viewModel.Id, viewModel.Observacao,
                viewModel.UsuarioId, viewModel.NomeUsuario);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("disparar-alerta/{correspondenciaId:Guid}")]
        public async Task<ActionResult> PutDispararAlerta(Guid correspondenciaId)
        {
            var comando = new DispararAlertaDeCorrespondenciaCommand(correspondenciaId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var comando = new RemoverCorrespondenciaCommand(id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }


        [HttpPost("gerar-excel")]
        public async Task<ActionResult> GerarExcel(List<Guid> lstCorrespondencias)
        {
            string sWebRootFolder = _webHostEnvironment.WebRootPath;
            string nomeDoArquivo = @"/" + Guid.NewGuid().ToString() + ".xlsx";

            var comando = new GerarExcelCorrespondenciaCommand(lstCorrespondencias, sWebRootFolder, nomeDoArquivo);

            var Resultado = await _mediatorHandler.EnviarComando(comando);
            
            if (Resultado.IsValid)
                return CustomResponse(nomeDoArquivo);

            return CustomResponse(Resultado);
        }


       
    }
}
