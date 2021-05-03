using AutoMapper;
using CondominioApp.Core.Mediator;
using CondominioApp.Enquetes.App.Aplication.Commands;
using CondominioApp.Enquetes.App.Aplication.Query;
using CondominioApp.Enquetes.App.Models;
using CondominioApp.Enquetes.App.ViewModels;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.Usuarios.App.Aplication.Query;
using CondominioApp.Usuarios.App.FlatModel;
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
        private readonly IPrincipalQuery _principalQuery;
        private readonly IUsuarioQuery _usuarioQuery;

        public EnqueteController
            (IMediatorHandler mediatorHandler, IEnqueteQuery enqueteQuery, IMapper mapper,
            IPrincipalQuery principalQuery, IUsuarioQuery usuarioQuery)
        {
            _mediatorHandler = mediatorHandler;
            _enqueteQuery = enqueteQuery;
            _mapper = mapper;
            _principalQuery = principalQuery;
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

            var enqueteVM = _mapper.Map<EnqueteViewModel>(enquete);

            enqueteVM.CalcularPorcentagem();

            enqueteVM.OrdenarAlternativas();

            return enqueteVM;
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
                enqueteVM.CalcularPorcentagem();
                enqueteVM.OrdenarAlternativas();
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
                    enqueteVM.CalcularPorcentagem();
                    enqueteVM.OrdenarAlternativas();
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
                enqueteVM.CalcularPorcentagem();
                enqueteVM.OrdenarAlternativas();
                enquetesVM.Add(enqueteVM);
            }
            return enquetesVM;
        }


        [HttpPost]
        public async Task<ActionResult> Post(CadastraEnqueteViewModel enqueteVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var condominio = await _principalQuery.ObterPorId(enqueteVM.CondominioId);
            if (condominio == null)
            {
                AdicionarErroProcessamento("Condominio não encontrado!");
                return CustomResponse();
            }

            var funcionario = await _usuarioQuery.ObterFuncionarioPorId(enqueteVM.FuncionarioId);
            if (funcionario == null)
            {
                AdicionarErroProcessamento("Funcionário não encontrado!");
                return CustomResponse();
            }

            var comando = CadastrarEnqueteCommandFactory(enqueteVM, funcionario, condominio);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        [HttpPut]
        public async Task<ActionResult> Put(EditaEnqueteViewModel enqueteVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = EditarEnqueteCommandFactory(enqueteVM);

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
        public async Task<ActionResult> Put(AlteraAlternativaViewModel alternativaVM)
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

            var unidade = await _principalQuery.ObterUnidadePorId(votoEnqueteVM.UnidadeId);
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
                usuario.Id, usuario.NomeCompleto, votoEnqueteVM.TipoDeUsuario.ToString(), 
                votoEnqueteVM.AlternativaId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }


        private CadastrarEnqueteCommand CadastrarEnqueteCommandFactory
            (CadastraEnqueteViewModel enqueteVM, FuncionarioFlat funcionario, CondominioFlat condominio)
        {
            var alternativas = new List<AlternativaEnquete>();
            if(enqueteVM.Alternativas != null)
            {
                foreach (var alternativaVM in enqueteVM.Alternativas)
                {
                    var alternativa = new AlternativaEnquete(alternativaVM.Descricao, alternativaVM.Ordem);
                    alternativas.Add(alternativa);
                }
            }            

            return new CadastrarEnqueteCommand(
                 enqueteVM.Descricao, enqueteVM.DataInicio, enqueteVM.DataFim,
                 condominio.Id, condominio.Nome, funcionario.Id, funcionario.NomeCompleto(),
                 enqueteVM.ApenasProprietarios, alternativas);
        }

        private EditarEnqueteCommand EditarEnqueteCommandFactory(EditaEnqueteViewModel enqueteVM)
        {
            var alternativas = new List<AlternativaEnquete>();
            if (enqueteVM.Alternativas != null)
            {
                foreach (var alternativaVM in enqueteVM.Alternativas)
                {
                    var alternativa = new AlternativaEnquete(alternativaVM.Descricao, alternativaVM.Ordem);
                    alternativas.Add(alternativa);
                }
            }

            return new EditarEnqueteCommand(
                 enqueteVM.Id, enqueteVM.Descricao, enqueteVM.DataInicio, enqueteVM.DataFim,
                 enqueteVM.ApenasProprietarios, alternativas);
        }
    }
}
