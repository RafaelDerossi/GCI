using AutoMapper;
using CondominioApp.Core.Mediator;
using CondominioApp.ReservaAreaComum.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Aplication.ViewModels;
using CondominioApp.ReservaAreaComum.App.Aplication.Query;
using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("api/reserva")]
    public class ReservaController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        //private readonly IMapper _mapper;
        //private readonly IAreaComumQuery _areaComumQuery;

        public ReservaController(IMediatorHandler mediatorHandler) //, IMapper mapper, IAreaComumQuery areaComumQuery)
        {
            _mediatorHandler = mediatorHandler;
            //_mapper = mapper;
            //_areaComumQuery = areaComumQuery;
        }


        //[HttpGet("{id:Guid}")]
        //public async Task<AreaComumViewModel> ObterPorId(Guid id)
        //{
        //    return _mapper.Map<AreaComumViewModel>(await _areaComumQuery.ObterPorId(id));
        //}

        //[HttpGet("por-condominio/{condominioId:Guid}")]
        //public async Task<IEnumerable<AreaComumViewModel>> ObterPorCondominio(Guid condominioId)
        //{
        //    var lista = await _areaComumQuery.ObterPorCondominio(condominioId);

        //    var listaVM = new List<AreaComumViewModel>();
        //    foreach (AreaComum areaComum in lista)
        //    {
        //        listaVM.Add(_mapper.Map<AreaComumViewModel>(areaComum));
        //    }

        //    return listaVM;          
        //}



        [HttpPost]
        public async Task<ActionResult> Post(CadastraReservaViewModel reservaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = CadastrarReservaCommandFactory(reservaVM);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("aprovar/{id:Guid}")]
        public async Task<ActionResult> PutAprovar(Guid id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AprovarReservaCommand(id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpDelete("cancelar-como-usuario")]
        public async Task<ActionResult> CancelarComoUsuario(CancelarReservaViewModel cancelarReservaVM)
        {
            var comando = new CancelarReservaComoUsuarioCommand(cancelarReservaVM.ReservaId, cancelarReservaVM.Justificativa);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpDelete("cancelar-como-administrador")]
        public async Task<ActionResult> CancelarComoAdministrador(CancelarReservaViewModel cancelarReservaVM)
        {
            var comando = new CancelarReservaComoAdministradorCommand(cancelarReservaVM.ReservaId, cancelarReservaVM.Justificativa);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }





        private CadastrarReservaCommand CadastrarReservaCommandFactory(CadastraReservaViewModel reservaVM)
        {            
            return new CadastrarReservaCommand(
                  reservaVM.AreaComumId, reservaVM.Observacao, reservaVM.UnidadeId, reservaVM.NumeroUnidade,
                  reservaVM.AndarUnidade, reservaVM.DescricaoGrupoUnidade, reservaVM.UsuarioId,
                  reservaVM.NomeUsuario, reservaVM.DataDeRealizacao, reservaVM.HoraInicio, reservaVM.HoraFim,
                  reservaVM.Preco, reservaVM.EstaNaFila, reservaVM.Origem, reservaVM.ReservadoPelaAdministracao);
        }


    }
}
