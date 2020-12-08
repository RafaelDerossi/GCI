using CondominioApp.Comunicados.App.Aplication.Commands;
using CondominioApp.Comunicados.App.ViewModels;
using CondominioApp.Core.Mediator;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("api/comunicado")]
    public class ComunicadoController : MainController
    {

        private readonly IMediatorHandler _mediatorHandler;
        //private readonly IMapper _mapper;
        //private readonly IComunicadoQuery _comunicadoQuery;        

        public ComunicadoController(IMediatorHandler mediatorHandler) //, IMapper mapper, ICorrespondenciaQuery correspondenciaQuery)
        {
            _mediatorHandler = mediatorHandler;
            //_mapper = mapper;
            //_comunicadoQuery = correspondenciaQuery;            
        }


        //[HttpGet("{id:Guid}")]
        //public async Task<CorrespondenciaViewModel> ObterPorId(Guid id)
        //{
        //    return _mapper.Map<CorrespondenciaViewModel>(await _comunicadoQuery.ObterPorId(id));
        //}

        //[HttpGet("por-unidade-e-periodo")]
        //public async Task<IEnumerable<CorrespondenciaViewModel>> ObterPorUnidadeEPeriodo(
        //    Guid unidadeId, DateTime dataInicio, DateTime dataFim)
        //{
        //    var correspondencias = await _comunicadoQuery.ObterPorUnidadeEPeriodo(
        //        unidadeId, dataInicio, dataFim);

        //    var correspondenciasVM = new List<CorrespondenciaViewModel>();
        //    foreach (Correspondencia item in correspondencias)
        //    {
        //        var enqueteVM = _mapper.Map<CorrespondenciaViewModel>(item);
        //        correspondenciasVM.Add(enqueteVM);
        //    }
        //    return correspondenciasVM;
        //}

        //[HttpGet("por-condominio-periodo-e-status")]
        //public async Task<IEnumerable<CorrespondenciaViewModel>> ObterEnquetesAtivasPorCondominio(
        //    Guid condominioId, DateTime dataInicio, DateTime dataFim, StatusCorrespondencia status)
        //{
        //    var correspondencias = await _comunicadoQuery.ObterPorCondominioPeriodoEStatus(
        //        condominioId, dataInicio, dataFim, status);

        //    var correspondenciasVM = new List<CorrespondenciaViewModel>();
        //    foreach (Correspondencia item in correspondencias)
        //    {
        //        var enqueteVM = _mapper.Map<CorrespondenciaViewModel>(item);
        //        correspondenciasVM.Add(enqueteVM);
        //    }
        //    return correspondenciasVM;
        //}



        [HttpPost]
        public async Task<ActionResult> Post(CadastrarComunicadoViewModel comunicadoVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            bool temAnexos = false;
            if (comunicadoVM.Anexos != null)
            {
                temAnexos = comunicadoVM.Anexos.Count() > 0;             
            }

            //Salva Comunicado
            var comando = new CadastrarComunicadoCommand(
                comunicadoVM.Titulo, comunicadoVM.Descricao, comunicadoVM.DataDeRealizacao,
                comunicadoVM.CondominioId, comunicadoVM.NomeCondominio, comunicadoVM.UsuarioId,
                comunicadoVM.NomeUsuario, comunicadoVM.Visibilidade, comunicadoVM.Categoria,
                temAnexos, comunicadoVM.CriadoPelaAdministradora,
                comunicadoVM.Unidades);           

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            //Salva Anexos
            if (Resultado.IsValid && temAnexos)
            {

            }

            return CustomResponse(Resultado);

        }

        //[HttpDelete("{id:Guid}")]
        //public async Task<ActionResult> Delete(Guid id)
        //{
        //    var comando = new RemoverCorrespondenciaCommand(id);

        //    var Resultado = await _mediatorHandler.EnviarComando(comando);

        //    return CustomResponse(Resultado);
        //}
    }
}
