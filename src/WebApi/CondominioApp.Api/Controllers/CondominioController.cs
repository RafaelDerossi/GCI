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

                



        [HttpPost]
        public async Task<ActionResult> Post(CadastraCondominioViewModel condominioVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new CadastrarCondominioCommand(
                 condominioVM.Cnpj, condominioVM.Nome, condominioVM.Descricao, condominioVM.LogoMarca,
                 condominioVM.NomeOriginal, condominioVM.Telefone, condominioVM.Logradouro, condominioVM.Complemento,
                 condominioVM.Numero, condominioVM.Cep, condominioVM.Bairro, condominioVM.Cidade, condominioVM.Estado,
                 condominioVM.RefereciaId, condominioVM.LinkGeraBoleto, condominioVM.BoletoFolder, condominioVM.UrlWebServer,
                 condominioVM.Portaria, condominioVM.PortariaMorador, condominioVM.Classificado, condominioVM.ClassificadoMorador,
                 condominioVM.Mural, condominioVM.MuralMorador, condominioVM.Chat, condominioVM.ChatMorador, condominioVM.Reserva,
                 condominioVM.ReservaNaPortaria, condominioVM.Ocorrencia, condominioVM.OcorrenciaMorador, condominioVM.Correspondencia,
                 condominioVM.CorrespondenciaNaPortaria, condominioVM.LimiteTempoReserva, condominioVM.DataAssinaturaContrato,
                 condominioVM.TipoDePlano, condominioVM.DescricaoContrato, condominioVM.ContratoAtivo, condominioVM.LinkContrato);
                       

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);          
        }

        [HttpPut]
        public async Task<ActionResult> Put(EditaCondominioViewModel EditaCondominioVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new EditarCondominioCommand(
                 EditaCondominioVM.Id, EditaCondominioVM.Cnpj, EditaCondominioVM.Nome,
                 EditaCondominioVM.Descricao, EditaCondominioVM.LogoMarca, EditaCondominioVM.NomeOriginal,
                 EditaCondominioVM.Telefone, EditaCondominioVM.Logradouro, EditaCondominioVM.Complemento,
                 EditaCondominioVM.Numero, EditaCondominioVM.Cep, EditaCondominioVM.Bairro, 
                 EditaCondominioVM.Cidade, EditaCondominioVM.Estado);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);                      
        }

        [HttpPut("configuracao")]
        public async Task<ActionResult> PutConfiguracao(EditaConfiguracaoCondominioViewModel EditaCondominioVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new EditarConfiguracaoCondominioCommand(
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
