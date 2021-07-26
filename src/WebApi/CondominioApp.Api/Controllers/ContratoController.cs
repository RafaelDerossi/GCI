using AutoMapper;
using CondominioApp.ArquivoDigital.AzureStorageBlob.Services;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Mediator;
using CondominioApp.Principal.Aplication;
using CondominioApp.Principal.Aplication.Commands;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Principal.Aplication.ViewModels;
using CondominioApp.Principal.Domain;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("api/Contrato")]
    public class ContratoController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IPrincipalQuery _principalQuery;
        public readonly IMapper _mapper;
        private readonly IAzureStorageService _azureStorageService;

        public ContratoController
            (IMediatorHandler mediatorHandler, IPrincipalQuery principalQuery,
             IMapper mapper, IAzureStorageService azureStorageService)
        {
            _mediatorHandler = mediatorHandler;
            _principalQuery = principalQuery;
            _mapper = mapper;
            _azureStorageService = azureStorageService;
        }


        /// <summary>
        /// Retorna um contrato pelo id
        /// </summary>
        /// <param name="Id">Id(Guid) do contrato</param>
        /// <response code="200">                
        /// Id                             : Id(Guid) do contrato;   
        /// CondominioId                   : Id(Guid) do condomínio;   
        /// DataAssinatura                 : Data da assinatura do contrato;   
        /// Plano                          : Tipo do plano Enum: SEM_CONTRATO = 0, FREE = 1, STANDARD = 2, PREMIUM = 3;   
        /// TipoDescricao                  : Descrição do Tipo do plano;   
        /// Descricao                      : Breve descrição do contrato(200 caracteres);   
        /// Ativo                          : Informa se o contrato esta ativo;   
        /// QuantidadeDeUnidadesContratada : Informa a quantidades de unidades contratadas;   
        /// NomeArquivoContrato            : Nome do Arquivo do contrato;           
        /// NomeOriginalArquivoContrato    : Nome original do Arquivo do contrato;           
        /// UrlArquivoContrato             : Url do arquivo do contrato;   
        /// </response>
        [HttpGet("{Id:Guid}")]
        public async Task<ActionResult<ContratoViewModel>> ObterPorId(Guid Id)
        {
            var contrato = await _principalQuery.ObterContratoPorId(Id);
            if (contrato == null)
            {
                AdicionarErroProcessamento("Contrato não encontrado.");
                return CustomResponse();
            }
            return _mapper.Map<ContratoViewModel>(contrato);
        }

        /// <summary>
        /// Retorna uma lista com todos os contratos do condomínio
        /// </summary>
        /// <param name="condominioId">Id(Guid) do condomínio</param>
        /// <response code="200">                
        /// Id                             : Id(Guid) do contrato;   
        /// CondominioId                   : Id(Guid) do condomínio;   
        /// DataAssinatura                 : Data da assinatura do contrato;   
        /// Plano                          : Tipo do plano Enum: SEM_CONTRATO = 0, FREE = 1, STANDARD = 2, PREMIUM = 3;   
        /// TipoDescricao                  : Descrição do Tipo do plano;   
        /// Descricao                      : Breve descrição do contrato(200 caracteres);   
        /// Ativo                          : Informa se o contrato esta ativo;   
        /// QuantidadeDeUnidadesContratada : Informa a quantidades de unidades contratadas;   
        /// NomeArquivoContrato            : Nome do Arquivo do contrato;           
        /// NomeOriginalArquivoContrato    : Nome original do Arquivo do contrato;           
        /// UrlArquivoContrato             : Url do arquivo do contrato;   
        /// </response>
        [HttpGet("por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<ContratoViewModel>>> ObterPorCondominio(Guid condominioId)
        {
            var contratos = await _principalQuery.ObterContratosPorCondominio(condominioId);
            if (contratos.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }
            var contratosVM = new List<ContratoViewModel>();
            foreach (Contrato item in contratos)
            {
                var contratoVM = _mapper.Map<ContratoViewModel>(item);
                contratosVM.Add(contratoVM);
            }
            return contratosVM;           
        }



        /// <summary>
        /// Adiciona um contrato ao condominio
        /// </summary>
        /// <param name="contratoVM"></param>
        /// <response code="200">                        
        /// CondominioId                   : Id(Guid) do condomínio;   
        /// DataAssinatura                 : Data da assinatura do contrato;   
        /// Plano                          : Tipo do plano Enum: SEM_CONTRATO = 0, FREE = 1, STANDARD = 2, PREMIUM = 3;           
        /// Descricao                      : Breve descrição do contrato(200 caracteres);   
        /// Ativo                          : Informa se o contrato esta ativo;   
        /// QuantidadeDeUnidadesContratada : Informa a quantidades de unidades contratadas;   
        /// ArquivoContrato                : Arquivo do contrato;  
        /// </response>
        [HttpPost]
        public async Task<ActionResult> Post(AdicionaContratoViewModel contratoVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);            

            var comando = AdicionarContratoCommandFactory(contratoVM);

            if (comando.EstaValido() && contratoVM.ArquivoContrato != null)
            {
                var retorno = await _azureStorageService.SubirArquivo
                              (contratoVM.ArquivoContrato,
                               comando.ArquivoContrato.NomeDoArquivo,
                               comando.CondominioId.ToString());

                if (!retorno.IsValid)
                    return CustomResponse(retorno);
            }

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);          
        }

        /// <summary>
        /// Edita dados do contrato
        /// </summary>
        /// <param name="editaContratoVM">                          
        /// Id                             : Id(Guid) do contrato;   
        /// DataAssinatura                 : Data da assinatura do contrato;   
        /// Plano                          : Tipo do plano Enum: SEM_CONTRATO = 0, FREE = 1, STANDARD = 2, PREMIUM = 3;           
        /// Descricao                      : Breve descrição do contrato(200 caracteres);   
        /// Ativo                          : Informa se o contrato esta ativo;   
        /// QuantidadeDeUnidadesContratada : Informa a quantidades de unidades contratadas;          
        /// </param>
        [HttpPut]
        public async Task<ActionResult> Put(AtualizaContratoViewModel editaContratoVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AtualizarContratoCommand
                (editaContratoVM.Id, editaContratoVM.DataDaAssinatura, editaContratoVM.Plano,
                 editaContratoVM.Descricao, editaContratoVM.QuantidadeDeUnidadesContratadas);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        /// <summary>
        /// Ativa um contrato
        /// </summary>
        /// <param name="Id">Id(Guid) do contrato</param>
        /// <returns></returns>
        [HttpPut("ativar/{Id:Guid}")]
        public async Task<ActionResult> AtivarContrato(Guid Id)
        {
            var comando = new AtivarContratoCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        /// <summary>
        /// Desativa um contrato
        /// </summary>
        /// <param name="Id">Id(Guid) do contrato</param>
        /// <returns></returns>
        [HttpPut("desativar/{Id:Guid}")]
        public async Task<ActionResult> DesativarContrato(Guid Id)
        {
            var comando = new DesativarContratoCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        /// <summary>
        /// Envia um contrato para a lixeira
        /// </summary>
        /// <param name="Id">Id(Guid) do contrato</param>
        /// <returns></returns>
        [HttpDelete("{Id:Guid}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            var comando = new ApagarContratoCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }        

        
        private AdicionarContratoCommand AdicionarContratoCommandFactory(AdicionaContratoViewModel contratoVM)
        {
            var nomeOriginalArquivoContrato = StorageHelper.ObterNomeDoArquivo(contratoVM.ArquivoContrato);

            return new AdicionarContratoCommand(
                 contratoVM.CondominioId, contratoVM.DataDaAssinatura, contratoVM.Tipo,
                 contratoVM.Descricao, contratoVM.Ativo, contratoVM.QuantidadeDeUnidadesContratadas,
                 nomeOriginalArquivoContrato);
        }

    }
}
