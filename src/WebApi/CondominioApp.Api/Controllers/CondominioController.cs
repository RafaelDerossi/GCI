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
        public CondominioController
            (IMediatorHandler mediatorHandler, IPrincipalQuery principalQuery, IUsuarioQuery usuarioQuery)
        {
            _mediatorHandler = mediatorHandler;
            _principalQuery = principalQuery;
            _usuarioQuery = usuarioQuery;
        }


        /// <summary>
        /// Retorna todos os condomínios cadastrados
        /// </summary>        
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
        /// UrlLogoMarca                        : Url da logo do condomínio;
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
        /// Cadastra um novo condomínio
        /// </summary>
        /// <param name="condominioVM"></param>
        /// <response code="200">
        /// PARÂMETROS:           
        /// Cnpj                                : CNPJ do condomínio;
        /// Nome                                : Nome do condomínio(200 caracteres);
        /// Descricao                           : Breve descrição do condomínio(200 caracteres);   
        /// ArquivoLogo                         : Nome do arquivo da logo do condomínio;   
        /// NomeOriginalArquivoLogo             : Nome original do arquivo da logo do condomínio;   
        /// UrlLogoMarca                        : Url da logo do condomínio;
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
        /// DataAssinaturaContrato              : Data da assinatura do contrato;   
        /// TipoPlano                           : Tipo do plano Enum: FREE = 1, STANDARD = 2, PREMIUM = 3;   
        /// DescricaoContrato                   : Breve descrição do contrato(200 caracteres);   
        /// ContratoAtivo                       : Informa se o contrato esta ativo;   
        /// QuantidadeDeUnidadesContratada      : Informa a quantidades de unidades contratadas;   
        /// ArquivoContrato                     : Arquivo do contrato;           
        /// </response>
        [HttpPost]
        public async Task<ActionResult> Post(AdicionaCondominioViewModel condominioVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var nomeOriginalLogo = StorageHelper.ObterNomeDoArquivo(condominioVM.ArquivoLogo);
            var nomeOriginalArquivoContrato = StorageHelper.ObterNomeDoArquivo(condominioVM.ArquivoContrato);

            var comando = new AdicionarCondominioCommand(
                 condominioVM.Cnpj, condominioVM.Nome, condominioVM.Descricao, nomeOriginalLogo,
                 condominioVM.Telefone, condominioVM.Logradouro, condominioVM.Complemento,
                 condominioVM.Numero, condominioVM.Cep, condominioVM.Bairro, condominioVM.Cidade,
                 condominioVM.Estado, condominioVM.PortariaAtivada, condominioVM.PortariaParaMoradorAtivada,
                 condominioVM.ClassificadoAtivado, condominioVM.ClassificadoParaMoradorAtivado,
                 condominioVM.MuralAtivado, condominioVM.MuralParaMoradorAtivado, condominioVM.ChatAtivado,
                 condominioVM.ChatParaMoradorAtivado, condominioVM.ReservaAtivada, condominioVM.ReservaNaPortariaAtivada,
                 condominioVM.OcorrenciaAtivada, condominioVM.OcorrenciaParaMoradorAtivada, condominioVM.CorrespondenciaAtivada,
                 condominioVM.CorrespondenciaNaPortariaAtivada, condominioVM.CadastroDeVeiculoPeloMoradorAtivado,
                 condominioVM.DataAssinaturaContrato, condominioVM.TipoDePlano, condominioVM.DescricaoContrato,
                 condominioVM.ContratoAtivo, nomeOriginalArquivoContrato, condominioVM.QuantidadeDeUnidadesContratada);
                       

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);          
        }

        [HttpPut]
        public async Task<ActionResult> Put(AtualizaCondominioViewModel EditaCondominioVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AtualizarCondominioCommand(
                 EditaCondominioVM.Id, EditaCondominioVM.Cnpj, EditaCondominioVM.Nome,
                 EditaCondominioVM.Descricao, EditaCondominioVM.LogoMarca, EditaCondominioVM.NomeOriginal,
                 EditaCondominioVM.Telefone, EditaCondominioVM.Logradouro, EditaCondominioVM.Complemento,
                 EditaCondominioVM.Numero, EditaCondominioVM.Cep, EditaCondominioVM.Bairro, 
                 EditaCondominioVM.Cidade, EditaCondominioVM.Estado);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);                      
        }

        [HttpPut("configuracao")]
        public async Task<ActionResult> PutConfiguracao(AtualizaConfiguracaoCondominioViewModel EditaCondominioVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AtualizarConfiguracaoCondominioCommand(
                 EditaCondominioVM.Id, EditaCondominioVM.Portaria, EditaCondominioVM.PortariaMorador,
                 EditaCondominioVM.Classificado, EditaCondominioVM.ClassificadoMorador, EditaCondominioVM.Mural,
                 EditaCondominioVM.MuralMorador, EditaCondominioVM.Chat, EditaCondominioVM.ChatMorador, 
                 EditaCondominioVM.Reserva, EditaCondominioVM.ReservaNaPortaria, EditaCondominioVM.Ocorrencia,
                 EditaCondominioVM.OcorrenciaMorador, EditaCondominioVM.Correspondencia, 
                 EditaCondominioVM.CorrespondenciaNaPortaria, EditaCondominioVM.LimiteTempoReserva);          
                    

            return CustomResponse(await _mediatorHandler.EnviarComando(comando));
        }

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

        [HttpDelete("{Id:Guid}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
           var comando = new ApagarCondominioCommand(Id);

           var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }
    }
}
