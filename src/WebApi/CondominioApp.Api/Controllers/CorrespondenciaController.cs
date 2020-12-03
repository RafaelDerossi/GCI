using CondominioApp.Core.Mediator;
using CondominioApp.Correspondencias.App.Aplication.Commands;
using CondominioApp.Correspondencias.App.ViewModels;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("api/correspondencia")]
    public class CorrespondenciaController : MainController
    {

        private readonly IMediatorHandler _mediatorHandler;

        public CorrespondenciaController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }


        //[HttpGet("{id:Guid}")]
        //public async Task<EnqueteViewModel> ObterPorId(Guid id)
        //{
        //    return _mapper.Map<EnqueteViewModel>(await _enqueteQuery.ObterPorId(id));
        //}

        //[HttpGet("por-condominio/{condominioId:Guid}")]
        //public async Task<IEnumerable<EnqueteViewModel>> ObterEnquetesPorCondominio(Guid condominioId)
        //{
        //    var enquetes = await _enqueteQuery.ObterPorCondominio(condominioId);

        //    var enquetesVM = new List<EnqueteViewModel>();
        //    foreach (Enquete item in enquetes)
        //    {
        //        var enqueteVM = _mapper.Map<EnqueteViewModel>(item);
        //        enquetesVM.Add(enqueteVM);
        //    }
        //    return enquetesVM;
        //}

        //[HttpGet("ativas-por-condominio/{condominioId:Guid}")]
        //public async Task<IEnumerable<EnqueteViewModel>> ObterEnquetesAtivasPorCondominio(Guid condominioId)
        //{
        //    var enquetes = await _enqueteQuery.ObterAtivasPorCondominio(condominioId);

        //    var enquetesVM = new List<EnqueteViewModel>();
        //    foreach (Enquete item in enquetes)
        //    {
        //        var enqueteVM = _mapper.Map<EnqueteViewModel>(item);
        //        enquetesVM.Add(enqueteVM);
        //    }
        //    return enquetesVM;
        //}



        [HttpPost]
        public async Task<ActionResult> Post(CadastraCorrespondenciaViewModel correspondenciaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new CadastrarCorrespondenciaCommand(
                 correspondenciaVM.CondominioId, correspondenciaVM.UnidadeId, correspondenciaVM.NumeroUnidade, correspondenciaVM.Bloco,
                 correspondenciaVM.Observacao, correspondenciaVM.UsuarioId, correspondenciaVM.NomeUsuario,
                 correspondenciaVM.Foto, correspondenciaVM.NomeOriginal, correspondenciaVM.NumeroRastreamentoCorreio,
                 correspondenciaVM.DataDeChegada, correspondenciaVM.TipoDeCorrespondencia, correspondenciaVM.Status);           

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }


        [HttpPut("marcar-correspondencia-vista/{correspondenciaId:Guid}")]
        public async Task<ActionResult> PutVista(Guid correspondenciaId)
        {           
            var comando = new MarcarCorrespondenciaVistaCommand(correspondenciaId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("marcar-correspondencia-retirada")]
        public async Task<ActionResult> PutRetirada(MarcaCorrespondenciaRetiradaViewModel viewModel)
        {
            var comando = new MarcarCorrespondenciaRetiradaCommand(
                viewModel.Id,viewModel.NomeRetirante, viewModel.Observacao,
                viewModel.UsuarioId, viewModel.NomeUsuario);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("marcar-correspondencia-devolvida")]
        public async Task<ActionResult> PutDevolvida(MarcaCorrespondenciaDevolvidaViewModel viewModel)
        {
            var comando = new MarcarCorrespondenciaDevolvidaCommand(
                viewModel.Id, viewModel.Observacao,
                viewModel.UsuarioId, viewModel.NomeUsuario);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("disparar-alerta/{correspondenciaId:Guid}")]
        public async Task<ActionResult> PutDispararAlerta(Guid correspondenciaId)
        {
            var comando = new DispararAlertaDeCorrespondenciaCommand(correspondenciaId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var comando = new RemoverCorrespondenciaCommand(id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }


    }
}
