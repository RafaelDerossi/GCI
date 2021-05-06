using AutoMapper;
using CondominioApp.Core.Mediator;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.ReservaAreaComum.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Aplication.ViewModels;
using CondominioApp.ReservaAreaComum.App.Aplication.Query;
using CondominioApp.ReservaAreaComum.Domain.FlatModel;
using CondominioApp.Usuarios.App.Aplication.Query;
using CondominioApp.Usuarios.App.FlatModel;
using CondominioApp.Usuarios.App.Models;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("api/reserva")]
    public class ReservaController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;        
        private readonly IReservaAreaComumQuery _reservaAreaComumQuery;
        private readonly IPrincipalQuery _principalQuery;
        private readonly IUsuarioQuery _usuarioQuery;


        public ReservaController
            (IMediatorHandler mediatorHandler, IReservaAreaComumQuery reservaAreaComumQuery,
            IPrincipalQuery principalQuery, IUsuarioQuery usuarioQuery) //, IMapper mapper)
        {
            _mediatorHandler = mediatorHandler;
            _reservaAreaComumQuery = reservaAreaComumQuery;
            _principalQuery = principalQuery;
            _usuarioQuery = usuarioQuery;
        }


        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ReservaFlat>> ObterPorId(Guid id)
        {
            var reserva = await _reservaAreaComumQuery.ObterReservaPorId(id);
            if (reserva == null)
            {
                AdicionarErroProcessamento("Reserva não encontrada.");
                return CustomResponse();
            }
            return reserva;
        }

        [HttpGet("por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<ReservaFlat>>> ObterPorCondominio(Guid condominioId)
        {
            var reservas = await _reservaAreaComumQuery.ObterReservasPorCondominio(condominioId);
            if (reservas.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }
            return reservas.ToList();
        }

        [HttpGet("por-unidade/{unidadeId:Guid}")]
        public async Task<ActionResult<IEnumerable<ReservaFlat>>> ObterPorUnidade(Guid unidadeId)
        {
            var reservas = await _reservaAreaComumQuery.ObterReservasPorUnidade(unidadeId);
            if (reservas.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }
            return reservas.ToList();
        }

        [HttpGet("por-usuario/{usuarioId:Guid}")]
        public async Task<ActionResult<IEnumerable<ReservaFlat>>> ObterPorUsuario(Guid usuarioId)
        {
            var reservas = await _reservaAreaComumQuery.ObterReservasPorUsuario(usuarioId);
            if (reservas.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }
            return reservas.ToList();
        }

        [HttpGet("por-areacomum/{areaComumId:Guid}")]
        public async Task<ActionResult<IEnumerable<ReservaFlat>>> ObterPorAreaComum(Guid areaComumId)
        {
            var reservas = await _reservaAreaComumQuery.ObterReservasPorAreaComum(areaComumId);
            if (reservas.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }
            return reservas.ToList();
        }

        [HttpGet("historico/{reservaId:Guid}")]
        public async Task<ActionResult<IEnumerable<HistoricoReservaFlat>>> ObterHistoricoDaReserva(Guid reservaId)
        {
            var historico = await _reservaAreaComumQuery.ObterHistoricoDaReserva(reservaId);
            if (historico.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }
            return historico.ToList();
        }





        [HttpPost("cadastrar-como-morador")]
        public async Task<ActionResult> PostComoMorador(CadastraReservaMoradorViewModel reservaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var morador = await _usuarioQuery.ObterMoradorPorId(reservaVM.MoradorId);
            if (morador == null)
            {
                AdicionarErroProcessamento("Morador não encontrado!");
                return CustomResponse();
            }

            var unidade = await _principalQuery.ObterUnidadePorId(reservaVM.UnidadeId);
            if (unidade == null)
            {
                AdicionarErroProcessamento("Unidade não encontrada!");
                return CustomResponse();
            }

            var comando = CadastrarReservaPeloUsuarioCommandFactory(reservaVM, unidade, morador);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPost("cadastrar-como-administrador")]
        public async Task<ActionResult> PostComoAdministrador(CadastraReservaAdmViewModel reservaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var morador = await _usuarioQuery.ObterMoradorPorId(reservaVM.MoradorId);
            if (morador == null)
            {
                AdicionarErroProcessamento("Morador não encontrado!");
                return CustomResponse();
            }

            var funcionario = await _usuarioQuery.ObterFuncionarioPorId(reservaVM.FuncionarioId);
            if (funcionario == null)
            {
                AdicionarErroProcessamento("Funcionário não encontrado!");
                return CustomResponse();
            }

            var unidade = await _principalQuery.ObterUnidadePorId(reservaVM.UnidadeId);
            if (unidade == null)
            {
                AdicionarErroProcessamento("Unidade não encontrada!");
                return CustomResponse();
            }

            var comando = CadastrarReservaPelaAdmCommandFactory(reservaVM, unidade, morador, funcionario);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }



        [HttpPut("aprovar")]
        public async Task<ActionResult> PutAprovar(AprovarReservaAdmViewModel reservaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var funcionario = await _usuarioQuery.ObterFuncionarioPorId(reservaVM.FuncionarioId);
            if (funcionario == null)
            {
                AdicionarErroProcessamento("Funcionário não encontrado!");
                return CustomResponse();
            }

            var comando = new AprovarReservaPelaAdministracaoCommand
                (reservaVM.ReservaId, funcionario.Id, funcionario.NomeCompleto, reservaVM.Origem);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("reprovar")]
        public async Task<ActionResult> PutReprovar(ReprovarReservaAdmViewModel reservaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var funcionario = await _usuarioQuery.ObterFuncionarioPorId(reservaVM.FuncionarioId);
            if (funcionario == null)
            {
                AdicionarErroProcessamento("Funcionário não encontrado!");
                return CustomResponse();
            }

            var comando = new ReprovarReservaPelaAdmCommand
                (reservaVM.ReservaId, reservaVM.Justificativa, funcionario.Id, funcionario.NomeCompleto, reservaVM.Origem);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }



        [HttpDelete("cancelar-como-usuario")]
        public async Task<ActionResult> CancelarComoUsuario(CancelarReservaMoradorViewModel reservaVM)
        {

            var morador = await _usuarioQuery.ObterMoradorPorId(reservaVM.MoradorId);
            if (morador == null)
            {
                AdicionarErroProcessamento("Morador não encontrado!");
                return CustomResponse();
            }

            var comandoCancelarReserva = new CancelarReservaComoUsuarioCommand
                (reservaVM.ReservaId, reservaVM.Justificativa, morador.Id, morador.NomeCompleto, reservaVM.Origem);

            var result = await _mediatorHandler.EnviarComando(comandoCancelarReserva);
            if (!result.IsValid)
                return CustomResponse(result);

            var comando2RetirarDaFila = new RetirarReservaDaFilaCommand(reservaVM.ReservaId);
            result = await _mediatorHandler.EnviarComando(comando2RetirarDaFila);

            return CustomResponse(result);
        }

        [HttpDelete("cancelar-como-administrador")]
        public async Task<ActionResult> CancelarComoAdministrador(CancelarReservaAdmViewModel reservaVM)
        {
            var funcionario = await _usuarioQuery.ObterFuncionarioPorId(reservaVM.FuncionarioId);
            if (funcionario == null)
            {
                AdicionarErroProcessamento("Funcionário não encontrado!");
                return CustomResponse();
            }

            var comando = new CancelarReservaComoAdministradorCommand
                (reservaVM.ReservaId, reservaVM.Justificativa, funcionario.Id, funcionario.NomeCompleto, reservaVM.Origem);

            var result = await _mediatorHandler.EnviarComando(comando);
            if (!result.IsValid)
                return CustomResponse(result);

            var comandoRetirarDaFila = new RetirarReservaDaFilaCommand(reservaVM.ReservaId);
            result = await _mediatorHandler.EnviarComando(comandoRetirarDaFila);

            return CustomResponse(result);           
        }





        private SolicitarReservaComoMoradorCommand CadastrarReservaPeloUsuarioCommandFactory
            (CadastraReservaMoradorViewModel reservaVM, UnidadeFlat unidade, MoradorFlat morador)
        {            
            return new SolicitarReservaComoMoradorCommand(
                  reservaVM.AreaComumId, reservaVM.Observacao, unidade.Id, unidade.Numero,
                  unidade.Andar, unidade.GrupoDescricao, morador.Id,
                  morador.NomeCompleto, reservaVM.DataDeRealizacao, reservaVM.HoraInicio, reservaVM.HoraFim,
                  reservaVM.Preco, reservaVM.Origem, reservaVM.ReservadoPelaAdministracao);
        }

        private SolicitarReservaComoAdministradorCommand CadastrarReservaPelaAdmCommandFactory
           (CadastraReservaAdmViewModel reservaVM, UnidadeFlat unidade, MoradorFlat morador, FuncionarioFlat funcionario)
        {
            return new SolicitarReservaComoAdministradorCommand(
                  reservaVM.AreaComumId, reservaVM.Observacao, unidade.Id, unidade.Numero,
                  unidade.Andar, unidade.GrupoDescricao, morador.Id,
                  morador.NomeCompleto, reservaVM.DataDeRealizacao, reservaVM.HoraInicio, reservaVM.HoraFim,
                  reservaVM.Preco, reservaVM.Origem, reservaVM.ReservadoPelaAdministracao, funcionario.Id,
                  funcionario.NomeCompleto);
        }
    }
}
