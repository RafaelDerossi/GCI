using AutoMapper;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Mediator;
using CondominioApp.Ocorrencias.App.Aplication.Commands;
using CondominioApp.Ocorrencias.App.Aplication.Query;
using CondominioApp.Ocorrencias.App.Models;
using CondominioApp.Ocorrencias.App.ViewModels;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.Usuarios.App.Aplication.Query;
using CondominioApp.Usuarios.App.Models;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("api/ocorrencia")]
    public class OcorrenciaController : MainController
    {

        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;        
        private readonly IPrincipalQuery _principalQuery;
        private readonly IUsuarioQuery _usuarioQuery;
        private readonly IOcorrenciaQuery _ocorrenciaQuery;

        public OcorrenciaController(IMediatorHandler mediatorHandler, IMapper mapper, 
            IPrincipalQuery principalQuery, IUsuarioQuery usuarioQuery, IOcorrenciaQuery ocorrenciaQuery)
        {
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;            
            _principalQuery = principalQuery;
            _usuarioQuery = usuarioQuery;
            _ocorrenciaQuery = ocorrenciaQuery;
        }



        [HttpGet("por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterPorCondominio(Guid condominioId)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorCondominio(condominioId);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = new List<OcorrenciaViewModel>();
            foreach (Ocorrencia comunicado in ocorrencias)
                ocorrenciasVM.Add(_mapper.Map<OcorrenciaViewModel>(comunicado));
            
            return ocorrenciasVM;
        }


        [HttpGet("por-condominio-e-usuario")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterPorCondominioEUsuario
            (Guid condominioId, Guid usuarioId)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorCondominioEUsuario(condominioId, usuarioId);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = new List<OcorrenciaViewModel>();
            foreach (Ocorrencia comunicado in ocorrencias)
                ocorrenciasVM.Add(_mapper.Map<OcorrenciaViewModel>(comunicado));

            return ocorrenciasVM;
        }


        [HttpGet("pendentes-por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterPendentesPorCondominio(Guid condominioId)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorCondominioEStatus(condominioId, StatusDaOcorrencia.PENDENTE);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = new List<OcorrenciaViewModel>();
            foreach (Ocorrencia comunicado in ocorrencias)
                ocorrenciasVM.Add(_mapper.Map<OcorrenciaViewModel>(comunicado));

            return ocorrenciasVM;
        }


        [HttpGet("em-andamento-por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterEmAndamentoPorCondominio(Guid condominioId)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorCondominioEStatus(condominioId, StatusDaOcorrencia.EM_ANDAMENTO);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = new List<OcorrenciaViewModel>();
            foreach (Ocorrencia comunicado in ocorrencias)
                ocorrenciasVM.Add(_mapper.Map<OcorrenciaViewModel>(comunicado));

            return ocorrenciasVM;
        }


        [HttpGet("resolvidas-por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterResolvidasPorCondominio(Guid condominioId)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorCondominioEStatus(condominioId, StatusDaOcorrencia.RESOLVIDA);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = new List<OcorrenciaViewModel>();
            foreach (Ocorrencia comunicado in ocorrencias)
                ocorrenciasVM.Add(_mapper.Map<OcorrenciaViewModel>(comunicado));

            return ocorrenciasVM;
        }


        [HttpGet("por-condominio-e-filtro")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterPorCondominioEFiltro(Guid condominioId, string filtro)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorCondominioEFiltro(condominioId, filtro);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = new List<OcorrenciaViewModel>();
            foreach (Ocorrencia comunicado in ocorrencias)
                ocorrenciasVM.Add(_mapper.Map<OcorrenciaViewModel>(comunicado));

            return ocorrenciasVM;
        }


        [HttpGet("pendentes-por-condominio-e-filtro")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterPendentesPorCondominioEFiltro(Guid condominioId, string filtro)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorCondominioEStatusEFiltro(condominioId, StatusDaOcorrencia.PENDENTE, filtro);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = new List<OcorrenciaViewModel>();
            foreach (Ocorrencia comunicado in ocorrencias)
                ocorrenciasVM.Add(_mapper.Map<OcorrenciaViewModel>(comunicado));

            return ocorrenciasVM;
        }


        [HttpGet("em-andamento-por-condominio-e-filtro")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterEmAndamentoPorCondominioEFiltro(Guid condominioId, string filtro)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorCondominioEStatusEFiltro(condominioId, StatusDaOcorrencia.EM_ANDAMENTO, filtro);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = new List<OcorrenciaViewModel>();
            foreach (Ocorrencia comunicado in ocorrencias)
                ocorrenciasVM.Add(_mapper.Map<OcorrenciaViewModel>(comunicado));

            return ocorrenciasVM;
        }


        [HttpGet("resolvidas-por-condominio-e-filtro")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterResolvidasPorCondominioEFiltro(Guid condominioId, string filtro)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorCondominioEStatusEFiltro(condominioId, StatusDaOcorrencia.RESOLVIDA, filtro);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = new List<OcorrenciaViewModel>();
            foreach (Ocorrencia comunicado in ocorrencias)
                ocorrenciasVM.Add(_mapper.Map<OcorrenciaViewModel>(comunicado));

            return ocorrenciasVM;
        }


        [HttpGet("respostas-por-ocorrencia/{ocorrenciaId:Guid}")]
        public async Task<ActionResult<IEnumerable<RespostaOcorrenciaViewModel>>> ObterRespostasPorOcorrencia(Guid ocorrenciaId)
        {
            var respostas = await _ocorrenciaQuery.ObterRespostasPorOcorrencia(ocorrenciaId);
            
            var respostasVM = new List<RespostaOcorrenciaViewModel>();
            foreach (RespostaOcorrencia resposta in respostas)
                respostasVM.Add(_mapper.Map<RespostaOcorrenciaViewModel>(resposta));

            return respostasVM;
        }



        [HttpPost]
        public async Task<ActionResult> Post(CadastraOcorrenciaViewModel ocorrenciaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);           

            var unidade = await _principalQuery.ObterUnidadePorId(ocorrenciaVM.UnidadeId);
            if (unidade == null)
            {
                AdicionarErroProcessamento("Unidade não encontrada!");
                return CustomResponse();
            }

            var usuario = await _usuarioQuery.ObterPorId(ocorrenciaVM.UsuarioId);
            if (usuario == null)
            {
                AdicionarErroProcessamento("Usuario não encontrado!");
                return CustomResponse();
            }

            var comando = CadastrarOcorrenciaCommandFactory(ocorrenciaVM, usuario, unidade);

            var Resultado = await _mediatorHandler.EnviarComando(comando);            

            return CustomResponse(Resultado);

        }

        [HttpPut]
        public async Task<ActionResult> Put(EditaOcorrenciaViewModel ocorrenciaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);           

            var comando = EditarOcorrenciaCommandFactory(ocorrenciaVM);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        [HttpPut("resposta-sindico")]
        public async Task<ActionResult> PutRespostaSindico(CadastraRespostaOcorrenciaSindicoViewModel respostaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var usuario = await _usuarioQuery.ObterPorId(respostaVM.UsuarioId);
            if (usuario == null)
            {
                AdicionarErroProcessamento("Usuario não encontrado!");
                return CustomResponse();
            }

            var comando = CadastrarRespostaOcorrenciaSindicoCommandFactory(respostaVM, usuario);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        [HttpPut("resposta-morador")]
        public async Task<ActionResult> PutRespostaMorador(CadastraRespostaOcorrenciaMoradorViewModel respostaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var usuario = await _usuarioQuery.ObterPorId(respostaVM.UsuarioId);
            if (usuario == null)
            {
                AdicionarErroProcessamento("Usuario não encontrado!");
                return CustomResponse();
            }

            var comando = CadastrarRespostaOcorrenciaMoradorCommandFactory(respostaVM, usuario);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        [HttpPut("marcar-resposta-vista/{respostaId:Guid}")]
        public async Task<ActionResult> PutMarcarRespostaVista(Guid respostaId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            
            var comando = new MarcarRespostaOcorrenciaComoVistaCommand(respostaId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }


        [HttpDelete("remover/{ocorrenciaId:Guid}")]
        public async Task<ActionResult> RemoverOcorrencia(Guid ocorrenciaId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new RemoverOcorrenciaCommand(ocorrenciaId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }




        private CadastrarOcorrenciaCommand CadastrarOcorrenciaCommandFactory
            (CadastraOcorrenciaViewModel ocorrenciaVM, Usuario usuario, UnidadeFlat unidade)
        {           
           return new CadastrarOcorrenciaCommand
                (ocorrenciaVM.Descricao, ocorrenciaVM.NomeOriginalFoto, ocorrenciaVM.NomeFoto,
                 ocorrenciaVM.Publica, ocorrenciaVM.UnidadeId, unidade.Numero, unidade.Andar, unidade.GrupoDescricao,
                 ocorrenciaVM.UsuarioId, usuario.NomeCompleto, unidade.CondominioId, unidade.CondominioNome,
                 ocorrenciaVM.Panico);
        }

        private EditarOcorrenciaCommand EditarOcorrenciaCommandFactory
           (EditaOcorrenciaViewModel ocorrenciaVM)
        {
            return new EditarOcorrenciaCommand
                 (ocorrenciaVM.Id, ocorrenciaVM.Descricao, ocorrenciaVM.FotoNomeOriginal, 
                 ocorrenciaVM.FotoNome, ocorrenciaVM.Publica);
        }

        private CadastrarRespostaOcorrenciaSindicoCommand CadastrarRespostaOcorrenciaSindicoCommandFactory
          (CadastraRespostaOcorrenciaSindicoViewModel respostaVM, Usuario usuario)
        {
            return new CadastrarRespostaOcorrenciaSindicoCommand
                 (respostaVM.OcorrenciaId, respostaVM.Descricao, respostaVM.UsuarioId, usuario.NomeCompleto,
                 respostaVM.FotoNome, respostaVM.FotoNomeOriginal, respostaVM.Status);
        }

        private CadastrarRespostaOcorrenciaMoradorCommand CadastrarRespostaOcorrenciaMoradorCommandFactory
            (CadastraRespostaOcorrenciaMoradorViewModel respostaVM, Usuario usuario)
        {
            return new CadastrarRespostaOcorrenciaMoradorCommand
                 (respostaVM.OcorrenciaId, respostaVM.Descricao, respostaVM.UsuarioId, usuario.NomeCompleto,
                 respostaVM.FotoNome, respostaVM.FotoNomeOriginal);
        }
      

    }
}
