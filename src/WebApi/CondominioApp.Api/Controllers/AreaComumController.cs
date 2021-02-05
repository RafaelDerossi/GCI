using AutoMapper;
using CondominioApp.Core.Mediator;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.ReservaAreaComum.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Aplication.ViewModels;
using CondominioApp.ReservaAreaComum.App.Aplication.Query;
using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Domain.FlatModel;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("api/areacomum")]
    public class AreaComumController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;
        private readonly IReservaAreaComumQuery _areaComumQuery;
        private readonly ICondominioQuery _condominioQuery;

        public AreaComumController(IMediatorHandler mediatorHandler, IMapper mapper,
                                   IReservaAreaComumQuery areaComumQuery, ICondominioQuery condominioQuery)
        {
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
            _areaComumQuery = areaComumQuery;
            _condominioQuery = condominioQuery;
        }


        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<AreaComumFlat>> ObterPorId(Guid id)
        {
            var areaComum = await _areaComumQuery.ObterPorId(id);
            if (areaComum == null)
            {
                AdicionarErroProcessamento("Área Comum não encontrada.");
                return CustomResponse();
            }
            return areaComum;
        }

        [HttpGet("por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<AreaComumFlat>>> ObterPorCondominio(Guid condominioId)
        {
            var areasComuns = await _areaComumQuery.ObterPorCondominio(condominioId);
            if (areasComuns.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }
            return areasComuns.ToList();
        }



        [HttpPost]
        public async Task<ActionResult> Post(CadastraAreaComumViewModel areaComumVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var condominio = await _condominioQuery.ObterPorId(areaComumVM.CondominioId);
            if (condominio == null)
            {
                AdicionarErroProcessamento("Condominio não encontrado!");
                return CustomResponse();
            }

            var comando = CadastrarAreaComumCommandFactory(areaComumVM, condominio);

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




        private CadastrarAreaComumCommand CadastrarAreaComumCommandFactory(CadastraAreaComumViewModel areaComumVM, CondominioFlat condominio)
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
                 areaComumVM.Nome, areaComumVM.Descricao, areaComumVM.TermoDeUso, condominio.Id,
                 condominio.Nome, areaComumVM.Capacidade, areaComumVM.DiasPermitidos,
                 areaComumVM.AntecedenciaMaximaEmMeses, areaComumVM.AntecedenciaMaximaEmDias,
                 areaComumVM.AntecedenciaMinimaEmDias, areaComumVM.AntecedenciaMinimaParaCancelamentoEmDias,
                 areaComumVM.RequerAprovacaoDeReserva, areaComumVM.TemHorariosEspecificos,
                 areaComumVM.TempoDeIntervaloEntreReservas, areaComumVM.Ativa, areaComumVM.TempoDeDuracaoDeReserva,
                 areaComumVM.NumeroLimiteDeReservaPorUnidade, areaComumVM.PermiteReservaSobreposta,
                 areaComumVM.NumeroLimiteDeReservaSobreposta, areaComumVM.NumeroLimiteDeReservaSobrepostaPorUnidade,
                 areaComumVM.TempoDeIntervaloEntreReservasPorUnidade, listaPeriodos);
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
                  areaComumVM.TempoDeIntervaloEntreReservasPorUnidade, listaPeriodos);
        }
    }
}
