using AutoMapper;
using CondominioApp.Core.Mediator;
using CondominioApp.ReservaAreaComum.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Aplication.ViewModels;
using CondominioApp.ReservaAreaComum.App.Aplication.Query;
using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Domain.FlatModel;
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
        private readonly IReservaAreaComumQuery _reservaAreaComumQuery;

        public ReservaController(IMediatorHandler mediatorHandler, IReservaAreaComumQuery reservaAreaComumQuery) //, IMapper mapper)
        {
            _mediatorHandler = mediatorHandler;
            _reservaAreaComumQuery = reservaAreaComumQuery;
            //_mapper = mapper;
        }


        [HttpGet("{id:Guid}")]
        public async Task<ReservaFlat> ObterPorId(Guid id)
        {
            return await _reservaAreaComumQuery.ObterReservaPorId(id);
        }

        [HttpGet("por-condominio/{condominioId:Guid}")]
        public async Task<IEnumerable<ReservaFlat>> ObterPorCondominio(Guid condominioId)
        {
           return await _reservaAreaComumQuery.ObterReservasPorCondominio(condominioId);
        }

        [HttpGet("por-unidade/{unidadeId:Guid}")]
        public async Task<IEnumerable<ReservaFlat>> ObterPorUnidade(Guid unidadeId)
        {
            return await _reservaAreaComumQuery.ObterReservasPorUnidade(unidadeId);
        }

        [HttpGet("por-usuario/{usuarioId:Guid}")]
        public async Task<IEnumerable<ReservaFlat>> ObterPorUsuario(Guid usuarioId)
        {
            return await _reservaAreaComumQuery.ObterReservasPorUsuario(usuarioId);
        }



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
            var comandoCancelarReserva = new CancelarReservaComoUsuarioCommand(cancelarReservaVM.ReservaId, cancelarReservaVM.Justificativa);

            var result = await _mediatorHandler.EnviarComando(comandoCancelarReserva);
            if (!result.IsValid)
                return CustomResponse(result);

            var comando2RetirarDaFila = new RetirarReservaDaFilaCommand(cancelarReservaVM.ReservaId);
            result = await _mediatorHandler.EnviarComando(comando2RetirarDaFila);

            return CustomResponse(result);
        }

        [HttpDelete("cancelar-como-administrador")]
        public async Task<ActionResult> CancelarComoAdministrador(CancelarReservaViewModel cancelarReservaVM)
        {
            var comando = new CancelarReservaComoAdministradorCommand(cancelarReservaVM.ReservaId, cancelarReservaVM.Justificativa);

            var result = await _mediatorHandler.EnviarComando(comando);
            if (!result.IsValid)
                return CustomResponse(result);

            var comandoRetirarDaFila = new RetirarReservaDaFilaCommand(cancelarReservaVM.ReservaId);
            result = await _mediatorHandler.EnviarComando(comandoRetirarDaFila);

            return CustomResponse(result);           
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
