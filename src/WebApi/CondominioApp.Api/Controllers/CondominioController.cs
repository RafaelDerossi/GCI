using CondominioApp.Core.Mediator;
using CondominioApp.Principal.Aplication.Commands;
using CondominioApp.Principal.Aplication.ViewModels;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("api/principal")]
    [ApiController]
    public class CondominioController : MainController
    {

        private readonly IMediatorHandler _mediatorHandler;

        public CondominioController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }


        [HttpPost("Novo-condominio")]
        public async Task<ActionResult> Post(CondominioViewModel condominioVM)
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
                 condominioVM.CorrespondenciaNaPortaria, condominioVM.LimiteTempoReserva);           

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);          
        }

        [HttpPut("Alterar-condominio")]
        public async Task<ActionResult> Put(AlteraCondominioViewModel AlteraCondominioVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AlterarCondominioCommand(
                 AlteraCondominioVM.CodominioId, AlteraCondominioVM.Cnpj, AlteraCondominioVM.Nome,
                 AlteraCondominioVM.Descricao, AlteraCondominioVM.LogoMarca, AlteraCondominioVM.NomeOriginal,
                 AlteraCondominioVM.Telefone, AlteraCondominioVM.Logradouro, AlteraCondominioVM.Complemento,
                 AlteraCondominioVM.Numero, AlteraCondominioVM.Cep, AlteraCondominioVM.Bairro, 
                 AlteraCondominioVM.Cidade, AlteraCondominioVM.Estado);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);                      
        }

        [HttpPut("Alterar-configuracaoCondominio")]
        public async Task<ActionResult> Put(AlteraConfiguracaoCondominioViewModel AlteraCondominioVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);


            var comando = new AlterarConfiguracaoCondominioCommand(
                 AlteraCondominioVM.CodominioId, AlteraCondominioVM.Portaria, AlteraCondominioVM.PortariaMorador,
                 AlteraCondominioVM.Classificado, AlteraCondominioVM.ClassificadoMorador, AlteraCondominioVM.Mural,
                 AlteraCondominioVM.MuralMorador, AlteraCondominioVM.Chat, AlteraCondominioVM.ChatMorador, 
                 AlteraCondominioVM.Reserva, AlteraCondominioVM.ReservaNaPortaria, AlteraCondominioVM.Ocorrencia,
                 AlteraCondominioVM.OcorrenciaMorador, AlteraCondominioVM.Correspondencia, 
                 AlteraCondominioVM.CorrespondenciaNaPortaria, AlteraCondominioVM.LimiteTempoReserva);

            
            var Resultado = await _mediatorHandler.EnviarComando(comando);            

            return CustomResponse(Resultado);
        }

        [HttpDelete("Remover-condominio")]
        public async Task<ActionResult> Delete(Guid condominioId)
        {
           var comando = new RemoverCondominioCommand(condominioId);

           var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPost("Novo-grupo")]
        public async Task<ActionResult> Post(GrupoViewModel grupoVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando =  new CadastrarGrupoCommand(
                 grupoVM.Descricao, grupoVM.CondominioId);           

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
           
        }

        [HttpPut("Alterar-grupo")]
        public async Task<ActionResult> Put(GrupoViewModel grupoVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AlterarGrupoCommand(
                grupoVM.GrupoId, grupoVM.Descricao);

          
            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        [HttpDelete("Remover-grupo")]
        public async Task<ActionResult> DeleteGrupo(Guid grupoId)
        {
            var comando = new RemoverGrupoCommand(grupoId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPost("Nova-unidade")]
        public async Task<ActionResult> Post(UnidadeViewModel unidadeVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new CadastrarUnidadeCommand(
                unidadeVM.Codigo, unidadeVM.Numero, unidadeVM.Andar,
                unidadeVM.Vagas, unidadeVM.Telefone, unidadeVM.Ramal, unidadeVM.Complemento,
                unidadeVM.GrupoId, unidadeVM.CondominioId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
            
        }

        [HttpPut("Alterar-unidade")]
        public async Task<ActionResult> Put(UnidadeViewModel unidadeVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AlterarUnidadeCommand(
            unidadeVM.UnidadeId, unidadeVM.Numero, unidadeVM.Andar,
            unidadeVM.Vagas, unidadeVM.Telefone, unidadeVM.Ramal, unidadeVM.Complemento,
            unidadeVM.GrupoId, unidadeVM.CondominioId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("ResetCodigo-unidade")]
        public async Task<ActionResult> Put(Guid unidadeId)
        {
            var comando = new ResetCodigoUnidadeCommand(unidadeId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpDelete("Remover-unidade")]
        public async Task<ActionResult> DeleteUnidade(Guid unidadeId)
        {
            var comando = new RemoverUnidadeCommand(unidadeId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

    }
}
