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

            var comando = CadastrarCondominioCommandFactory(condominioVM);

            if (!OperacaoValida())
            {
                return CustomResponse();
            }

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            if (!Resultado.IsValid)
            {
                return CustomResponse(Resultado);
            }

            foreach (var error in Resultado.Errors)
            {
                AdicionarErroProcessamento(error.ErrorMessage);
            }

            return CustomResponse();
        }

        [HttpPut("Alterar-condominio")]
        public async Task<ActionResult> Put(AlteraCondominioViewModel AlteraCondominioVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);


            var comando = AlterarCondominioCommandFactory(AlteraCondominioVM);

            if (!OperacaoValida())
            {
                return CustomResponse();
            }

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            if (!Resultado.IsValid)
            {
                return CustomResponse(Resultado);
            }

            foreach (var error in Resultado.Errors)
            {
                AdicionarErroProcessamento(error.ErrorMessage);
            }

            return CustomResponse();
        }

        [HttpPut("Alterar-configuracaoCondominio")]
        public async Task<ActionResult> Put(AlteraConfiguracaoCondominioViewModel AlteraCondominioVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);


            var comando = AlterarConfiguracaoCondominioCommandFactory(AlteraCondominioVM);

            if (!OperacaoValida())
            {
                return CustomResponse();
            }

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            if (!Resultado.IsValid)
            {
                return CustomResponse(Resultado);
            }

            foreach (var error in Resultado.Errors)
            {
                AdicionarErroProcessamento(error.ErrorMessage);
            }

            return CustomResponse();
        }

        [HttpPost("Novo-grupo")]
        public async Task<ActionResult> Post(GrupoViewModel grupoVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);


            var comando = CadastrarGrupoCommandFactory(grupoVM);

            if (!OperacaoValida())
            {
                return CustomResponse();
            }

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            if (!Resultado.IsValid)
            {
                return CustomResponse(Resultado);
            }

            foreach (var error in Resultado.Errors)
            {
                AdicionarErroProcessamento(error.ErrorMessage);
            }

            return CustomResponse();
        }

        [HttpPut("Alterar-grupo")]
        public async Task<ActionResult> Put(GrupoViewModel grupoVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);


            var comando = AlterarGrupoCommandFactory(grupoVM);

            if (!OperacaoValida())
            {
                return CustomResponse();
            }

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            if (!Resultado.IsValid)
            {
                return CustomResponse(Resultado);
            }

            foreach (var error in Resultado.Errors)
            {
                AdicionarErroProcessamento(error.ErrorMessage);
            }

            return CustomResponse();
        }

        [HttpPost("Nova-unidade")]
        public async Task<ActionResult> Post(UnidadeViewModel unidadeVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);


            var comando = CadastrarUnidadeCommandFactory(unidadeVM);

            if (!OperacaoValida())
            {
                return CustomResponse();
            }

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            if (!Resultado.IsValid)
            {
                return CustomResponse(Resultado);
            }

            foreach (var error in Resultado.Errors)
            {
                AdicionarErroProcessamento(error.ErrorMessage);
            }

            return CustomResponse();
        }

        [HttpPut("Alterar-unidade")]
        public async Task<ActionResult> Put(UnidadeViewModel unidadeVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = AlterarUnidadeCommandFactory(unidadeVM);

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
        

        /// Factories

        private CadastrarCondominioCommand CadastrarCondominioCommandFactory(CondominioViewModel condominioVM)
        {
            try
            {
                return new CadastrarCondominioCommand(
                 condominioVM.Cnpj, condominioVM.Nome, condominioVM.Descricao, condominioVM.LogoMarca,
                 condominioVM.NomeOriginal, condominioVM.Telefone, condominioVM.RefereciaId, condominioVM.LinkGeraBoleto,
                 condominioVM.BoletoFolder, condominioVM.UrlWebServer, condominioVM.Portaria, condominioVM.PortariaMorador,
                 condominioVM.Classificado, condominioVM.ClassificadoMorador, condominioVM.Mural, condominioVM.MuralMorador,
                 condominioVM.Chat, condominioVM.ChatMorador, condominioVM.Reserva, condominioVM.ReservaNaPortaria,
                 condominioVM.Ocorrencia, condominioVM.OcorrenciaMorador, condominioVM.Correspondencia,
                 condominioVM.CorrespondenciaNaPortaria, condominioVM.LimiteTempoReserva);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return null;
            }
        }

        private CadastrarGrupoCommand CadastrarGrupoCommandFactory(GrupoViewModel grupoVM)
        {
            try
            {
                return new CadastrarGrupoCommand(
                 grupoVM.Descricao, grupoVM.CondominioId);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return null;
            }
        }

        private CadastrarUnidadeCommand CadastrarUnidadeCommandFactory(UnidadeViewModel unidadeVM)
        {
            try
            {
                return new CadastrarUnidadeCommand(
                unidadeVM.Codigo, unidadeVM.Numero, unidadeVM.Andar,
                unidadeVM.Vagas, unidadeVM.Telefone, unidadeVM.Ramal, unidadeVM.Complemento,
                unidadeVM.GrupoId, unidadeVM.CondominioId);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return null;
            }
        }

        private AlterarUnidadeCommand AlterarUnidadeCommandFactory(UnidadeViewModel unidadeVM)
        {
            return new AlterarUnidadeCommand(
            unidadeVM.UnidadeId, unidadeVM.Numero, unidadeVM.Andar,
            unidadeVM.Vagas, unidadeVM.Telefone, unidadeVM.Ramal, unidadeVM.Complemento,
            unidadeVM.GrupoId, unidadeVM.CondominioId);
        }

        private AlterarGrupoCommand AlterarGrupoCommandFactory(GrupoViewModel grupoVM)
        {
            try
            {
                return new AlterarGrupoCommand(
                grupoVM.GrupoId, grupoVM.Descricao);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return null;
            }
        }

        private AlterarCondominioCommand AlterarCondominioCommandFactory(AlteraCondominioViewModel condominioVM)
        {
            try
            {
                return new AlterarCondominioCommand(
                 condominioVM.CodominioId, condominioVM.Cnpj, condominioVM.Nome, condominioVM.Descricao, condominioVM.LogoMarca,
                 condominioVM.NomeOriginal, condominioVM.Telefone);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return null;
            }
        }

        private AlterarConfiguracaoCondominioCommand AlterarConfiguracaoCondominioCommandFactory(AlteraConfiguracaoCondominioViewModel condominioVM)
        {
            try
            {
                return new AlterarConfiguracaoCondominioCommand(
                 condominioVM.CodominioId, condominioVM.Portaria, condominioVM.PortariaMorador,
                 condominioVM.Classificado, condominioVM.ClassificadoMorador, condominioVM.Mural, condominioVM.MuralMorador,
                 condominioVM.Chat, condominioVM.ChatMorador, condominioVM.Reserva, condominioVM.ReservaNaPortaria,
                 condominioVM.Ocorrencia, condominioVM.OcorrenciaMorador, condominioVM.Correspondencia,
                 condominioVM.CorrespondenciaNaPortaria, condominioVM.LimiteTempoReserva);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return null;
            }
        }


    }
}
