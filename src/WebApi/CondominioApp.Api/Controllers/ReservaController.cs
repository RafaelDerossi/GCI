using CondominioApp.Core.Mediator;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.ReservaAreaComum.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Aplication.ViewModels;
using CondominioApp.ReservaAreaComum.App.Aplication.Query;
using CondominioApp.ReservaAreaComum.Domain.FlatModel;
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
    [Route("api/reserva")]
    public class ReservaController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;        
        private readonly IReservaAreaComumQuery _reservaAreaComumQuery;
        private readonly IPrincipalQuery _principalQuery;
        private readonly IUsuarioQuery _usuarioQuery;


        public ReservaController
            (IMediatorHandler mediatorHandler, IReservaAreaComumQuery reservaAreaComumQuery,
            IPrincipalQuery principalQuery, IUsuarioQuery usuarioQuery)
        {
            _mediatorHandler = mediatorHandler;
            _reservaAreaComumQuery = reservaAreaComumQuery;
            _principalQuery = principalQuery;
            _usuarioQuery = usuarioQuery;
        }

        /// <summary>
        /// Retorna uma reserva
        /// </summary>
        /// <param name="id">Id(Guid) da reserva</param>
        /// <response code="200">
        /// Id: Id(Guid) da reserva;   
        /// DataDeCadastro: Data da solicitação da reserva;   
        /// DataDeAlteracao: Data de alteração da reserva;   
        /// Lixeira: Informa se a reserva esta na lixeira;   
        /// AreaComumId: Id(Guid) da área comum para qual a reserva foi solicitada;   
        /// NomeAreaComum: Nome da área comum para qual a reserva foi solicitada;   
        /// CondominioId: Id(Guid) do Condomínio ao qual a área comum pertence;   
        /// NomeCondominio: Nome do Condomínio ao qual a área comum pertence;   
        /// Capacidade: Capacidade da área comum para qual a reserva foi solicitada;   
        /// Observacao: Observações sobre a reserva;   
        /// UnidadeId: Id(Guid) da unidade a qual o solicitante da reserva pertence;   
        /// NumeroUnidade: Número da unidade a qual o solicitante da reserva pertence;   
        /// AndarUnidade: Andar da unidade a qual o solicitante da reserva pertence;   
        /// DescricaoGrupoUnidade: Grupo da unidade a qual o solicitante da reserva pertence;   
        /// MoradorId: Id(Guid) do morador que solicitou a reserva;   
        /// NomeMorador: Nome do morador que solicitou a reserva;   
        /// DataDeRealizacao: Data para a qual a reserva foi solicitada;   
        /// HoraInicio: Horário de inicio da reserva;   
        /// HoraFim: Horário de término da reserva;   
        /// Preco: Valor de custo da reserva para o solicitante;   
        /// Status: Situação da reserva: 
        /// Enum (PROCESSANDO = 0, APROVADA = 1, REPROVADA = 2,
        ///       AGUARDANDO_APROVACAO = 3, NA_FILA = 4,  CANCELADA = 5,
        ///       EXPIRADA = 6, REMOVIDA = 7);   
        /// Justificativa: Justificativa para a situação da reserva;   
        /// Origem: Origem da solicitação da reserva (Modelo do dispositivo/Sistema WEB);   
        /// CriadaPelaAdministracao: Informa se a reserva foi criada para a administração;   
        /// ReservadoPelaAdministracao: Informa de a reserva foi gerada pela administração em nome de um morador;   
        /// StatusDescricao: Descrição da situação da reserva;   
        /// Protocolo: Protocolo da reserva (Gerado automáticamente);   
        /// </response>
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

        /// <summary>
        /// Retorna últimas 500 reservas feitas no condomínio
        /// </summary>
        /// <param name="condominioId">Id(Guid) do condomínio</param>
        /// <returns></returns>
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

        /// <summary>
        /// Retorna últimas 500 reservas feitas por moradores da unidade
        /// </summary>
        /// <param name="unidadeId">Id(Guid) da unidade</param>
        /// <returns></returns>
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

        /// <summary>
        /// Retorna últimas 500 reservas feitas pelo morador
        /// </summary>
        /// <param name="moradorId">Id(Guid) do morador</param>
        /// <returns></returns>
        [HttpGet("por-morador/{moradorId:Guid}")]
        public async Task<ActionResult<IEnumerable<ReservaFlat>>> ObterPorMorador(Guid moradorId)
        {
            var reservas = await _reservaAreaComumQuery.ObterReservasPorMorador(moradorId);
            if (reservas.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }
            return reservas.ToList();
        }

        /// <summary>
        /// Retorna últimas 500 reservas feitas para a área comum
        /// </summary>
        /// <param name="areaComumId">Id(Guid) da área comum</param>
        /// <returns></returns>
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

        /// <summary>
        /// Retorna o histórico da reserva
        /// </summary>
        /// <param name="reservaId">Id(Guid) da reserva</param>
        /// <response code="200">
        /// Id: Id(Guid) do registro de histórico;   
        /// DataDeCadastro:  Data do registro;   
        /// DataDeAlteracao: Data de alteração do registro;   
        /// Lixeira: Informa se o registro esta na lixeira;   
        /// ReservaId: Id(Guid) da reserva a qual o registro se refere;   
        /// Acao: Enum da ação realiza.
        /// (SOLICITADA = 0, APROVADA = 1, REPROVADA = 2, AGUARDAR_APROVACAO = 3, 
        ///  ENVIADA_PARA_FILA = 4, RETIRADA_DA_FILA = 5, CANCELADA = 6, EXPIRADA = 7, REMOVIDA = 8);   
        /// AutorId: Id(Guid) do autor da ação;   
        /// NomeAutorAcao: nome do autor da ação;   
        /// TipoDoAutor: Enum do tipo do autor da ação. (ADMINISTRACAO = 1, MORADOR = 2, SISTEMA = 3);   
        /// Origem: Origem da ação (Modelo do dispositivo/Sistema Web);   
        /// DescricaoDaAcao: Descrição da Ação;   
        /// DescricaoTipoDoAutor: Descrição do tipo do autor;   
        /// </response>
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




        /// <summary>
        /// Solicitar uma reserva como morador
        /// </summary>
        /// <param name="reservaVM">
        /// AreaComumId: Id(Guid) da área comum para qual a reserva esta sendo solicitada;   
        /// Observacao: Observação da reserva  (240 caracteres);  
        /// MoradorId: Id(Guid) do morador que esta solicitando a reserva;   
        /// DataDeRealizacao: Data para a qual a reserva esta sendo solicitada;   
        /// HoraInicio: Horário de inicio para o qual a reserva esta sendo solicitada;   
        /// HoraFim: Horário de término para o qual a reserva esta sendo solicitada;   
        /// Preco: Valor de custo para o solicitante da reserva;   
        /// Origem:Origem da solicitação da reserva (Modelo do dispositivo/ Sistema Web) (200 caracteres);   
        /// </param>        
        [HttpPost("solicitar-como-morador")]
        public async Task<ActionResult> PostComoMorador(AdicionaReservaMoradorViewModel reservaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var morador = await _usuarioQuery.ObterMoradorPorId(reservaVM.MoradorId);
            if (morador == null)
            {
                AdicionarErroProcessamento("Morador não encontrado!");
                return CustomResponse();
            }

            var unidade = await _principalQuery.ObterUnidadePorId(morador.UnidadeId);
            if (unidade == null)
            {
                AdicionarErroProcessamento("Unidade não encontrada!");
                return CustomResponse();
            }

            var comando = SolicitarReservaComoMoradorCommandFactory(reservaVM, unidade, morador);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        /// <summary>
        /// Solicitar uma reserva como administrador
        /// </summary>
        /// <param name="reservaVM">
        /// AreaComumId: Id(Guid) da área comum para qual a reserva esta sendo solicitada;   
        /// Observacao: Observação da reserva  (240 caracteres);  
        /// MoradorId: Id(Guid) do morador para o qual a solicitação esta sendo feita;   
        /// DataDeRealizacao: Data para a qual a reserva esta sendo solicitada;   
        /// HoraInicio: Horário de inicio para o qual a reserva esta sendo solicitada;   
        /// HoraFim: Horário de término para o qual a reserva esta sendo solicitada;   
        /// Preco: Valor de custo para o solicitante da reserva;   
        /// ReservadoPelaAdministracao: Se a reserva é para a administração;   
        /// Origem:Origem da solicitação da reserva (Modelo do dispositivo/ Sistema Web) (200 caracteres);   
        /// FuncionarioId: Id(Guid) do funcionário que esta realizando a solicitação;   
        /// </param>        
        [HttpPost("solicitar-como-administrador")]
        public async Task<ActionResult> PostComoAdministrador(AdicionaReservaAdmViewModel reservaVM)
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

            var unidade = await _principalQuery.ObterUnidadePorId(morador.UnidadeId);
            if (unidade == null)
            {
                AdicionarErroProcessamento("Unidade não encontrada!");
                return CustomResponse();
            }

            var comando = SolicitarReservaComoAdministradorCommandFactory(reservaVM, unidade, morador, funcionario);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }


        /// <summary>
        /// Aprovar uma reserva que esta pendente. (Para reserva em área comum que pede aprovação da administração)
        /// </summary>
        /// <param name="reservaVM">
        /// ReservaId: Id(Guid) da reserva a ser aprovada;                   
        /// FuncionarioId: Id(Guid) do funcionário que esta realizando a aprovação;   
        /// Origem:Origem da ação (Modelo do dispositivo/ Sistema Web) (200 caracteres);   
        /// </param>
        [HttpPut("aprovar")]
        public async Task<ActionResult> PutAprovar(AprovaReservaAdmViewModel reservaVM)
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

        /// <summary>
        /// Reprovar uma reserva que esta pendente. (Para reserva em área comum que pede aprovação da administração)
        /// </summary>
        /// <param name="reservaVM">
        /// ReservaId: Id(Guid) da reserva a ser reprovada;                  
        /// Justificativa: Justificativa da reprovação  (500 caracteres);   
        /// FuncionarioId: Id(Guid) do funcionário que esta realizando a reprovação;   
        /// Origem:Origem da ação (Modelo do dispositivo/ Sistema Web) (200 caracteres);   
        /// </param>        
        [HttpPut("reprovar")]
        public async Task<ActionResult> PutReprovar(ReprovaReservaAdmViewModel reservaVM)
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


        /// <summary>
        /// Cancelar uma reserva como morador(Somente reservas solicitadas pelo próprio)
        /// </summary>
        /// <param name="reservaVM">
        /// ReservaId: Id(Guid) da reserva a ser cancelada;                  
        /// Justificativa: Justificativa do cancelamento (500 caracteres);   
        /// MoradorId: Id(Guid) do morador que esta realizando a ação;   
        /// Origem:Origem da ação (Modelo do dispositivo/ Sistema Web) (200 caracteres);   
        /// </param>        
        [HttpDelete("cancelar-como-morador")]
        public async Task<ActionResult> CancelarComoUsuario(CancelaReservaMoradorViewModel reservaVM)
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

        /// <summary>
        /// Cancelar uma reserva como administrador
        /// </summary>
        /// <param name="reservaVM">
        /// ReservaId: Id(Guid) da reserva a ser cancelada;                  
        /// Justificativa: Justificativa do cancelamento (500 caracteres);   
        /// FuncionarioId: Id(Guid) do funcionário que esta realizando a ação;   
        /// Origem: Origem da ação (Modelo do dispositivo/ Sistema Web) (200 caracteres);   
        /// </param>        
        [HttpDelete("cancelar-como-administrador")]
        public async Task<ActionResult> CancelarComoAdministrador(CancelaReservaAdmViewModel reservaVM)
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





        private SolicitarReservaComoMoradorCommand SolicitarReservaComoMoradorCommandFactory
            (AdicionaReservaMoradorViewModel reservaVM, UnidadeFlat unidade, MoradorFlat morador)
        {            
            return new SolicitarReservaComoMoradorCommand(
                  reservaVM.AreaComumId, reservaVM.Observacao, unidade.Id, unidade.Numero,
                  unidade.Andar, unidade.GrupoDescricao, morador.Id,
                  morador.NomeCompleto, reservaVM.DataDeRealizacao, reservaVM.HoraInicio, reservaVM.HoraFim,
                  reservaVM.Preco, reservaVM.Origem, false);
        }

        private SolicitarReservaComoAdministradorCommand SolicitarReservaComoAdministradorCommandFactory
           (AdicionaReservaAdmViewModel reservaVM, UnidadeFlat unidade, MoradorFlat morador, FuncionarioFlat funcionario)
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
