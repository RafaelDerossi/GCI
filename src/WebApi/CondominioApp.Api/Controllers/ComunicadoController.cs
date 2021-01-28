using AutoMapper;
using CondominioApp.Comunicados.App.Aplication.Commands;
using CondominioApp.Comunicados.App.Aplication.Query;
using CondominioApp.Comunicados.App.Models;
using CondominioApp.Comunicados.App.ViewModels;
using CondominioApp.Core.Mediator;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("api/comunicado")]
    public class ComunicadoController : MainController
    {

        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;
        private readonly IComunicadoQuery _comunicadoQuery;        

        public ComunicadoController(IMediatorHandler mediatorHandler, IMapper mapper, IComunicadoQuery comunicadoQuery)
        {
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
            _comunicadoQuery = comunicadoQuery;           
        }


        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ComunicadoViewModel>> ObterPorId(Guid id)
        {
            var comunicado = await _comunicadoQuery.ObterPorId(id);
            if (comunicado == null)
            {
                AdicionarErroProcessamento("Comunicado não encontrado.");
                return CustomResponse();
            }

            //Obtem Anexos
            if (comunicado.TemAnexos)
            {

            }

            return _mapper.Map<ComunicadoViewModel>(comunicado);
        }

        [HttpGet("por-condominio-unidade-e-proprietario")]
        public async Task<ActionResult<IEnumerable<ComunicadoViewModel>>> ObterPorCondominioUnidadeEProprietario
            (Guid condominioId, Guid unidadeId, bool IsProprietario)
        {
            var comunicados = await _comunicadoQuery.ObterPorCondominioUnidadeEProprietario(
                condominioId, unidadeId, IsProprietario);
            if (comunicados.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var comunicadosVM = new List<ComunicadoViewModel>();
            foreach (Comunicado comunicado in comunicados)
            {                
                //Obtem Anexos
                if (comunicado.TemAnexos)
                {

                }
                var comunicadoVM = _mapper.Map<ComunicadoViewModel>(comunicado);
                comunicadosVM.Add(comunicadoVM);
            }
            return comunicadosVM;
        }


        [HttpGet("por-condominio-e-usuario")]
        public async Task<ActionResult<IEnumerable<ComunicadoViewModel>>> ObterPorCondominioEUsuario(
            Guid condominioId, Guid usuarioId)
        {
            var comunicados = await _comunicadoQuery.ObterPorCondominioEUsuario(condominioId, usuarioId);
            if (comunicados.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var comunicadosVM = new List<ComunicadoViewModel>();
            foreach (Comunicado comunicado in comunicados)
            {
                //Obtem Anexos
                if (comunicado.TemAnexos)
                {

                }
                var comunicadoVM = _mapper.Map<ComunicadoViewModel>(comunicado);
                comunicadosVM.Add(comunicadoVM);
            }

            return comunicadosVM;
        }



        [HttpPost]
        public async Task<ActionResult> Post(CadastrarComunicadoViewModel comunicadoVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = CadastrarComunicadoCommandFactory(comunicadoVM);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            //Salva Anexos
            if (Resultado.IsValid && comunicadoVM.TemAnexos)
            {

            }

            return CustomResponse(Resultado);

        }

        [HttpPut]
        public async Task<ActionResult> Put(EditarComunicadoViewModel comunicadoVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);         

           
            var comando = EditarComunicadoCommandFactory(comunicadoVM);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            //Editar Anexos
            if (Resultado.IsValid)
            {

            }

            return CustomResponse(Resultado);

        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var comando = new RemoverComunicadoCommand(id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            //Remover Anexos
            if (Resultado.IsValid)
            {

            }

            return CustomResponse(Resultado);
        }




        private CadastrarComunicadoCommand CadastrarComunicadoCommandFactory(CadastrarComunicadoViewModel comunicadoVM)
        {
            var listaUnidades = new List<Unidade>();
            if (comunicadoVM.Unidades != null)
            {
                foreach (UnidadeViewModel unidadeVM in comunicadoVM.Unidades)
                {
                    var unidade = _mapper.Map<Unidade>(unidadeVM);
                    listaUnidades.Add(unidade);
                }
            }
           
           return new CadastrarComunicadoCommand(
                comunicadoVM.Titulo, comunicadoVM.Descricao, comunicadoVM.DataDeRealizacao,
                comunicadoVM.CondominioId, comunicadoVM.NomeCondominio, comunicadoVM.UsuarioId,
                comunicadoVM.NomeUsuario, comunicadoVM.Visibilidade, comunicadoVM.Categoria,
                comunicadoVM.TemAnexos, comunicadoVM.CriadoPelaAdministradora, listaUnidades);
        }

        private EditarComunicadoCommand EditarComunicadoCommandFactory(EditarComunicadoViewModel comunicadoVM)
        {
            var listaUnidades = new List<Unidade>();
            if (comunicadoVM.Unidades != null)
            {
                foreach (UnidadeViewModel unidadeVM in comunicadoVM.Unidades)
                {
                    var unidade = _mapper.Map<Unidade>(unidadeVM);
                    listaUnidades.Add(unidade);
                }
            }

            //Edita Comunicado
          return new EditarComunicadoCommand(
                comunicadoVM.ComunicadoId, comunicadoVM.Titulo, comunicadoVM.Descricao, comunicadoVM.DataDeRealizacao,
                comunicadoVM.UsuarioId, comunicadoVM.NomeUsuario, comunicadoVM.Visibilidade, comunicadoVM.Categoria,
                comunicadoVM.TemAnexos, listaUnidades);

        }
    }
}
