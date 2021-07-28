using CondominioApp.ArquivoDigital.AzureStorageBlob.Services;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Mediator;
using CondominioApp.Principal.Aplication.Commands;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Principal.Aplication.ViewModels;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.Usuarios.App.Aplication.Query;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("api/condominio")]
    public class CondominioController : MainController
    {

        private readonly IMediatorHandler _mediatorHandler;
        private readonly IPrincipalQuery _principalQuery;
        private readonly IUsuarioQuery _usuarioQuery;
        private readonly IAzureStorageService _azureStorageService;

        public CondominioController
            (IMediatorHandler mediatorHandler, IPrincipalQuery principalQuery,
             IUsuarioQuery usuarioQuery, IAzureStorageService azureStorageService)
        {
            _mediatorHandler = mediatorHandler;
            _principalQuery = principalQuery;
            _usuarioQuery = usuarioQuery;
            _azureStorageService = azureStorageService;
        }


        /// <summary>
        /// Retorna todos os condomínios cadastrados
        /// </summary>        
        ///  /// <response code="200">
        /// Id                                  : Id(Guid) do condomínio;   
        /// DataDeCadastro                      : Data-hora de cadastro do condomínio;   
        /// DataDeAlteracao                     : Data-hora de alteração do condomínio;   
        /// Lixeira                             : Informa se o condomínio esta na lixeira ou não;   
        /// Cnpj                                : CNPJ do condomínio;   
        /// Nome                                : Nome do condomínio(200 caracteres);   
        /// Descricao                           : Breve descrição do condomínio(200 caracteres);   
        /// NomeArquivoLogo                     : Nome do arquivo da logo do condomínio;   
        /// NomeOriginalArquivoLogo             : Nome original do arquivo da logo do condomínio;     
        /// UrlArquivoLogo                      : Url da logo do condomínio;   
        /// Telefone                            : Telefone do condomínio;   
        /// Logradouro                          : Endereço do condomínio;   
        /// Complemento                         : Complemento do endereço do condomínio;   
        /// Numero                              : Número do endereço do condomínio;   
        /// Cep                                 : Cep do condomínio;   
        /// Bairro                              : Bairro do condomínio;   
        /// Cidade                              : Município do condomínio;   
        /// Estado                              : UF do condomínio;   
        /// RefereciaId                         :
        /// LinkGeraBoleto                      :
        /// BoletoFolder                        :
        /// UrlWebServer                        :
        /// FuncionarioIdDoSindico              : Id(Guid) do síndico;   
        /// NomeDoSindico                       : Nome do síndico;   
        /// PortariaAtivada                     : Informa se as funções de portaria estão ativadas no condomínio;   
        /// PortariaParaMoradorAtivada          : Informa se as funções de portaria no app do morador estão ativada no condomínio;   
        /// ClassificadoAtivado                 : Informa se a função "classificados" esta ativada no condomínio;   
        /// ClassificadoParaMoradorAtivado      : Informa se a função "classificados" no app do morador esta ativada no condomínio;   
        /// MuralAtivado                        : Informa se a função "mural" esta ativada no condomínio;   
        /// MuralParaMoradorAtivado             : Informa se a função "mural" no app do morador esta ativada no condomínio;   
        /// ChatAtivado                         : Informa se o "chat" esta ativado no condomínio;   
        /// ChatParaMoradorAtivado              : Informa se o "chat" no app do morador esta ativado no condomínio;   
        /// ReservaAtivada                      : Informa se as funções de reservar horários em áreas comuns estão ativadas no condomínio;   
        /// ReservaNaPortariaAtivada            : Informa se as funções de reservar horários em áreas comuns estão ativadas na portaria do condomínio;   
        /// OcorrenciaAtivada                   : Informa se a função "ocorrências" esta ativada no condomínio;   
        /// OcorrenciaParaMoradorAtivada        : Informa se a função "ocorrência" no app do morador esta ativada no condomínio;   
        /// CorrespondenciaAtivada              : Informa se a função "correspondência" esta ativada no condomínio;   
        /// CorrespondenciaNaPortariaAtivada    : Informa se a função "correspondência" esta ativada na portaria do condomínio;   
        /// CadastroDeVeiculoPeloMoradorAtivado : Informa se a função cadastrar veículos pelo morador no app esta ativada;   
        /// EnqueteAtivada                      : Informa se a função "Enquete" esta ativada;   
        /// ControleDeAcessoAtivado             : Informa se as funções de controle de acesso(Áreas de acesso, carteirinha virtual) estão ativadas;   
        /// TarefaAtivada                       : Informa se a gestão de tarefas esta ativada;   
        /// OrcamentoAtivado                    : Informa se a gestão de orçamentos esta ativada;   
        /// AutomacaoAtivada                    : Informa se as funções de automação estão ativadas;   
        /// ContratoId                          : Id(Guid) do contrato com o condomínio;   
        /// DataAssinaturaContrato              : Data da assinatura do contrato;   
        /// TipoPlano                           : Tipo do plano Enum: FREE = 1, STANDARD = 2, PREMIUM = 3;   
        /// DescricaoContrato                   : Breve descrição do contrato(200 caracteres);   
        /// ContratoAtivo                       : Informa se o contrato esta ativo;   
        /// NomeArquivoContrato                 : Nome do arquivo de contrato;   
        /// NomeOriginalArquivoContrato         : Nome original do arquivo de contrato;   
        /// UrlArquivoContrato                  : Url do arquivo de contrato;           
        /// </response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CondominioFlat>>> ObterTodos()
        {
            var condominios = await _principalQuery.ObterTodos();
            if (condominios.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            return condominios.ToList();
        }

        /// <summary>
        /// Retorna um condomínio
        /// </summary>
        /// <param name="Id">Id(Guid) do condomínio</param> 
        /// <response code="200">
        /// Id                                  : Id(Guid) do condomínio;   
        /// DataDeCadastro                      : Data-hora de cadastro do condomínio;   
        /// DataDeAlteracao                     : Data-hora de alteração do condomínio;   
        /// Lixeira                             : Informa se o condomínio esta na lixeira ou não;   
        /// Cnpj                                : CNPJ do condomínio;   
        /// Nome                                : Nome do condomínio(200 caracteres);   
        /// Descricao                           : Breve descrição do condomínio(200 caracteres);    
        /// NomeArquivoLogo                     : Nome do arquivo da logo do condomínio;    
        /// NomeOriginalArquivoLogo             : Nome original do arquivo da logo do condomínio;   
        /// UrlArquivoLogo                      : Url da logo do condomínio;   
        /// Telefone                            : Telefone do condomínio;   
        /// Logradouro                          : Endereço do condomínio;   
        /// Complemento                         : Complemento do endereço do condomínio;   
        /// Numero                              : Número do endereço do condomínio;   
        /// Cep                                 : Cep do condomínio;   
        /// Bairro                              : Bairro do condomínio;   
        /// Cidade                              : Município do condomínio;   
        /// Estado                              : UF do condomínio;   
        /// RefereciaId                         :
        /// LinkGeraBoleto                      :
        /// BoletoFolder                        :
        /// UrlWebServer                        :
        /// FuncionarioIdDoSindico              : Id(Guid) do síndico;   
        /// NomeDoSindico                       : Nome do síndico;   
        /// PortariaAtivada                     : Informa se as funções de portaria estão ativadas no condomínio;   
        /// PortariaParaMoradorAtivada          : Informa se as funções de portaria no app do morador estão ativada no condomínio;   
        /// ClassificadoAtivado                 : Informa se a função "classificados" esta ativada no condomínio;   
        /// ClassificadoParaMoradorAtivado      : Informa se a função "classificados" no app do morador esta ativada no condomínio;   
        /// MuralAtivado                        : Informa se a função "mural" esta ativada no condomínio;   
        /// MuralParaMoradorAtivado             : Informa se a função "mural" no app do morador esta ativada no condomínio;   
        /// ChatAtivado                         : Informa se o "chat" esta ativado no condomínio;   
        /// ChatParaMoradorAtivado              : Informa se o "chat" no app do morador esta ativado no condomínio;   
        /// ReservaAtivada                      : Informa se as funções de reservar horários em áreas comuns estão ativadas no condomínio;   
        /// ReservaNaPortariaAtivada            : Informa se as funções de reservar horários em áreas comuns estão ativadas na portaria do condomínio;   
        /// OcorrenciaAtivada                   : Informa se a função "ocorrências" esta ativada no condomínio;   
        /// OcorrenciaParaMoradorAtivada        : Informa se a função "ocorrência" no app do morador esta ativada no condomínio;   
        /// CorrespondenciaAtivada              : Informa se a função "correspondência" esta ativada no condomínio;   
        /// CorrespondenciaNaPortariaAtivada    : Informa se a função "correspondência" esta ativada na portaria do condomínio;   
        /// CadastroDeVeiculoPeloMoradorAtivado : Informa se a função cadastrar veículos pelo morador no app esta ativada;   
        /// EnqueteAtivada                      : Informa se a função "Enquete" esta ativada;   
        /// ControleDeAcessoAtivado             : Informa se as funções de controle de acesso(Áreas de acesso, carteirinha virtual) estão ativadas;   
        /// TarefaAtivada                       : Informa se a gestão de tarefas esta ativada;   
        /// OrcamentoAtivado                    : Informa se a gestão de orçamentos esta ativada;   
        /// AutomacaoAtivada                    : Informa se as funções de automação estão ativadas;   
        /// ContratoId                          : Id(Guid) do contrato com o condomínio;   
        /// DataAssinaturaContrato              : Data da assinatura do contrato;   
        /// TipoPlano                           : Tipo do plano Enum: FREE = 1, STANDARD = 2, PREMIUM = 3;   
        /// DescricaoContrato                   : Breve descrição do contrato(200 caracteres);   
        /// ContratoAtivo                       : Informa se o contrato esta ativo;   
        /// NomeArquivoContrato                 : Nome do arquivo de contrato;   
        /// NomeOriginalArquivoContrato         : Nome original do arquivo de contrato;   
        /// UrlArquivoContrato                  : Url do arquivo de contrato;   
        /// </response>
        [HttpGet("{Id:Guid}")]
        public async Task<ActionResult<CondominioFlat>> ObterPorId(Guid Id)
        {
            var condominio = await _principalQuery.ObterPorId(Id);
            if (condominio == null)
            {
                AdicionarErroProcessamento("Condomínio não encontrado.");
                return CustomResponse();
            }
            return condominio;
        }
          
        /// <summary>
        /// Retorna condomínios que estão na lixeira
        /// </summary>
        /// <returns></returns>
        [HttpGet("Removidos")]
        public async Task<ActionResult<IEnumerable<CondominioFlat>>> ObterRemovidos()
        {            
            var condominios = await _principalQuery.ObterRemovidos();
            if (condominios.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            return condominios.ToList();
        }

        /// <summary>
        /// Retorna os condomínios do funcionário através do seu usuarioId
        /// </summary>
        /// <param name="usuarioId">Id(Guid) do usuário</param>
        /// <returns></returns>
        [HttpGet("por-funcionario/{usuarioId:Guid}")]
        public async Task<ActionResult<IEnumerable<CondominioFlat>>> ObterCondominiosDoFuncionario(Guid usuarioId)
        {
            var funcionarios = await _usuarioQuery.ObterFuncionariosPorUsuarioId(usuarioId);            
            if (funcionarios.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var condominiosIds = funcionarios.Select(x => x.CondominioId);

            var condominios = await _principalQuery.ObterPorIds(condominiosIds);

            return condominios.ToList();
        }


        /// <summary>
        /// Cadastra um novo condomínio
        /// </summary>
        /// <param name="condominioVM"></param>
        /// <response code="200">
        /// PARÂMETROS:                   
        /// Cnpj                                : CNPJ do condomínio;   
        /// Nome                                : Nome do condomínio(200 caracteres);   
        /// Descricao                           : Breve descrição do condomínio(200 caracteres);   
        /// ArquivoLogo                         : Nome do arquivo da logo do condomínio;           
        /// Telefone                            : Telefone do condomínio;   
        /// Logradouro                          : Endereço do condomínio;   
        /// Complemento                         : Complemento do endereço do condomínio;   
        /// Numero                              : Número do endereço do condomínio;   
        /// Cep                                 : Cep do condomínio;   
        /// Bairro                              : Bairro do condomínio;   
        /// Cidade                              : Município do condomínio;   
        /// Estado                              : UF do condomínio;   
        /// PortariaAtivada                     : Informa se as funções de portaria estão ativadas no condomínio;   
        /// PortariaParaMoradorAtivada          : Informa se as funções de portaria no app do morador estão ativada no condomínio;   
        /// ClassificadoAtivado                 : Informa se a função "classificados" esta ativada no condomínio;   
        /// ClassificadoParaMoradorAtivado      : Informa se a função "classificados" no app do morador esta ativada no condomínio;   
        /// MuralAtivado                        : Informa se a função "mural" esta ativada no condomínio;   
        /// MuralParaMoradorAtivado             : Informa se a função "mural" no app do morador esta ativada no condomínio;   
        /// ChatAtivado                         : Informa se o "chat" esta ativado no condomínio;   
        /// ChatParaMoradorAtivado              : Informa se o "chat" no app do morador esta ativado no condomínio;   
        /// ReservaAtivada                      : Informa se as funções de reservar horários em áreas comuns estão ativadas no condomínio;   
        /// ReservaNaPortariaAtivada            : Informa se as funções de reservar horários em áreas comuns estão ativadas na portaria do condomínio;   
        /// OcorrenciaAtivada                   : Informa se a função "ocorrências" esta ativada no condomínio;   
        /// OcorrenciaParaMoradorAtivada        : Informa se a função "ocorrência" no app do morador esta ativada no condomínio;   
        /// CorrespondenciaAtivada              : Informa se a função "correspondência" esta ativada no condomínio;   
        /// CorrespondenciaNaPortariaAtivada    : Informa se a função "correspondência" esta ativada na portaria do condomínio;   
        /// CadastroDeVeiculoPeloMoradorAtivado : Informa se a função cadastrar veículos pelo morador no app esta ativada;           
        /// EnqueteAtivada                      : Informa se a função "Enquete" esta ativada;   
        /// ControleDeAcessoAtivado             : Informa se as funções de controle de acesso(Áreas de acesso, carteirinha virtual) estão ativadas;   
        /// TarefaAtivada                       : Informa se a gestão de tarefas esta ativada;   
        /// OrcamentoAtivado                    : Informa se a gestão de orçamentos esta ativada;   
        /// AutomacaoAtivada                    : Informa se as funções de automação estão ativadas;   
        /// DataAssinaturaContrato              : Data da assinatura do contrato;   
        /// TipoPlano                           : Tipo do plano Enum: FREE = 1, STANDARD = 2, PREMIUM = 3;   
        /// DescricaoContrato                   : Breve descrição do contrato(200 caracteres);   
        /// ContratoAtivo                       : Informa se o contrato esta ativo;   
        /// QuantidadeDeUnidadesContratada      : Informa a quantidades de unidades contratadas;   
        /// ArquivoContrato                     : Arquivo do contrato;           
        /// </response>
        [HttpPost]
        public async Task<ActionResult> Post([FromForm]AdicionaCondominioViewModel condominioVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);            

            var comando = AdicionarCondominioCommandFactory(condominioVM);

            if (comando.EstaValido())
            {
                if (condominioVM.ArquivoLogo != null)
                {
                    var retorno = await _azureStorageService.SubirArquivo
                              (condominioVM.ArquivoLogo,
                               comando.Logo.NomeDoArquivo,
                               comando.Id.ToString());

                    if (!retorno.IsValid)
                        return CustomResponse(retorno);
                }

                if (condominioVM.ArquivoContrato != null)
                {
                    var retorno = await _azureStorageService.SubirArquivo
                              (condominioVM.ArquivoContrato,
                               comando.Contrato.ArquivoContrato.NomeDoArquivo,
                               comando.Id.ToString());

                    if (!retorno.IsValid)
                        return CustomResponse(retorno);
                }


            }           

            return CustomResponse(await _mediatorHandler.EnviarComando(comando));          
        }

        /// <summary>
        /// Atualiza dados do condomínio
        /// </summary>
        /// <param name="EditaCondominioVM">
        /// PARÂMETROS:    
        /// Id                                  : Id(Guid) do condomínio;   
        /// Cnpj                                : CNPJ do condomínio;   
        /// Nome                                : Nome do condomínio(200 caracteres);   
        /// Descricao                           : Breve descrição do condomínio(200 caracteres);                   
        /// Telefone                            : Telefone do condomínio;   
        /// Logradouro                          : Endereço do condomínio;   
        /// Complemento                         : Complemento do endereço do condomínio;   
        /// Numero                              : Número do endereço do condomínio;   
        /// Cep                                 : Cep do condomínio;   
        /// Bairro                              : Bairro do condomínio;   
        /// Cidade                              : Município do condomínio;   
        /// Estado                              : UF do condomínio;           
        /// </param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put(AtualizaCondominioViewModel EditaCondominioVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AtualizarCondominioCommand(
                 EditaCondominioVM.Id, EditaCondominioVM.Cnpj, EditaCondominioVM.Nome,
                 EditaCondominioVM.Descricao, EditaCondominioVM.Telefone, EditaCondominioVM.Logradouro,
                 EditaCondominioVM.Complemento, EditaCondominioVM.Numero, EditaCondominioVM.Cep,
                 EditaCondominioVM.Bairro, EditaCondominioVM.Cidade, EditaCondominioVM.Estado);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);                      
        }

        /// <summary>
        /// Atualiza os parâmetros do condomínio
        /// </summary>
        /// <param name="EditaCondominioVM">
        /// Id                                  : Guid do condomínio;   
        /// PortariaAtivada                     : Informa se as funções de portaria estão ativadas no condomínio;   
        /// PortariaParaMoradorAtivada          : Informa se as funções de portaria no app do morador estão ativada no condomínio;   
        /// ClassificadoAtivado                 : Informa se a função "classificados" esta ativada no condomínio;   
        /// ClassificadoParaMoradorAtivado      : Informa se a função "classificados" no app do morador esta ativada no condomínio;   
        /// MuralAtivado                        : Informa se a função "mural" esta ativada no condomínio;   
        /// MuralParaMoradorAtivado             : Informa se a função "mural" no app do morador esta ativada no condomínio;   
        /// ChatAtivado                         : Informa se o "chat" esta ativado no condomínio;   
        /// ChatParaMoradorAtivado              : Informa se o "chat" no app do morador esta ativado no condomínio;   
        /// ReservaAtivada                      : Informa se as funções de reservar horários em áreas comuns estão ativadas no condomínio;   
        /// ReservaNaPortariaAtivada            : Informa se as funções de reservar horários em áreas comuns estão ativadas na portaria do condomínio;   
        /// OcorrenciaAtivada                   : Informa se a função "ocorrências" esta ativada no condomínio;   
        /// OcorrenciaParaMoradorAtivada        : Informa se a função "ocorrência" no app do morador esta ativada no condomínio;   
        /// CorrespondenciaAtivada              : Informa se a função "correspondência" esta ativada no condomínio;   
        /// CorrespondenciaNaPortariaAtivada    : Informa se a função "correspondência" esta ativada na portaria do condomínio;   
        /// CadastroDeVeiculoPeloMoradorAtivado : Informa se a função cadastrar veículos pelo morador no app esta ativada;                   
        /// EnqueteAtivada                      : Informa se a função "Enquete" esta ativada;   
        /// ControleDeAcessoAtivado             : Informa se as funções de controle de acesso(Áreas de acesso, carteirinha virtual) estão ativadas;   
        /// TarefaAtivada                       : Informa se a gestão de tarefas esta ativada;   
        /// OrcamentoAtivado                    : Informa se a gestão de orçamentos esta ativada;   
        /// AutomacaoAtivada                    : Informa se as funções de automação estão ativadas;   
        /// </param>
        /// <returns></returns>
        [HttpPut("configuracao")]
        public async Task<ActionResult> PutConfiguracao(AtualizaConfiguracaoCondominioViewModel EditaCondominioVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AtualizarConfiguracaoCondominioCommand(
                 EditaCondominioVM.Id, EditaCondominioVM.PortariaAtivada, EditaCondominioVM.PortariaParaMoradorAtivada,
                 EditaCondominioVM.ClassificadoAtivado, EditaCondominioVM.ClassificadoParaMoradorAtivado, EditaCondominioVM.MuralAtivado,
                 EditaCondominioVM.MuralParaMoradorAtivado, EditaCondominioVM.ChatAtivado, EditaCondominioVM.ChatParaMoradorAtivado, 
                 EditaCondominioVM.ReservaAtivada, EditaCondominioVM.ReservaNaPortariaAtivada, EditaCondominioVM.OcorrenciaAtivada,
                 EditaCondominioVM.OcorrenciaParaMoradorAtivada, EditaCondominioVM.CorrespondenciaAtivada, 
                 EditaCondominioVM.CorrespondenciaNaPortariaAtivada, EditaCondominioVM.CadastroDeVeiculoPeloMoradorAtivado,
                 EditaCondominioVM.EnqueteAtivada, EditaCondominioVM.ControleDeAcessoAtivado, EditaCondominioVM.TarefaAtivada,
                 EditaCondominioVM.OrcamentoAtivado, EditaCondominioVM.AutomacaoAtivada);          
                    

            return CustomResponse(await _mediatorHandler.EnviarComando(comando));
        }

        /// <summary>
        /// Define o funcionário como síndico do condomínio
        /// </summary>
        /// <param name="funcionarioId">Id(Guid) do condomínio</param>
        /// <returns></returns>
        [HttpPut("definir-sindico/{funcionarioId:Guid}")]
        public async Task<ActionResult> PutDefinirSindico(Guid funcionarioId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var sindico = await _usuarioQuery.ObterFuncionarioPorId(funcionarioId);
            if (sindico == null)
            {
                AdicionarErroProcessamento("Funcionário não encontrado!");
                return CustomResponse();
            }            

            var comando = new DefinirSindicoDoCondominioCommand(
                 sindico.CondominioId, sindico.Id, sindico.NomeCompleto);                 

            return CustomResponse(await _mediatorHandler.EnviarComando(comando));
        }

        /// <summary>
        /// Atualiza a logo do condomínio
        /// </summary>
        /// <param name="EditaCondominioVM">
        /// Id                                  : Guid do condomínio;           
        /// ArquivoLogo : Arquivo da foto da logo do condomínio;                   
        /// </param>
        /// <returns></returns>
        [HttpPut("logo")]
        public async Task<ActionResult> PutAtualizaLogoDoCondominio(AtualizaLogoCondominioViewModel EditaCondominioVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var nomeOriginalLogo = StorageHelper.ObterNomeDoArquivo(EditaCondominioVM.ArquivoLogo);           

            var comando = new AtualizarLogoDoCondominioCommand(
                 EditaCondominioVM.Id, nomeOriginalLogo);

            if (comando.EstaValido() && EditaCondominioVM.ArquivoLogo != null)
            {
                var retorno = await _azureStorageService.SubirArquivo
                              (EditaCondominioVM.ArquivoLogo,
                               comando.Logo.NomeDoArquivo,
                               comando.Id.ToString());

                if (!retorno.IsValid)
                    return CustomResponse(retorno);
            }

            return CustomResponse(await _mediatorHandler.EnviarComando(comando));
        }


        /// <summary>
        /// Envia um condomínio para lixeira
        /// </summary>
        /// <param name="Id">Id(Guid) do condomínio</param>
        /// <returns></returns>
        [HttpDelete("{Id:Guid}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
           var comando = new ApagarCondominioCommand(Id);

           var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        
        private AdicionarCondominioCommand AdicionarCondominioCommandFactory(AdicionaCondominioViewModel condominioVM)
        {
            var nomeOriginalLogo = StorageHelper.ObterNomeDoArquivo(condominioVM.ArquivoLogo);
            var nomeOriginalArquivoContrato = StorageHelper.ObterNomeDoArquivo(condominioVM.ArquivoContrato);

           return new AdicionarCondominioCommand(
                 condominioVM.Cnpj, condominioVM.Nome, condominioVM.Descricao, nomeOriginalLogo,
                 condominioVM.Telefone, condominioVM.Logradouro, condominioVM.Complemento,
                 condominioVM.Numero, condominioVM.Cep, condominioVM.Bairro, condominioVM.Cidade,
                 condominioVM.Estado, condominioVM.PortariaAtivada, condominioVM.PortariaParaMoradorAtivada,
                 condominioVM.ClassificadoAtivado, condominioVM.ClassificadoParaMoradorAtivado,
                 condominioVM.MuralAtivado, condominioVM.MuralParaMoradorAtivado, condominioVM.ChatAtivado,
                 condominioVM.ChatParaMoradorAtivado, condominioVM.ReservaAtivada, condominioVM.ReservaNaPortariaAtivada,
                 condominioVM.OcorrenciaAtivada, condominioVM.OcorrenciaParaMoradorAtivada, condominioVM.CorrespondenciaAtivada,
                 condominioVM.CorrespondenciaNaPortariaAtivada, condominioVM.CadastroDeVeiculoPeloMoradorAtivado,
                 condominioVM.EnqueteAtivada, condominioVM.ControleDeAcessoAtivado, condominioVM.TarefaAtivada,
                 condominioVM.OrcamentoAtivado, condominioVM.AutomacaoAtivada, condominioVM.DataDeAssinaturaDoContrato,
                 condominioVM.Plano, condominioVM.DescricaoContrato, condominioVM.ContratoAtivo,
                 nomeOriginalArquivoContrato, condominioVM.QuantidadeDeUnidadesContratada);
        }

    }
}
