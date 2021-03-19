using AutoMapper;
using CondominioApp.Core.Mediator;
using CondominioApp.Ocorrencias.App.Aplication.Commands;
using CondominioApp.Ocorrencias.App.ViewModels;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.Usuarios.App.Aplication.Query;
using CondominioApp.Usuarios.App.Models;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
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

        public OcorrenciaController(IMediatorHandler mediatorHandler, IMapper mapper, 
            IPrincipalQuery principalQuery, IUsuarioQuery usuarioQuery)
        {
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;            
            _principalQuery = principalQuery;
            _usuarioQuery = usuarioQuery;            
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
                

        private CadastrarOcorrenciaCommand CadastrarOcorrenciaCommandFactory
            (CadastraOcorrenciaViewModel ocorrenciaVM, Usuario usuario, UnidadeFlat unidade)
        {           
           return new CadastrarOcorrenciaCommand
                (ocorrenciaVM.Descricao, ocorrenciaVM.NomeOriginalFoto, ocorrenciaVM.NomeFoto,
                 ocorrenciaVM.Publica, ocorrenciaVM.UnidadeId, unidade.Numero, unidade.Andar, unidade.GrupoDescricao,
                 ocorrenciaVM.UsuarioId, usuario.NomeCompleto, unidade.CondominioId, unidade.CondominioNome,
                 ocorrenciaVM.Panico);
        }
            
       

    }
}
