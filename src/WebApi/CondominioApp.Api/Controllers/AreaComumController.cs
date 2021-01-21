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
    [Route("api/areacomum")]
    public class AreaComumController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;
        private readonly IReservaAreaComumQuery _areaComumQuery;

        public AreaComumController(IMediatorHandler mediatorHandler, IMapper mapper, IReservaAreaComumQuery areaComumQuery)
        {
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
            _areaComumQuery = areaComumQuery;
        }


        [HttpGet("{id:Guid}")]
        public async Task<AreaComumFlat> ObterPorId(Guid id)
        {
            return await _areaComumQuery.ObterPorId(id);
        }

        [HttpGet("por-condominio/{condominioId:Guid}")]
        public async Task<IEnumerable<AreaComumFlat>> ObterPorCondominio(Guid condominioId)
        {
            return await _areaComumQuery.ObterPorCondominio(condominioId);                  
        }



        [HttpPost]
        public async Task<ActionResult> Post(CadastraAreaComumViewModel areaComumVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = CadastrarAreaComumCommandFactory(areaComumVM);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut]
        public async Task<ActionResult> Put(EditaAreaComumViewModel areaComumVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = EditarAreaComumCommandFactory(areaComumVM);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpDelete("{Id:Guid}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            var comando = new RemoverAreaComumCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }


        [HttpPut("ativar/{Id:Guid}")]
        public async Task<ActionResult> AtivarAreaComum(Guid Id)
        {
            var comando = new AtivarAreaComumCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("desativar/{Id:Guid}")]
        public async Task<ActionResult> DesativarAreaComum(Guid Id)
        {
            var comando = new DesativarAreaComumCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }




        private CadastrarAreaComumCommand CadastrarAreaComumCommandFactory(CadastraAreaComumViewModel areaComumVM)
        {
            var listaPeriodos = new List<Periodo>();
            if (areaComumVM.Periodos != null)
            {
                foreach (PeriodoViewModel periodoVM in areaComumVM.Periodos)
                {
                    var periodo = _mapper.Map<Periodo>(periodoVM);                   
                    listaPeriodos.Add(periodo);
                }
            }
           return new CadastrarAreaComumCommand(
                 areaComumVM.Nome, areaComumVM.Descricao, areaComumVM.TermoDeUso, areaComumVM.CondominioId,
                 areaComumVM.NomeCondominio, areaComumVM.Capacidade, areaComumVM.DiasPermitidos,
                 areaComumVM.AntecedenciaMaximaEmMeses, areaComumVM.AntecedenciaMaximaEmDias,
                 areaComumVM.AntecedenciaMinimaEmDias, areaComumVM.AntecedenciaMinimaParaCancelamentoEmDias,
                 areaComumVM.RequerAprovacaoDeReserva, areaComumVM.TemHorariosEspecificos,
                 areaComumVM.TempoDeIntervaloEntreReservas, areaComumVM.Ativa, areaComumVM.TempoDeDuracaoDeReserva,
                 areaComumVM.NumeroLimiteDeReservaPorUnidade, areaComumVM.PermiteReservaSobreposta,
                 areaComumVM.NumeroLimiteDeReservaSobreposta, areaComumVM.NumeroLimiteDeReservaSobrepostaPorUnidade,
                 areaComumVM.TempoDeIntervaloEntreReservasPorUsuario, listaPeriodos);
        }

        private EditarAreaComumCommand EditarAreaComumCommandFactory(EditaAreaComumViewModel areaComumVM)
        {
            var listaPeriodos = new List<Periodo>();
            if (areaComumVM.Periodos != null)
            {
                foreach (PeriodoViewModel periodoVM in areaComumVM.Periodos)
                {
                    var periodo = _mapper.Map<Periodo>(periodoVM);                   
                    listaPeriodos.Add(periodo);
                }
            }
            return new EditarAreaComumCommand(
                  areaComumVM.Id, areaComumVM.Nome, areaComumVM.Descricao, areaComumVM.TermoDeUso, 
                  areaComumVM.Capacidade, areaComumVM.DiasPermitidos, areaComumVM.AntecedenciaMaximaEmMeses,
                  areaComumVM.AntecedenciaMaximaEmDias, areaComumVM.AntecedenciaMinimaEmDias, 
                  areaComumVM.AntecedenciaMinimaParaCancelamentoEmDias,
                  areaComumVM.RequerAprovacaoDeReserva, areaComumVM.TemHorariosEspecificos,
                  areaComumVM.TempoDeIntervaloEntreReservas, areaComumVM.TempoDeDuracaoDeReserva,
                  areaComumVM.NumeroLimiteDeReservaPorUnidade, areaComumVM.PermiteReservaSobreposta,
                  areaComumVM.NumeroLimiteDeReservaSobreposta, areaComumVM.NumeroLimiteDeReservaSobrepostaPorUnidade,
                  areaComumVM.TempoDeIntervaloEntreReservasPorUsuario, listaPeriodos);
        }
    }
}
