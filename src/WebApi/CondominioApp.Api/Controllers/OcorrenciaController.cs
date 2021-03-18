using AutoMapper;
using CondominioApp.ArquivoDigital.App.Aplication.Commands;
using CondominioApp.Core.Mediator;
using CondominioApp.Ocorrencias.App.Aplication.Commands;
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

        public OcorrenciaController(IMediatorHandler mediatorHandler, IMapper mapper, IPrincipalQuery principalQuery, IUsuarioQuery usuarioQuery)
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

            var condominio = await _principalQuery.ObterPorId(ocorrenciaVM.CondominioId);
            if(condominio == null)
            {
                AdicionarErroProcessamento("Condomínio não encontrado!");
                return CustomResponse();
            }

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

            var comando = CadastrarOcorrenciaCommandFactory(ocorrenciaVM, condominio, usuario);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            //Salva Anexos
            if (Resultado.IsValid && ocorrenciaVM.TemAnexos)
            {
                foreach (AnexoOcorrenciaViewModel item in ocorrenciaVM.Anexos)
                {

                }
            }

            return CustomResponse(Resultado);

        }

        



        private CadastrarOcorrenciaCommand CadastrarOcorrenciaCommandFactory
            (CadastraOcorrenciaViewModel ocorrenciaVM, CondominioFlat condominio, Usuario usuario)
        {           
           return new CadastrarOcorrenciaCommand
                (ocorrenciaVM.Descricao, ocorrenciaVM.Foto, ocorrenciaVM.Publica, ocorrenciaVM.UnidadeId,
                ocorrenciaVM.UsuarioId, ocorrenciaVM.CondominioId, ocorrenciaVM.Panico, ocorrenciaVM.TemAnexos);
        }

        private CadastrarArquivoCommand CadastrarArquivoCommandFactory(AnexoOcorrenciaViewModel anexo, bool publico, Guid pastaId)
        {
            return new CadastrarArquivoCommand
                (anexo.NomeOriginal, anexo.Tamanho, pastaId, publico, anexo.UsuarioId, anexo.NomeOriginal,
                anexo.Titulo, anexo.Descricao);
        }

    }
}
