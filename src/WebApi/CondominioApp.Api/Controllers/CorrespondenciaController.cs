using AutoMapper;
using CondominioApp.ArquivoDigital.AzureStorageBlob.Services;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Mediator;
using CondominioApp.Correspondencias.App.Aplication.Commands;
using CondominioApp.Correspondencias.App.Aplication.Query;
using CondominioApp.Correspondencias.App.Models;
using CondominioApp.Correspondencias.App.ViewModels;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.Usuarios.App.Aplication.Query;
using CondominioApp.Usuarios.App.FlatModel;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        private readonly IAzureStorageService _azureStorageService;

        public CorrespondenciaController(
            IMediatorHandler mediatorHandler, IMapper mapper, ICorrespondenciaQuery correspondenciaQuery,
            IWebHostEnvironment webHostEnvironment, IPrincipalQuery principalQuery, IUsuarioQuery usuarioQuery,
            IAzureStorageService azureStorageService)
        {
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
            _correspondenciaQuery = correspondenciaQuery;
            _webHostEnvironment = webHostEnvironment;
            _principalQuery = principalQuery;
            _usuarioQuery = usuarioQuery;
            _azureStorageService = azureStorageService;
        }


        /// <summary>
        /// Retorna uma correspondência pelo Id
        /// </summary>
        /// <param name="id">Id(Guid) da correspondência</param>
        /// <returns></returns>
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



        /// <summary>
        /// Retorna uma correspondência pelo Código de verificação
        /// </summary>
        /// <param name="codigoDeVerificacao">string com o código</param>
        /// <returns></returns>
        [HttpGet("{codigoDeVerificacao}")]
        public async Task<ActionResult<CorrespondenciaViewModel>> ObterPorCodigo(string codigoDeVerificacao)
        {
            var correspondencia = await _correspondenciaQuery.ObterPorCodigo(codigoDeVerificacao);
            if (correspondencia == null)
            {
                AdicionarErroProcessamento("Correspondência não encontrada.");
                return CustomResponse();
            }
            return _mapper.Map<CorrespondenciaViewModel>(correspondencia);
        }

        /// <summary>
        /// Retorna uma lista de correspondências da unidade no período
        /// </summary>
        /// <param name="unidadeId">Id(Guid) da unidade</param>
        /// <param name="dataInicio">Data de início do período</param>
        /// <param name="dataFim">Data de fim do período</param>
        /// <returns></returns>
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

        /// <summary>
        /// Retorna uma lista de correspondências do condomínio por período e status
        /// </summary>
        /// <param name="condominioId">Id(Guid) do condomínio</param>
        /// <param name="dataInicio">Data de início do período</param>
        /// <param name="dataFim">Data de fim do período</param>
        /// <param name="status">Status da correspondência: PENDENTE = 0, RETIRADO = 1, DEVOLVIDO = 2</param>
        /// <returns></returns>
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


        /// <summary>
        /// Retorna o Historico da correspondencia
        /// </summary>
        /// <param name="correspondenciaId">Id(Guid) da correspondência</param>
        /// <returns></returns>
        [HttpGet("historico-da-correspondencia")]
        public async Task<ActionResult<IEnumerable<HistoricoCorrespondenciaViewModel>>> ObterHistoricoDaCorrespondencia(
            Guid correspondenciaId)
        {
            var historicos = await _correspondenciaQuery.ObterHistoricoPorCorrespondencia(correspondenciaId);
            if (historicos.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var historicosViewModel = new List<HistoricoCorrespondenciaViewModel>();
            foreach (HistoricoCorrespondencia item in historicos)
            {
                var historicoViewModel = _mapper.Map<HistoricoCorrespondenciaViewModel>(item);
                historicosViewModel.Add(historicoViewModel);
            }
            return historicosViewModel;
        }




        /// <summary>
        /// Cadastra uma nova correspondência e alerta o morador
        /// </summary>
        /// <param name="correspondenciaVM"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromForm]AdicionaCorrespondenciaViewModel correspondenciaVM)
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

            var comando = AdicionarCorrespondenciaCommandFactory(correspondenciaVM, funcionario, unidade);

            if (correspondenciaVM.ArquivoFotoCorrespondencia != null && comando.EstaValido())
            {
                var retorno = await _azureStorageService.SubirArquivo
                              (correspondenciaVM.ArquivoFotoCorrespondencia,
                               comando.FotoCorrespondencia.NomeDoArquivo,
                               unidade.CondominioId.ToString());

                if (!retorno.IsValid)
                {
                    AdicionarErroProcessamento("Falha ao carregar foto!");
                    return CustomResponse();
                }
            }

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        /// <summary>
        /// Marcar uma correspondência como vista
        /// </summary>
        /// <param name="correspondenciaId">Id(Guid) da correspondência</param>
        /// <returns></returns>
        [HttpPut("marcar-correspondencia-vista/{correspondenciaId:Guid}")]
        public async Task<ActionResult> PutVista(Guid correspondenciaId)
        {           
            var comando = new MarcarCorrespondenciaVistaCommand(correspondenciaId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        /// <summary>
        /// Marcar uma correspondência como retirada
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPut("marcar-correspondencia-retirada")]
        public async Task<ActionResult> PutRetirada([FromForm]MarcaCorrespondenciaRetiradaViewModel viewModel)
        {
            var funcionario = await _usuarioQuery.ObterFuncionarioPorId(viewModel.FuncionarioId);
            if (funcionario == null)
            {
                AdicionarErroProcessamento("Funcionário não encontrado!");
                return CustomResponse();
            }

            var nomeArquivoFotoRetirante = StoragePaths.ObterNomeDoArquivo(viewModel.ArquivoFotoDoRetirante);

            var comando = new MarcarCorrespondenciaRetiradaCommand(
                viewModel.CorrespondenciaId,viewModel.NomeRetirante, viewModel.Observacao,
                viewModel.FuncionarioId, funcionario.NomeCompleto, nomeArquivoFotoRetirante);

            if (viewModel.ArquivoFotoDoRetirante != null && comando.EstaValido())
            {
                var retorno = await _azureStorageService.SubirArquivo
                              (viewModel.ArquivoFotoDoRetirante,
                               comando.FotoRetirante.NomeDoArquivo, 
                               funcionario.CondominioId.ToString());
                if (!retorno.IsValid)
                {
                    AdicionarErroProcessamento("Falha ao carregar foto!");
                    return CustomResponse();
                }
            }

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        /// <summary>
        /// Marcar correspondência como devolvida
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Disparar alerta para avisar sobre uma correspondência que não foi retirada.
        /// </summary>
        /// <param name="correspondenciaId">Id(Guid) da correspondência</param>
        /// <returns></returns>
        [HttpPut("disparar-alerta/{correspondenciaId:Guid}")]
        public async Task<ActionResult> PutDispararAlerta(Guid correspondenciaId)
        {
            var comando = new DispararAlertaDeCorrespondenciaCommand(correspondenciaId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        /// <summary>
        /// Enviar uma correspondência para a lixeira
        /// </summary>
        /// <param name="id">Id(Guid) da correspondência</param>
        /// <returns></returns>
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var comando = new ApagarCorrespondenciaCommand(id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        /// <summary>
        /// Gerar um arquivo excel de uma lista de correspondências
        /// </summary>
        /// <param name="lstCorrespondencias">Lista de ids(Guid) das correspondências para o arquivo excel</param>
        /// <returns></returns>
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



        private AdicionarCorrespondenciaCommand AdicionarCorrespondenciaCommandFactory
            (AdicionaCorrespondenciaViewModel viewModel, FuncionarioFlat funcionario, UnidadeFlat unidade)
        {
            var nomeArquivo = StoragePaths.ObterNomeDoArquivo(viewModel.ArquivoFotoCorrespondencia);

            return new AdicionarCorrespondenciaCommand
                (unidade.CondominioId, unidade.Id, unidade.Numero, unidade.GrupoDescricao, 
                 viewModel.Observacao, funcionario.Id, funcionario.Nome, nomeArquivo, 
                 viewModel.NumeroRastreamentoCorreio, viewModel.DataDeChegada, 
                 viewModel.TipoDeCorrespondencia, viewModel.EnviarNotificacao,
                 viewModel.Localizacao);
        }

    }
}
