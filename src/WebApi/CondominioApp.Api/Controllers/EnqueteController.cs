using AutoMapper;
using CondominioApp.Core.Mediator;
using CondominioApp.Enquetes.App.Aplication.Commands;
using CondominioApp.Enquetes.App.Aplication.Query;
using CondominioApp.Enquetes.App.Models;
using CondominioApp.Enquetes.App.ViewModels;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Usuarios.App.Aplication.Query;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("api/enquete")]
    public class EnqueteController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IEnqueteQuery _enqueteQuery;
        public readonly IMapper _mapper;
        private readonly ICondominioQuery _condominioQuery;
        private readonly IUsuarioQuery _usuarioQuery;

        public EnqueteController(IMediatorHandler mediatorHandler, IEnqueteQuery enqueteQuery, IMapper mapper, ICondominioQuery condominioQuery, IUsuarioQuery usuarioQuery)
        {
            _mediatorHandler = mediatorHandler;
            _enqueteQuery = enqueteQuery;
            _mapper = mapper;
            _condominioQuery = condominioQuery;
            _usuarioQuery = usuarioQuery;
        }



        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<EnqueteViewModel>> ObterPorId(Guid id)
        {
            var enquete = await _enqueteQuery.ObterPorId(id);
            if (enquete == null)
            {
                AdicionarErroProcessamento("Enquete não encontrada.");
                return CustomResponse();
            }
            return _mapper.Map<EnqueteViewModel>(enquete);
        }

        [HttpGet("por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<EnqueteViewModel>>> ObterEnquetesPorCondominio(Guid condominioId)
        {
            var enquetes = await _enqueteQuery.ObterPorCondominio(condominioId);
            if (enquetes.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var enquetesVM = new List<EnqueteViewModel>();
            foreach (Enquete item in enquetes)
            {
                var enqueteVM = _mapper.Map<EnqueteViewModel>(item);
                enquetesVM.Add(enqueteVM);
            }
            return enquetesVM;
        }
               
        [HttpGet("ativas-nao-votadas")]
        public async Task<ActionResult<IEnumerable<EnqueteViewModel>>> ObterEnquetesAtivasNaoVotadas(Guid condominioId, Guid usuarioId)
        {
            var enquetes = await _enqueteQuery.ObterAtivasPorCondominio(condominioId);
            if (enquetes.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var enquetesVM = new List<EnqueteViewModel>();
            foreach (Enquete enquete in enquetes)
            {
                if (!enquete.UsuarioJaVotou(usuarioId))
                {
                    var enqueteVM = _mapper.Map<EnqueteViewModel>(enquete);
                    enquetesVM.Add(enqueteVM);
                }               
            }
            return enquetesVM;
        }

        [HttpGet("ativas-por-condominio-e-usuario")]
        public async Task<ActionResult<IEnumerable<EnqueteViewModel>>> ObterEnquetesAtivasPorCondominioEUsuario(Guid condominioId, Guid usuarioId)
        {
            var enquetes = await _enqueteQuery.ObterAtivasPorCondominio(condominioId);
            if (enquetes.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }


            var enquetesVM = new List<EnqueteViewModel>();
            foreach (Enquete enquete in enquetes)
            {
                var enqueteVM = _mapper.Map<EnqueteViewModel>(enquete);
                enqueteVM.EnqueteVotada = enquete.UsuarioJaVotou(usuarioId);
                enquetesVM.Add(enqueteVM);
            }
            return enquetesVM;
        }


        [HttpPost]
        public async Task<ActionResult> Post(CadastraEnqueteViewModel enqueteVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var condominio = await _condominioQuery.ObterPorId(enqueteVM.CondominioId);
            if (condominio == null)
            {
                AdicionarErroProcessamento("Condominio não encontrado!");
                return CustomResponse();
            }

            var usuario = await _usuarioQuery.ObterPorId(enqueteVM.UsuarioId);
            if (usuario == null)
            {
                AdicionarErroProcessamento("Usuario não encontrado!");
                return CustomResponse();
            }

            var comando = new CadastrarEnqueteCommand(
                 enqueteVM.Descricao, enqueteVM.DataInicio, enqueteVM.DataFim,
                 condominio.Id, condominio.Nome,
                 usuario.Id, usuario.NomeCompleto,
                 enqueteVM.ApenasProprietarios, enqueteVM.Alternativas);           

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        [HttpPut]
        public async Task<ActionResult> Put(AlteraEnqueteViewModel enqueteVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new EditarEnqueteCommand(
                enqueteVM.Id, enqueteVM.Descricao, enqueteVM.DataInicio, 
                enqueteVM.DataFim, enqueteVM.ApenasProprietarios);


            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        [HttpDelete("{Id:Guid}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            var comando = new RemoverEnqueteCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }



        [HttpPut("alterar-alternativa")]
        public async Task<ActionResult> Put(AlterarAlternativaViewModel alternativaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new EditarAlternativaCommand(
                alternativaVM.Id, alternativaVM.Descricao);


            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        [HttpDelete("remover-alternativa/{alternativaId:Guid}")]
        public async Task<ActionResult> DeleteAlternativa(Guid alternativaId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new RemoverAlternativaCommand(alternativaId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }


        [HttpPost("votar-enquete")]
        public async Task<ActionResult> VotarEnquete(VotoEnqueteViewModel votoEnqueteVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var unidade = await _condominioQuery.ObterUnidadePorId(votoEnqueteVM.UnidadeId);
            if (unidade == null)
            {
                AdicionarErroProcessamento("Unidade não encontrada!");
                return CustomResponse();
            }

            var usuario = await _usuarioQuery.ObterPorId(votoEnqueteVM.UsuarioId);
            if (usuario == null)
            {
                AdicionarErroProcessamento("Usuario não encontrado!");
                return CustomResponse();
            }


            var comando = new CadastrarRespostaCommand(
                unidade.Id, unidade.Numero, unidade.GrupoDescricao,
                usuario.Id, usuario.NomeCompleto, usuario.TpUsuario.ToString(), 
                votoEnqueteVM.AlternativaId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

    }
}
