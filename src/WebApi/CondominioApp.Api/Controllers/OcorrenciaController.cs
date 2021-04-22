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


        [HttpGet("por-morador-ou-publicas/{moradorId:Guid}")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterPorMoradorOuPublicas(Guid moradorId)
        {
            var morador = await _usuarioQuery.ObterMoradorPorId(moradorId);
            if (morador == null)
            {
                AdicionarErroProcessamento("Morador não encontrado!");
                return CustomResponse();
            }

            var ocorrencias = await _ocorrenciaQuery.ObterPorMoradorOuPublicas(morador.CondominioId, moradorId);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = MapperListEntityToViewModel(ocorrencias);

            return ocorrenciasVM;
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

            var ocorrenciasVM = MapperListEntityToViewModel(ocorrencias);

            return ocorrenciasVM;
        }


        [HttpGet("pendentes-por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterPendentesPorCondominio(Guid unidadeId)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorCondominioEStatus(unidadeId, StatusDaOcorrencia.PENDENTE);
            if (ocorrencias.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var ocorrenciasVM = MapperListEntityToViewModel(ocorrencias);

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

            var ocorrenciasVM = MapperListEntityToViewModel(ocorrencias);

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

            var ocorrenciasVM = MapperListEntityToViewModel(ocorrencias);

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

            var ocorrenciasVM = MapperListEntityToViewModel(ocorrencias);

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

            var ocorrenciasVM = MapperListEntityToViewModel(ocorrencias);

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

            var ocorrenciasVM = MapperListEntityToViewModel(ocorrencias);

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

            var ocorrenciasVM = MapperListEntityToViewModel(ocorrencias);

            return ocorrenciasVM;
        }







        [HttpGet("por-unidade/{unidadeId:Guid}")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterPorUnidade(Guid unidadeId)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorUnidade(unidadeId);
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


        [HttpGet("pendentes-por-unidade/{unidadeId:Guid}")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterPendentesPorUnidade(Guid unidadeId)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorUnidadeEStatus(unidadeId, StatusDaOcorrencia.PENDENTE);
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


        [HttpGet("em-andamento-por-unidade/{unidadeId:Guid}")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterEmAndamentoPorUnidade(Guid unidadeId)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorUnidadeEStatus(unidadeId, StatusDaOcorrencia.EM_ANDAMENTO);
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


        [HttpGet("resolvidas-por-unidade/{unidadeId:Guid}")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterResolvidasPorUnidade(Guid unidadeId)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorUnidadeEStatus(unidadeId, StatusDaOcorrencia.RESOLVIDA);
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


        [HttpGet("por-unidade-e-filtro")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterPorUnidadeEFiltro(Guid unidadeId, string filtro)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorUnidadeEFiltro(unidadeId, filtro);
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


        [HttpGet("pendentes-por-unidade-e-filtro")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterPendentesPorUnidadeEFiltro(Guid unidadeId, string filtro)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorUnidadeEStatusEFiltro(unidadeId, StatusDaOcorrencia.PENDENTE, filtro);
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


        [HttpGet("em-andamento-por-unidade-e-filtro")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterEmAndamentoPorUnidadeEFiltro(Guid unidadeId, string filtro)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorUnidadeEStatusEFiltro(unidadeId, StatusDaOcorrencia.EM_ANDAMENTO, filtro);
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


        [HttpGet("resolvidas-por-unidade-e-filtro")]
        public async Task<ActionResult<IEnumerable<OcorrenciaViewModel>>> ObterResolvidasPorUnidadeEFiltro(Guid unidadeId, string filtro)
        {
            var ocorrencias = await _ocorrenciaQuery.ObterPorUnidadeEStatusEFiltro(unidadeId, StatusDaOcorrencia.RESOLVIDA, filtro);
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

            var morador = await _usuarioQuery.ObterMoradorPorId(ocorrenciaVM.MoradorId);
            if (morador == null)
            {
                AdicionarErroProcessamento("Morador não encontrado!");
                return CustomResponse();
            }

            var comando = CadastrarOcorrenciaCommandFactory(ocorrenciaVM, morador, unidade);

            var Resultado = await _mediatorHandler.EnviarComando(comando);            

            return CustomResponse(Resultado);

        }    

        [HttpPost("resposta-sindico")]
        public async Task<ActionResult> PostRespostaSindico(CadastraRespostaOcorrenciaSindicoViewModel respostaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var funcionario = await _usuarioQuery.ObterFuncionarioPorId(respostaVM.FuncionarioId);
            if (funcionario == null)
            {
                AdicionarErroProcessamento("Funcionário não encontrado!");
                return CustomResponse();
            }

            var comando = CadastrarRespostaOcorrenciaSindicoCommandFactory(respostaVM, funcionario);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        [HttpPost("resposta-morador")]
        public async Task<ActionResult> PostRespostaMorador(CadastraRespostaOcorrenciaMoradorViewModel respostaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var morador = await _usuarioQuery.ObterMoradorPorId(respostaVM.MoradorId);
            if (morador == null)
            {
                AdicionarErroProcessamento("Morador não encontrado!");
                return CustomResponse();
            }

            var comando = CadastrarRespostaOcorrenciaMoradorCommandFactory(respostaVM, morador);

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

        [HttpPut("marcar-resposta-vista/{respostaId:Guid}")]
        public async Task<ActionResult> PutMarcarRespostaVista(Guid respostaId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            
            var comando = new MarcarRespostaOcorrenciaComoVistaCommand(respostaId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        [HttpPut("resposta")]
        public async Task<ActionResult> PutResposta(EditarRespostaOcorrenciaViewModel respostaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new EditarRespostaOcorrenciaCommand
                (respostaVM.Id, respostaVM.MoradorIdFuncionarioId, respostaVM.Descricao, 
                respostaVM.NomeFoto, respostaVM.NomeOriginalFoto);

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

        [HttpDelete("remover/{respostaId:Guid}")]
        public async Task<ActionResult> RemoverRespostaDeOcorrencia(Guid respostaId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new RemoverRespostaOcorrenciaCommand(respostaId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }



        private List<OcorrenciaViewModel> MapperListEntityToViewModel(IEnumerable<Ocorrencia> ocorrencias)
        {
            var ocorrenciasVM = new List<OcorrenciaViewModel>();
            foreach (Ocorrencia ocorrencia in ocorrencias)
            {
                var ocorrenciaVM = _mapper.Map<OcorrenciaViewModel>(ocorrencia);

                var morador = _usuarioQuery.ObterMoradorPorId(ocorrencia.MoradorId).Result;
                ocorrenciaVM.NomeMorador = morador.Nome;
                ocorrenciaVM.FotoMorador = morador.Foto;

                ocorrenciasVM.Add(ocorrenciaVM);
            }
            return ocorrenciasVM;
        }

        private CadastrarOcorrenciaCommand CadastrarOcorrenciaCommandFactory
            (CadastraOcorrenciaViewModel ocorrenciaVM, MoradorFlat morador, UnidadeFlat unidade)
        {           
           return new CadastrarOcorrenciaCommand
                (ocorrenciaVM.Descricao, ocorrenciaVM.NomeOriginalFoto, ocorrenciaVM.NomeFoto,
                 ocorrenciaVM.Publica, ocorrenciaVM.UnidadeId, unidade.Numero, unidade.Andar, unidade.GrupoDescricao,
                 ocorrenciaVM.MoradorId, morador.Nome, unidade.CondominioId, unidade.CondominioNome,
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
          (CadastraRespostaOcorrenciaSindicoViewModel respostaVM, FuncionarioFlat funcionario)
        {
            return new CadastrarRespostaOcorrenciaSindicoCommand
                 (respostaVM.OcorrenciaId, respostaVM.Descricao, respostaVM.FuncionarioId, funcionario.Nome,
                 respostaVM.FotoNome, respostaVM.FotoNomeOriginal, respostaVM.StatusDaOcorrencia);
        }

        private CadastrarRespostaOcorrenciaMoradorCommand CadastrarRespostaOcorrenciaMoradorCommandFactory
            (CadastraRespostaOcorrenciaMoradorViewModel respostaVM, MoradorFlat morador)
        {
            return new CadastrarRespostaOcorrenciaMoradorCommand
                 (respostaVM.OcorrenciaId, respostaVM.Descricao, respostaVM.MoradorId, morador.Nome,
                 respostaVM.FotoNome, respostaVM.FotoNomeOriginal);
        }
      

    }
}
