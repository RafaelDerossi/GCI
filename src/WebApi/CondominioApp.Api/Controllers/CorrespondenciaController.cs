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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        /// Retorna o Histórico da correspondencia        
        /// </summary>
        /// <param name="correspondenciaId">Id(Guid) da correspondência</param>        
        /// <response code="200">Enum Ação: CADASTRO = 0, NOTIFICACAO = 1, RETIRADA = 2, DEVOLUCAO = 3, EXCLUSAO = 4</response>
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
        /// Cadastra uma nova correspondência
        /// </summary>
        /// <param name="correspondenciaVM">
        /// DataDeChegada              : Data em que a correspondência chegou;   
        /// UnidadeId                  : Id(Guid) da unidade da correspondência;   
        /// FuncionarioId              : Id(Guid) do funcionário que cadastrou a correspondência;   
        /// Observacao                 : Observações sobre a chegada da correspôndencia;   
        /// ArquivoFotoCorrespondencia : Arquivo da foto da correspondência;   
        /// NumeroRastreamentoCorreio  : Número de rastreamento da correspondência nos Correios ou transportadora;   
        /// TipoDeCorrespondencia      : Tipo da correspondência, ex: "Caixa", "Pacote", "Mercado Livre", "Amazon";   
        /// Localizacao                : Localização da correspondência para retirada;   
        /// EnviarNotificacao          : Informa se envia notificação sobre a correspôndencia ao morador ou não;   
        /// </param>
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
                    return CustomResponse(retorno);

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

            var nomeArquivoFotoRetirante = StorageHelper.ObterNomeDoArquivo(viewModel.ArquivoFotoDoRetirante);

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
        /// Marcar uma correspondência como retirada através do qrcode
        /// </summary>
        /// <param name="codigoDeVerificacao">Código de verificação da correspondência</param>
        /// <param name="moradorId">Id(Guid) do morador que esta retirando</param>
        /// <param name="funcionarioId">Id(Guid) do funcionário que esta entregando</param>
        /// <returns></returns>
        [HttpPut("marcar-correspondencia-retirada-qrcode")]
        public async Task<ActionResult> PutRetiradaQrcode(string codigoDeVerificacao, Guid moradorId, Guid funcionarioId)
        {
            var funcionario = await _usuarioQuery.ObterFuncionarioPorId(funcionarioId);
            if (funcionario == null)
            {
                AdicionarErroProcessamento("Funcionário não encontrado!");
                return CustomResponse();
            }

            var morador = await _usuarioQuery.ObterMoradorPorId(moradorId);
            if (morador == null)
            {
                AdicionarErroProcessamento("Morador não encontrado!");
                return CustomResponse();
            }

            var correspondencia = await _correspondenciaQuery.ObterPorCodigo(codigoDeVerificacao);
            if (correspondencia == null)
            {
                AdicionarErroProcessamento("Correspondência não encontrada!");
                return CustomResponse();
            }

            var comando = new MarcarCorrespondenciaRetiradaCommand(
                correspondencia.Id, morador.NomeCompleto, "Retirada pelo QrCode",
                funcionario.Id, funcionario.NomeCompleto, morador.Foto);            

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
            string nomeDoArquivo = $"{Guid.NewGuid()}.xlsx";
            MemoryStream ms = new MemoryStream();
         
            var comando = new GerarExcelCorrespondenciaCommand(lstCorrespondencias, ms);           

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

                
                var arquivo = new FormFile(ms, 0, ms.Length, null, nomeDoArquivo)
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "application/xlsx"
                };

                var pastaDoStorage = "RelatoriosEmExcel";

                var retorno = await _azureStorageService.SubirArquivo
                    (arquivo,
                     nomeDoArquivo,
                     pastaDoStorage);

                if (!retorno.IsValid)
                    return CustomResponse(retorno);                

                var url = StorageHelper.ObterUrlDeArquivo(pastaDoStorage, nomeDoArquivo);

                return CustomResponse(url);
            }            

            return CustomResponse(Resultado);
        }



        private AdicionarCorrespondenciaCommand AdicionarCorrespondenciaCommandFactory
            (AdicionaCorrespondenciaViewModel viewModel, FuncionarioFlat funcionario, UnidadeFlat unidade)
        {
            var nomeArquivo = StorageHelper.ObterNomeDoArquivo(viewModel.ArquivoFotoCorrespondencia);

            return new AdicionarCorrespondenciaCommand
                (unidade.CondominioId, unidade.Id, unidade.Numero, unidade.GrupoDescricao, 
                 viewModel.Observacao, funcionario.Id, funcionario.Nome, nomeArquivo, 
                 viewModel.NumeroRastreamentoCorreio, viewModel.DataDeChegada, 
                 viewModel.TipoDeCorrespondencia, viewModel.EnviarNotificacao,
                 viewModel.Localizacao);
        }

    }
}
