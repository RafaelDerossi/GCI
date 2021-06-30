using AutoMapper;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Mediator;
using CondominioApp.Correspondencias.App.Aplication.Commands;
using CondominioApp.Correspondencias.App.Aplication.Query;
using CondominioApp.Correspondencias.App.Models;
using CondominioApp.Correspondencias.App.ViewModels;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Usuarios.App.Aplication.Query;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private readonly IPrincipalQuery _principalQuery;
        private readonly IUsuarioQuery _usuarioQuery;

        public CorrespondenciaController(
            IMediatorHandler mediatorHandler, IMapper mapper, ICorrespondenciaQuery correspondenciaQuery,
            IWebHostEnvironment webHostEnvironment, IPrincipalQuery principalQuery, IUsuarioQuery usuarioQuery)
        {
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
            _correspondenciaQuery = correspondenciaQuery;
            _webHostEnvironment = webHostEnvironment;
            _principalQuery = principalQuery;
            _usuarioQuery = usuarioQuery;
        }


        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<CorrespondenciaViewModel>> ObterPorId(Guid id)
        {
            var correspondencia = await _correspondenciaQuery.ObterPorId(id);
            if (correspondencia == null)
            {
                AdicionarErroProcessamento("Correspondência não encontrada.");
                return CustomResponse();
            }
            return _mapper.Map<CorrespondenciaViewModel>(correspondencia);
        }

        [HttpGet("por-unidade-e-periodo")]
        public async Task<ActionResult<IEnumerable<CorrespondenciaViewModel>>> ObterPorUnidadeEPeriodo(
            Guid unidadeId, DateTime dataInicio, DateTime dataFim)
        {
            var correspondencias = await _correspondenciaQuery.ObterPorUnidadeEPeriodo(
                unidadeId, dataInicio, dataFim);
            if (correspondencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var correspondenciasVM = new List<CorrespondenciaViewModel>();
            foreach (Correspondencia item in correspondencias)
            {
                var correspondenciaVM = _mapper.Map<CorrespondenciaViewModel>(item);
                correspondenciasVM.Add(correspondenciaVM);
            }
            return correspondenciasVM;
        }

        [HttpGet("por-condominio-periodo-e-status")]
        public async Task<ActionResult<IEnumerable<CorrespondenciaViewModel>>> ObterPorCondominioPeriodoEStatus(
            Guid condominioId, DateTime dataInicio, DateTime dataFim, StatusCorrespondencia status)
        {
            var correspondencias = await _correspondenciaQuery.ObterPorCondominioPeriodoEStatus(
                condominioId, dataInicio, dataFim, status);
            if (correspondencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var correspondenciasVM = new List<CorrespondenciaViewModel>();
            foreach (Correspondencia item in correspondencias)
            {
                var correspondenciaVM = _mapper.Map<CorrespondenciaViewModel>(item);
                correspondenciasVM.Add(correspondenciaVM);
            }
            return correspondenciasVM;
        }



        [HttpPost]
        public async Task<ActionResult> Post(AdicionaCorrespondenciaViewModel correspondenciaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var unidade =await _principalQuery.ObterUnidadePorId(correspondenciaVM.UnidadeId);
            if (unidade == null)
            {
                AdicionarErroProcessamento("Unidade não encontrada!");
                return CustomResponse();
            }

            var funcionario = await _usuarioQuery.ObterFuncionarioPorId(correspondenciaVM.FuncionarioId);
            if (funcionario == null)
            {
                AdicionarErroProcessamento("Funcionário não encontrado!");
                return CustomResponse();
            }

            var comando = new AdicionarCorrespondenciaCommand(
                 unidade.CondominioId, unidade.Id, unidade.Numero, unidade.GrupoDescricao,
                 correspondenciaVM.Observacao, funcionario.Id, funcionario.NomeCompleto,
                 correspondenciaVM.Foto, correspondenciaVM.NomeOriginal,
                 correspondenciaVM.NumeroRastreamentoCorreio, correspondenciaVM.DataDeChegada,
                 correspondenciaVM.TipoDeCorrespondencia, correspondenciaVM.Status,
                 correspondenciaVM.NomeRetirante, correspondenciaVM.DataDaRetirada);

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
            var funcionario = await _usuarioQuery.ObterFuncionarioPorId(viewModel.FuncionarioId);
            if (funcionario == null)
            {
                AdicionarErroProcessamento("Funcionário não encontrado!");
                return CustomResponse();
            }

            var comando = new MarcarCorrespondenciaRetiradaCommand(
                viewModel.Id,viewModel.NomeRetirante, viewModel.Observacao,
                viewModel.FuncionarioId, funcionario.NomeCompleto);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("marcar-correspondencia-devolvida")]
        public async Task<ActionResult> PutDevolvida(MarcaCorrespondenciaDevolvidaViewModel viewModel)
        {
            var funcionario = await _usuarioQuery.ObterFuncionarioPorId(viewModel.FuncionarioId);
            if (funcionario == null)
            {
                AdicionarErroProcessamento("Funcionário não encontrado!");
                return CustomResponse();
            }

            var comando = new MarcarCorrespondenciaDevolvidaCommand(
                viewModel.Id, viewModel.Observacao,
                viewModel.FuncionarioId, funcionario.NomeCompleto);

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
            var comando = new ApagarCorrespondenciaCommand(id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }


        [HttpPost("gerar-excel")]
        public async Task<ActionResult> GerarExcel(List<Guid> lstCorrespondencias)
        {
            string sWebRootFolder = _webHostEnvironment.WebRootPath;
            string nomeDoArquivo = @"/" + Guid.NewGuid().ToString();            

            var comando = new GerarExcelCorrespondenciaCommand(lstCorrespondencias, sWebRootFolder, nomeDoArquivo);

            nomeDoArquivo = $"{nomeDoArquivo}.xlsx";
            string caminhoCompleto = $"{sWebRootFolder}/Download/Temp{nomeDoArquivo}";

            var Resultado = await _mediatorHandler.EnviarComando(comando);
            
            if (Resultado.IsValid)
            {
                //Rotina para retornar o arquivo
                //var provider = new FileExtensionContentTypeProvider();
                //if (!provider.TryGetContentType(caminhoCompleto, out var contentType))
                //{
                    //contentType = "application/octet-stream";
                //}
                //var bytes = await System.IO.File.ReadAllBytesAsync(caminhoCompleto);
                //return File(bytes, contentType, Path.GetFileName(caminhoCompleto));
                
                return CustomResponse(nomeDoArquivo);
            }            

            return CustomResponse(Resultado);
        }


       
    }
}
