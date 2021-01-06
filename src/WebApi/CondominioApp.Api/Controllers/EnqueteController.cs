using AutoMapper;
using CondominioApp.Core.Mediator;
using CondominioApp.Enquetes.App.Aplication.Commands;
using CondominioApp.Enquetes.App.Aplication.Query;
using CondominioApp.Enquetes.App.Models;
using CondominioApp.Enquetes.App.ViewModels;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("api/enquete")]
    public class EnqueteController : MainController
    {

        private readonly IMediatorHandler _mediatorHandler;

        private readonly IEnqueteQuery _enqueteQuery;

        public readonly IMapper _mapper;

        public EnqueteController(IMediatorHandler mediatorHandler, IEnqueteQuery enqueteQuery, IMapper mapper)
        {
            _mediatorHandler = mediatorHandler;
            _enqueteQuery = enqueteQuery;
            _mapper = mapper;
        }


        [HttpGet("{id:Guid}")]
        public async Task<EnqueteViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<EnqueteViewModel>(await _enqueteQuery.ObterPorId(id));
        }

        [HttpGet("por-condominio/{condominioId:Guid}")]
        public async Task<IEnumerable<EnqueteViewModel>> ObterEnquetesPorCondominio(Guid condominioId)
        {
            var enquetes = await _enqueteQuery.ObterPorCondominio(condominioId);

            var enquetesVM = new List<EnqueteViewModel>();
            foreach (Enquete item in enquetes)
            {
                var enqueteVM = _mapper.Map<EnqueteViewModel>(item);
                enquetesVM.Add(enqueteVM);
            }
            return enquetesVM;
        }
               
        [HttpGet("ativas-nao-votadas")]
        public async Task<IEnumerable<EnqueteViewModel>> ObterEnquetesAtivasNaoVotadas(Guid condominioId, Guid usuarioId)
        {
            var enquetes = await _enqueteQuery.ObterAtivasPorCondominio(condominioId);

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
        public async Task<IEnumerable<EnqueteViewModel>> ObterEnquetesAtivasPorCondominioEUsuario(Guid condominioId, Guid usuarioId)
        {
            var enquetes = await _enqueteQuery.ObterAtivasPorCondominio(condominioId);

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

            var comando = new CadastrarEnqueteCommand(
                 enqueteVM.Descricao, enqueteVM.DataInicio, enqueteVM.DataFim,
                 enqueteVM.CondominioId, enqueteVM.CondominioNome,
                 enqueteVM.UsuarioId, enqueteVM.UsuarioNome,
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

            var comando = new CadastrarRespostaCommand(
                votoEnqueteVM.UnidadeId, votoEnqueteVM.Unidade, votoEnqueteVM.Bloco,
                votoEnqueteVM.UsuarioId, votoEnqueteVM.UsuarioNome, votoEnqueteVM.TipoDeUsuario, 
                votoEnqueteVM.AlternativaId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }
    }
}
