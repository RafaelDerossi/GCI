using AutoMapper;
using CondominioApp.Core.Mediator;
using CondominioApp.ReservaAreaComum.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Aplication.ViewModels;
using CondominioApp.ReservaAreaComum.Domain;
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
        //private readonly ICondominioQuery _condominioQuery;

        public AreaComumController(IMediatorHandler mediatorHandler, IMapper mapper) //, ICondominioQuery condominioQuery)
        {
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
            //_condominioQuery = condominioQuery;
        }


        //[HttpGet("{id:Guid}")]
        //public async Task<GrupoFlat> ObterGrupoPorId(Guid id)
        //{
        //    return await _condominioQuery.ObterGrupoPorId(id);
        //}

        //[HttpGet("por-condominio/{condominioId:Guid}")]
        //public async Task<IEnumerable<GrupoFlat>> ObterGruposPorCondominio(Guid condominioId)
        //{
        //    return await _condominioQuery.ObterGruposPorCondominio(condominioId);
        //}



        [HttpPost]
        public async Task<ActionResult> Post(CadastraAreaComumViewModels areaComumVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = CadastrarAreaComumCommandFactory(areaComumVM);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        //[HttpPut]
        //public async Task<ActionResult> Put(EditaGrupoViewModel grupoVM)
        //{
        //    if (!ModelState.IsValid) return CustomResponse(ModelState);

        //    var comando = new EditarGrupoCommand(
        //        grupoVM.Id, grupoVM.Descricao);


        //    var Resultado = await _mediatorHandler.EnviarComando(comando);

        //    return CustomResponse(Resultado);

        //}

        //[HttpDelete("{Id:Guid}")]
        //public async Task<ActionResult> DeleteGrupo(Guid Id)
        //{
        //    var comando = new RemoverGrupoCommand(Id);

        //    var Resultado = await _mediatorHandler.EnviarComando(comando);

        //    return CustomResponse(Resultado);
        //}

       private CadastrarAreaComumCommand CadastrarAreaComumCommandFactory(CadastraAreaComumViewModels areaComumVM)
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
                 listaPeriodos);
        }
    }
}
