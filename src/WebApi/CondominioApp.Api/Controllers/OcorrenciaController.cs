using AutoMapper;
using CondominioApp.ArquivoDigital.AzureStorageBlob.Services;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Mediator;
using CondominioApp.Ocorrencias.App.Aplication.Commands;
using CondominioApp.Ocorrencias.App.Aplication.Query;
using CondominioApp.Ocorrencias.App.Models;
using CondominioApp.Ocorrencias.App.ViewModels;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.Usuarios.App.Aplication.Query;
using CondominioApp.Usuarios.App.FlatModel;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("api/ocorrencia")]
    public class OcorrenciaController : MainController
    {

        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;        
        private readonly IPrincipalQuery _principalQuery;
        private readonly IUsuarioQuery _usuarioQuery;
        private readonly IOcorrenciaQuery _ocorrenciaQuery;
        private readonly IAzureStorageService _azureStorageService;

        public OcorrenciaController(IMediatorHandler mediatorHandler, IMapper mapper, 
                                    IPrincipalQuery principalQuery, IUsuarioQuery usuarioQuery,
                                    IOcorrenciaQuery ocorrenciaQuery,
                                    IAzureStorageService azureStorageService)
        {
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;            
            _principalQuery = principalQuery;
            _usuarioQuery = usuarioQuery;
            _ocorrenciaQuery = ocorrenciaQuery;
            _azureStorageService = azureStorageService;
        }


        #region GETs
        
        [HttpGet("por-morador-ou-publicas/{moradorId:Guid}")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterPorMoradorOuPublicas(Guid moradorId)
        {
            var morador = await _usuarioQuery.ObterMoradorPorId(moradorId);
            if (morador == null)
            {
                AdicionarErroProcessamento("Morador não encontrado!");
                return CustomResponse();
            }

            var ocorrencias = await _ocorrenciaQuery.ObterPorMoradorOuPublicas(morador.CondominioId, moradorId);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = MapperListEntityToViewModel(ocorrencias);

            return ocorrenciasVM;
        }


        [HttpGet("por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterPorCondominio(Guid condominioId)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorCondominio(condominioId);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = MapperListEntityToViewModel(ocorrencias);

            return ocorrenciasVM;
        }


        [HttpGet("pendentes-por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterPendentesPorCondominio(Guid unidadeId)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorCondominioEStatus(unidadeId, StatusDaOcorrencia.PENDENTE);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = MapperListEntityToViewModel(ocorrencias);

            return ocorrenciasVM;
        }


        [HttpGet("em-andamento-por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterEmAndamentoPorCondominio(Guid condominioId)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorCondominioEStatus(condominioId, StatusDaOcorrencia.EM_ANDAMENTO);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = MapperListEntityToViewModel(ocorrencias);

            return ocorrenciasVM;
        }


        [HttpGet("resolvidas-por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterResolvidasPorCondominio(Guid condominioId)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorCondominioEStatus(condominioId, StatusDaOcorrencia.RESOLVIDA);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = MapperListEntityToViewModel(ocorrencias);

            return ocorrenciasVM;
        }


        [HttpGet("por-condominio-e-filtro")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterPorCondominioEFiltro(Guid condominioId, string filtro)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorCondominioEFiltro(condominioId, filtro);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = MapperListEntityToViewModel(ocorrencias);

            return ocorrenciasVM;
        }


        [HttpGet("pendentes-por-condominio-e-filtro")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterPendentesPorCondominioEFiltro(Guid condominioId, string filtro)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorCondominioEStatusEFiltro(condominioId, StatusDaOcorrencia.PENDENTE, filtro);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = MapperListEntityToViewModel(ocorrencias);

            return ocorrenciasVM;
        }


        [HttpGet("em-andamento-por-condominio-e-filtro")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterEmAndamentoPorCondominioEFiltro(Guid condominioId, string filtro)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorCondominioEStatusEFiltro(condominioId, StatusDaOcorrencia.EM_ANDAMENTO, filtro);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = MapperListEntityToViewModel(ocorrencias);

            return ocorrenciasVM;
        }


        [HttpGet("resolvidas-por-condominio-e-filtro")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterResolvidasPorCondominioEFiltro(Guid condominioId, string filtro)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorCondominioEStatusEFiltro(condominioId, StatusDaOcorrencia.RESOLVIDA, filtro);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = MapperListEntityToViewModel(ocorrencias);

            return ocorrenciasVM;
        }




        [HttpGet("por-unidade/{unidadeId:Guid}")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterPorUnidade(Guid unidadeId)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorUnidade(unidadeId);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = new List<OcorrenciaViewModel>();
            foreach (Ocorrencia comunicado in ocorrencias)
                ocorrenciasVM.Add(_mapper.Map<OcorrenciaViewModel>(comunicado));

            return ocorrenciasVM;
        }


        [HttpGet("pendentes-por-unidade/{unidadeId:Guid}")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterPendentesPorUnidade(Guid unidadeId)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorUnidadeEStatus(unidadeId, StatusDaOcorrencia.PENDENTE);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = new List<OcorrenciaViewModel>();
            foreach (Ocorrencia comunicado in ocorrencias)
                ocorrenciasVM.Add(_mapper.Map<OcorrenciaViewModel>(comunicado));

            return ocorrenciasVM;
        }


        [HttpGet("em-andamento-por-unidade/{unidadeId:Guid}")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterEmAndamentoPorUnidade(Guid unidadeId)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorUnidadeEStatus(unidadeId, StatusDaOcorrencia.EM_ANDAMENTO);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = new List<OcorrenciaViewModel>();
            foreach (Ocorrencia comunicado in ocorrencias)
                ocorrenciasVM.Add(_mapper.Map<OcorrenciaViewModel>(comunicado));

            return ocorrenciasVM;
        }


        [HttpGet("resolvidas-por-unidade/{unidadeId:Guid}")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterResolvidasPorUnidade(Guid unidadeId)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorUnidadeEStatus(unidadeId, StatusDaOcorrencia.RESOLVIDA);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = new List<OcorrenciaViewModel>();
            foreach (Ocorrencia comunicado in ocorrencias)
                ocorrenciasVM.Add(_mapper.Map<OcorrenciaViewModel>(comunicado));

            return ocorrenciasVM;
        }


        [HttpGet("por-unidade-e-filtro")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterPorUnidadeEFiltro(Guid unidadeId, string filtro)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorUnidadeEFiltro(unidadeId, filtro);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = new List<OcorrenciaViewModel>();
            foreach (Ocorrencia comunicado in ocorrencias)
                ocorrenciasVM.Add(_mapper.Map<OcorrenciaViewModel>(comunicado));

            return ocorrenciasVM;
        }


        [HttpGet("pendentes-por-unidade-e-filtro")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterPendentesPorUnidadeEFiltro(Guid unidadeId, string filtro)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorUnidadeEStatusEFiltro(unidadeId, StatusDaOcorrencia.PENDENTE, filtro);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = new List<OcorrenciaViewModel>();
            foreach (Ocorrencia comunicado in ocorrencias)
                ocorrenciasVM.Add(_mapper.Map<OcorrenciaViewModel>(comunicado));

            return ocorrenciasVM;
        }


        [HttpGet("em-andamento-por-unidade-e-filtro")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterEmAndamentoPorUnidadeEFiltro(Guid unidadeId, string filtro)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorUnidadeEStatusEFiltro(unidadeId, StatusDaOcorrencia.EM_ANDAMENTO, filtro);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = new List<OcorrenciaViewModel>();
            foreach (Ocorrencia comunicado in ocorrencias)
                ocorrenciasVM.Add(_mapper.Map<OcorrenciaViewModel>(comunicado));

            return ocorrenciasVM;
        }


        [HttpGet("resolvidas-por-unidade-e-filtro")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterResolvidasPorUnidadeEFiltro(Guid unidadeId, string filtro)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorUnidadeEStatusEFiltro(unidadeId, StatusDaOcorrencia.RESOLVIDA, filtro);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = new List<OcorrenciaViewModel>();
            foreach (Ocorrencia comunicado in ocorrencias)
                ocorrenciasVM.Add(_mapper.Map<OcorrenciaViewModel>(comunicado));

            return ocorrenciasVM;
        }





        [HttpGet("respostas-por-ocorrencia/{ocorrenciaId:Guid}")]
        public async Task<ActionResult<IEnumerable<RespostaOcorrenciaViewModel>>> ObterRespostasPorOcorrencia(Guid ocorrenciaId)
        {
            var ocorrencia = await _ocorrenciaQuery.ObterPorId(ocorrenciaId);
            if (ocorrencia == null)
            {
                AdicionarErroProcessamento("Ocorrência não encontrada!");
                return CustomResponse();
            }

            var respostas = await _ocorrenciaQuery.ObterRespostasPorOcorrencia(ocorrenciaId);
            
            var respostasVM = new List<RespostaOcorrenciaViewModel>();
            foreach (RespostaOcorrencia resposta in respostas)
            {
                var respostaViewModel = _mapper.Map<RespostaOcorrenciaViewModel>(resposta);
                respostaViewModel.FotoUrl = StorageHelper.ObterUrlDeArquivo(ocorrencia.CondominioId.ToString(), resposta.Foto.NomeDoArquivo);
                respostasVM.Add(respostaViewModel);
            }                

            return respostasVM;
        }

        #endregion


        #region POSTs

        /// <summary>
        /// Adiciona uma ocorrência
        /// </summary>
        /// <param name="ocorrenciaVM"></param>
        /// <response code="200">
        /// Parâmetros:   
        /// Descricao   : Descrição da ocorêrncia (1000 caracteres);   
        /// Publica     : Define se a ocorrência é publica(todos os moradores podem ver) ou privada(somente a administração pode ver);   
        /// MoradorId   : Id(Guid) do morador que criou a ocorrência;   
        /// Panico      : Informa se a ocorrência é de emergência ou não;   
        /// ArquivoFoto : Arquivo da foto de ocorrência;   
        /// </response>
        [HttpPost]
        public async Task<ActionResult> Post([FromForm]AdicionaOcorrenciaViewModel ocorrenciaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var morador = await _usuarioQuery.ObterMoradorPorId(ocorrenciaVM.MoradorId);
            if (morador == null)
            {
                AdicionarErroProcessamento("Morador não encontrado!");
                return CustomResponse();
            }

            var unidade = await _principalQuery.ObterUnidadePorId(morador.UnidadeId);
            if (unidade == null)
            {
                AdicionarErroProcessamento("Unidade não encontrada!");
                return CustomResponse();
            }

            var comando = AdicionarOcorrenciaCommandFactory(ocorrenciaVM, morador, unidade);

            if (ocorrenciaVM.ArquivoFoto != null && comando.EstaValido())
            {
                var retorno = await _azureStorageService.SubirArquivo
                              (ocorrenciaVM.ArquivoFoto, comando.Foto.NomeDoArquivo, unidade.CondominioId.ToString());
                if (!retorno.IsValid)
                    return CustomResponse(retorno);
            }

            var Resultado = await _mediatorHandler.EnviarComando(comando);            

            return CustomResponse(Resultado);
        }

        /// <summary>
        /// Adiciona uma resposta da administração a uma ocorrência
        /// </summary>
        /// <param name="respostaVM"></param>
        /// <response code="200">
        /// Parâmetros:   
        /// OcorrenciaId      : Id(Guid) da ocorrência;   
        /// Descricao         : Descrição da ocorêrncia (1000 caracteres);   
        /// FuncionarioId     : Id(Guid) do funcionario que esta respondendo a ocorrência;   
        /// ArquivoFoto       : Arquivo da foto;   
        /// ArquivoAnexo      : Arquivo anexo;   
        /// StatusDaOcorrencia: Define o status da ocorrência.Enum(PENDENTE = 0, EM_ANDAMENTO = 1, RESOLVIDA = 2)
        /// </response>
        [HttpPost("resposta-administracao")]
        public async Task<ActionResult> PostRespostaAdministracao([FromForm]AdicionaRespostaOcorrenciaAdministracaoViewModel respostaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var funcionario = await _usuarioQuery.ObterFuncionarioPorId(respostaVM.FuncionarioId);
            if (funcionario == null)
            {
                AdicionarErroProcessamento("Funcionário não encontrado!");
                return CustomResponse();
            }

            var comando = AdicionarRespostaOcorrenciaAdministracaoCommandFactory(respostaVM, funcionario);

            if (respostaVM.ArquivoFoto != null && comando.EstaValido())
            {
                var retorno = await _azureStorageService.SubirArquivo
                              (respostaVM.ArquivoFoto, comando.Foto.NomeDoArquivo, funcionario.CondominioId.ToString());
                if (!retorno.IsValid)
                    return CustomResponse(retorno);                
            }

            if (respostaVM.ArquivoAnexo != null && comando.EstaValido())
            {
                var retorno = await _azureStorageService.SubirArquivo
                    (respostaVM.ArquivoFoto, comando.Foto.NomeDoArquivo, funcionario.CondominioId.ToString());
                if (!retorno.IsValid)                    
                    return CustomResponse(retorno);
            }

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        /// <summary>
        /// Adiciona uma resposta do morador a uma ocorrência
        /// </summary>
        /// <param name="respostaVM"></param>
        /// <response code="200">
        /// Parâmetros:   
        /// OcorrenciaId      : Id(Guid) da ocorrência;   
        /// Descricao         : Descrição da ocorêrncia (1000 caracteres);   
        /// MoradorId         : Id(Guid) do morador que esta respondendo a ocorrência;   
        /// ArquivoFoto       : Arquivo da foto;   
        /// ArquivoAnexo      : Arquivo anexo;           
        /// </response>
        [HttpPost("resposta-morador")]
        public async Task<ActionResult> PostRespostaMorador([FromForm]AdicionaRespostaOcorrenciaMoradorViewModel respostaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var morador = await _usuarioQuery.ObterMoradorPorId(respostaVM.MoradorId);
            if (morador == null)
            {
                AdicionarErroProcessamento("Morador não encontrado!");
                return CustomResponse();
            }

            var comando = AdicionarRespostaOcorrenciaMoradorCommandFactory(respostaVM, morador);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        #endregion


        #region PUTs

        /// <summary>
        /// Atualiza uma ocorrência
        /// </summary>
        /// <param name="ocorrenciaVM"></param>
        /// <response code="200">
        /// Parâmetros:   
        /// Id          : Id(Guid) da ocorrência a ser editada;   
        /// Descricao   : Descrição da ocorrência(1000 caracteres);   
        /// Publica     : Define se a ocorrência vai poder ser vista por todos os moradores(Pública) ou apenas pela administração(privada);   
        /// ArquivoFoto : Arquivo de uma foto;   
        /// </response>
        [HttpPut]
        public async Task<ActionResult> Put([FromForm]AtualizaOcorrenciaViewModel ocorrenciaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var ocorrencia = await _ocorrenciaQuery.ObterPorId(ocorrenciaVM.Id);
            if (ocorrencia == null)
            {
                AdicionarErroProcessamento("Ocorrência não encontrada!");
                return CustomResponse();
            }

            var comando = AtualizarOcorrenciaCommandFactory(ocorrenciaVM);            

            if (ocorrenciaVM.ArquivoFoto != null && comando.EstaValido())
            {
                var retorno = await _azureStorageService.SubirArquivo
                   (ocorrenciaVM.ArquivoFoto, comando.Foto.NomeDoArquivo, ocorrencia.CondominioId.ToString());
                if (!retorno.IsValid)
                    return CustomResponse(retorno);
            }

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }        

        /// <summary>
        /// Marca uma resposta de uma ocorrência como vista
        /// </summary>
        /// <param name="respostaId">Id(Guid) da resposta</param>
        /// <returns></returns>
        [HttpPut("marcar-resposta-vista/{respostaId:Guid}")]
        public async Task<ActionResult> PutMarcarRespostaVista(Guid respostaId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            
            var comando = new MarcarRespostaOcorrenciaComoVistaCommand(respostaId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        /// <summary>
        /// Atualizar uma resposta se ainda não foi visualizada
        /// </summary>
        /// <param name="respostaVM"></param>
        /// <response code="200">
        /// Parâmetros:   
        /// Id                     : Id(Guid) da resposta;   
        /// Descricao              : Nova descrição da resposta (1000 caracteres);   
        /// MoradorIdFuncionarioId : Id(Guid) da morador ou do funcionário que esta editando a resposta(tem que ser o mesmo que criou a resposta);   
        /// </response>
        [HttpPut("resposta")]
        public async Task<ActionResult> PutResposta([FromForm]AtualizaRespostaOcorrenciaViewModel respostaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var resposta = await _ocorrenciaQuery.ObterPorId(respostaVM.Id);
            if (resposta == null)
            {
                AdicionarErroProcessamento("Resposta não encontrada!");
                return CustomResponse();
            }           

            var comando = new AtualizarRespostaOcorrenciaCommand
                (respostaVM.Id, respostaVM.MoradorIdFuncionarioId, respostaVM.Descricao);            

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        #endregion


        #region Delete
        /// <summary>
        /// Envia uma ocorrência para lixeira
        /// </summary>
        /// <param name="ocorrenciaId">Id(Guid) da ocorrência</param>
        /// <returns></returns>
        [HttpDelete("remover/{ocorrenciaId:Guid}")]
        public async Task<ActionResult> RemoverOcorrencia(Guid ocorrenciaId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new ApagarOcorrenciaCommand(ocorrenciaId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        /// <summary>
        /// Envia uma resposta para a lixeira
        /// </summary>
        /// <param name="respostaId">Id(Guid) da resposta</param>
        /// <param name="moradorIdFuncionarioId">Id(Guid) do morador ou do funcionário que esta tentando apagar a resposta</param>
        /// <returns></returns>
        [HttpDelete("remover/{respostaId:Guid}")]
        public async Task<ActionResult> RemoverRespostaDeOcorrencia(Guid respostaId, Guid moradorIdFuncionarioId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new ApagarRespostaOcorrenciaCommand(respostaId, moradorIdFuncionarioId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }
        #endregion



        #region Metodos Auxiliares        

        private List<OcorrenciaViewModel> MapperListEntityToViewModel(IEnumerable<Ocorrencia> ocorrencias)
        {
            var ocorrenciasVM = new List<OcorrenciaViewModel>();
            foreach (Ocorrencia ocorrencia in ocorrencias)
            {
                var ocorrenciaVM = _mapper.Map<OcorrenciaViewModel>(ocorrencia);

                var morador = _usuarioQuery.ObterMoradorPorId(ocorrencia.MoradorId).Result;
                ocorrenciaVM.NomeMorador = morador.NomeCompleto;
                ocorrenciaVM.FotoMoradorUrl = morador.Url;

                ocorrenciasVM.Add(ocorrenciaVM);
            }
            return ocorrenciasVM;
        }

        private AdicionarOcorrenciaCommand AdicionarOcorrenciaCommandFactory
            (AdicionaOcorrenciaViewModel ocorrenciaVM, MoradorFlat morador, UnidadeFlat unidade)
        {
            var nomeArquivo = StorageHelper.ObterNomeDoArquivo(ocorrenciaVM.ArquivoFoto);

            return new AdicionarOcorrenciaCommand
                (ocorrenciaVM.Descricao, nomeArquivo, ocorrenciaVM.Publica,
                 unidade.Id, unidade.Numero, unidade.Andar, unidade.GrupoDescricao, ocorrenciaVM.MoradorId,
                 morador.NomeCompleto, unidade.CondominioId, unidade.CondominioNome, ocorrenciaVM.Panico);
        }

        private AtualizarOcorrenciaCommand AtualizarOcorrenciaCommandFactory
           (AtualizaOcorrenciaViewModel ocorrenciaVM)
        {
            var nomeArquivo = StorageHelper.ObterNomeDoArquivo(ocorrenciaVM.ArquivoFoto);

            return new AtualizarOcorrenciaCommand
                 (ocorrenciaVM.Id, ocorrenciaVM.Descricao, nomeArquivo, ocorrenciaVM.Publica);
        }

        private AdicionarRespostaOcorrenciaAdministracaoCommand AdicionarRespostaOcorrenciaAdministracaoCommandFactory
          (AdicionaRespostaOcorrenciaAdministracaoViewModel respostaVM, FuncionarioFlat funcionario)
        {
            var fotoNomeOriginal = StorageHelper.ObterNomeDoArquivo(respostaVM.ArquivoFoto);
            var arquivoAnexoNomeOriginal = StorageHelper.ObterNomeDoArquivo(respostaVM.ArquivoAnexo);

            return new AdicionarRespostaOcorrenciaAdministracaoCommand
                 (respostaVM.OcorrenciaId, respostaVM.Descricao, respostaVM.FuncionarioId,
                  funcionario.NomeCompleto, fotoNomeOriginal, respostaVM.StatusDaOcorrencia,
                  arquivoAnexoNomeOriginal);
        }

        private AdicionarRespostaOcorrenciaMoradorCommand AdicionarRespostaOcorrenciaMoradorCommandFactory
            (AdicionaRespostaOcorrenciaMoradorViewModel respostaVM, MoradorFlat morador)
        {
            var fotoNomeArquivo = StorageHelper.ObterNomeDoArquivo(respostaVM.ArquivoFoto);
            var arquivoAnexoNomeOriginal = StorageHelper.ObterNomeDoArquivo(respostaVM.ArquivoAnexo);

            return new AdicionarRespostaOcorrenciaMoradorCommand
                 (respostaVM.OcorrenciaId, respostaVM.Descricao, respostaVM.MoradorId, morador.NomeCompleto,
                  fotoNomeArquivo, arquivoAnexoNomeOriginal);
        }
                       

        #endregion

    }
}
