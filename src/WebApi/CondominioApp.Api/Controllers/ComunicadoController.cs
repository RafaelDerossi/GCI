﻿using AutoMapper;
using CondominioApp.ArquivoDigital.App.Aplication.Commands;
using CondominioApp.ArquivoDigital.App.Aplication.Query;
using CondominioApp.ArquivoDigital.App.Models;
using CondominioApp.Comunicados.App.Aplication.Commands;
using CondominioApp.Comunicados.App.Aplication.Query;
using CondominioApp.Comunicados.App.Models;
using CondominioApp.Comunicados.App.ViewModels;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Mediator;
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
    [Route("api/comunicado")]
    public class ComunicadoController : MainController
    {

        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;
        private readonly IComunicadoQuery _comunicadoQuery;
        private readonly IPrincipalQuery _principalQuery;
        private readonly IUsuarioQuery _usuarioQuery;
        private readonly IArquivoDigitalQuery _arquivoDigitalQuery;

        public ComunicadoController
            (IMediatorHandler mediatorHandler, IMapper mapper, IComunicadoQuery comunicadoQuery,
            IPrincipalQuery principalQuery, IUsuarioQuery usuarioQuery, IArquivoDigitalQuery arquivoDigitalQuery)
        {
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
            _comunicadoQuery = comunicadoQuery;
            _principalQuery = principalQuery;
            _usuarioQuery = usuarioQuery;
            _arquivoDigitalQuery = arquivoDigitalQuery;
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

            var comunicadoVM = _mapper.Map<ComunicadoViewModel>(comunicado);

            //Obtem Anexos
            if (comunicado.TemAnexos)
            {
                var anexos = await ObterAnexos(comunicado);
                comunicadoVM.Anexos = anexos;
            }

            return comunicadoVM;
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
                var comunicadoVM = _mapper.Map<ComunicadoViewModel>(comunicado);

                //Obtem Anexos
                if (comunicado.TemAnexos)
                {
                    var anexos = await ObterAnexos(comunicado);
                    comunicadoVM.Anexos = anexos;
                }
                
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
                var comunicadoVM = _mapper.Map<ComunicadoViewModel>(comunicado);

                //Obtem Anexos
                if (comunicado.TemAnexos)
                {
                    var anexos = await ObterAnexos(comunicado);
                    comunicadoVM.Anexos = anexos;
                }
               
                comunicadosVM.Add(comunicadoVM);
            }

            return comunicadosVM;
        }

        [HttpGet("por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<ComunicadoViewModel>>> ObterPorCondominio(Guid condominioId)
        {
            var comunicados = await _comunicadoQuery.ObterPorCondominio(condominioId);
            if (comunicados.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var comunicadosVM = new List<ComunicadoViewModel>();
            foreach (Comunicado comunicado in comunicados)
            {
                var comunicadoVM = _mapper.Map<ComunicadoViewModel>(comunicado);
                //Obtem Anexos
                if (comunicado.TemAnexos)
                {
                   var anexos = await ObterAnexos(comunicado);
                   comunicadoVM.Anexos = anexos;
                }                
                
                comunicadosVM.Add(comunicadoVM);
            }

            return comunicadosVM;
        }



        [HttpPost]
        public async Task<ActionResult> Post(CadastraComunicadoViewModel comunicadoVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var condominio = await _principalQuery.ObterPorId(comunicadoVM.CondominioId);
            if(condominio == null)
            {
                AdicionarErroProcessamento("Condominio não encontrado!");
                return CustomResponse();
            }

            var usuario = await _usuarioQuery.ObterPorId(comunicadoVM.UsuarioId);
            if (usuario == null)
            {
                AdicionarErroProcessamento("Usuario não encontrado!");
                return CustomResponse();
            }

            var comando = CadastrarComunicadoCommandFactory(comunicadoVM, condominio, usuario);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            //Salva Anexos
            if (Resultado.IsValid && comunicadoVM.TemAnexos)
            {
                await SalvarAnexos(comunicadoVM.Anexos.ToList(), comando, comando.ComunicadoId);
                if (!OperacaoValida())
                {
                    var comandoExcluirOcorrencia = new RemoverComunicadoCommand(comando.ComunicadoId);
                    await _mediatorHandler.EnviarComando(comandoExcluirOcorrencia);
                    return CustomResponse();
                }
            }

            return CustomResponse(Resultado);

        }

        [HttpPut]
        public async Task<ActionResult> Put(EditaComunicadoViewModel comunicadoVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
                        

            var usuario = await _usuarioQuery.ObterPorId(comunicadoVM.UsuarioId);
            if (usuario == null)
            {
                AdicionarErroProcessamento("Usuario não encontrado!");
                return CustomResponse();
            }

            var comunicado = await _comunicadoQuery.ObterPorId(comunicadoVM.ComunicadoId);
            if (comunicado == null)
            {
                AdicionarErroProcessamento("Comunicado não encontrado!");
                return CustomResponse();
            }

            var comando = EditarComunicadoCommandFactory(comunicadoVM, usuario);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            //Salva Anexos
            if (Resultado.IsValid && comunicadoVM.TemAnexos)
            {
                await SalvarAnexos(comunicadoVM.Anexos.ToList(), comando, comunicado.CondominioId);
                if (!OperacaoValida())
                {                 
                    return CustomResponse();
                }
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
               await ExcluirAnexos(comando);
            }

            return CustomResponse(Resultado);
        }


        [HttpDelete("anexo/{arquivoId:Guid}")]
        public async Task<ActionResult> DeleteAnexo(Guid arquivoId)
        {
            var comando = new RemoverArquivoCommand(arquivoId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);            

            return CustomResponse(Resultado);
        }





        #region Metodos Auxiliares

        private CadastrarComunicadoCommand CadastrarComunicadoCommandFactory
            (CadastraComunicadoViewModel comunicadoVM, CondominioFlat condominio, Usuario usuario)
        {
            var listaUnidadesComunicado = new List<UnidadeComunicado>();
            if (comunicadoVM.UnidadesId != null)
            {
                foreach (Guid unidadeId in comunicadoVM.UnidadesId)
                {
                    var unidade = _principalQuery.ObterUnidadePorId(unidadeId).Result;
                    if (unidade != null)
                    {
                        var unidadeComunicado = new UnidadeComunicado(unidade.Id, unidade.Numero, unidade.Andar, unidade.GrupoId, unidade.GrupoDescricao);
                        listaUnidadesComunicado.Add(unidadeComunicado);
                    }                        
                }
            }
           
           return new CadastrarComunicadoCommand(
                comunicadoVM.Titulo, comunicadoVM.Descricao, comunicadoVM.DataDeRealizacao,
                comunicadoVM.CondominioId, condominio.Nome, usuario.Id,
                usuario.NomeCompleto, comunicadoVM.Visibilidade, comunicadoVM.Categoria,
                comunicadoVM.TemAnexos, comunicadoVM.CriadoPelaAdministradora, listaUnidadesComunicado);
        }

        private EditarComunicadoCommand EditarComunicadoCommandFactory(EditaComunicadoViewModel comunicadoVM, Usuario usuario)
        {
            var listaUnidadesComunicado = new List<UnidadeComunicado>();
            if (comunicadoVM.UnidadesId != null)
            {
                foreach (Guid unidadeId in comunicadoVM.UnidadesId)
                {
                    var unidade = _principalQuery.ObterUnidadePorId(unidadeId).Result;
                    if (unidade!=null)
                    {
                        var unidadeComunicado = new UnidadeComunicado
                            (unidade.Id, unidade.Numero, unidade.Andar, unidade.GrupoId, unidade.GrupoDescricao);
                        listaUnidadesComunicado.Add(unidadeComunicado);
                    }                    
                }
            }

            //Edita Comunicado
            return new EditarComunicadoCommand(
                comunicadoVM.ComunicadoId, comunicadoVM.Titulo, comunicadoVM.Descricao, comunicadoVM.DataDeRealizacao,
                usuario.Id, usuario.NomeCompleto, comunicadoVM.Visibilidade, comunicadoVM.Categoria,
                comunicadoVM.TemAnexos, listaUnidadesComunicado);

        }


        private async Task SalvarAnexos
            (List<CadastraAnexoComunicadoViewModel> anexos, ComunicadoCommand comando, Guid condominioId)
        {
            comando.SetCondominioId(condominioId);

            var pasta = await ObterPastaDoSistema(comando);

            await ExcluirAnexos(comando);

            foreach (CadastraAnexoComunicadoViewModel anexo in anexos)
            {
                var comandoCadastraArquivo = CadastrarArquivoCommandFactory(anexo, comando, pasta.Id);
                var ResultadoCadastroArquivo = await _mediatorHandler.EnviarComando(comandoCadastraArquivo);
                if (!ResultadoCadastroArquivo.IsValid)
                    CustomResponse(ResultadoCadastroArquivo);
            }
        }        

        private CadastrarPastaCommand CadastrarPastaCommandFactory
            (Guid condominioId, CategoriaDaPastaDeSistema categoriaDaPastaDeSistema)
        {
            return new CadastrarPastaCommand
                (categoriaDaPastaDeSistema.ToString(), "Pasta de ocorrências do sistema",
                condominioId, true, true, categoriaDaPastaDeSistema);
        }

        private CadastrarArquivoCommand CadastrarArquivoCommandFactory
            (CadastraAnexoComunicadoViewModel anexo, ComunicadoCommand comunicadoCommand, Guid pastaId)
        {
            var arquivoPublico = false;
            if (comunicadoCommand.Visibilidade == VisibilidadeComunicado.PUBLICO)
                arquivoPublico = true;

            return new CadastrarArquivoCommand
                (anexo.NomeOriginal, anexo.Tamanho, pastaId, arquivoPublico, comunicadoCommand.UsuarioId,
                 comunicadoCommand.NomeUsuario, "Anexo de Comunicado", "", comunicadoCommand.ComunicadoId);
        }


        private async Task<IEnumerable<AnexoComunicadoViewModel>> ObterAnexos(Comunicado comunicado)
        {
            var anexosVM = new List<AnexoComunicadoViewModel>();
            var anexos = await _arquivoDigitalQuery.ObterArquivosPorAnexadoPorId(comunicado.Id);
            if (anexos == null)
                return anexosVM;

            
            foreach (Arquivo item in anexos)
            {
                var anexoVM = new AnexoComunicadoViewModel
                    (item.Id, item.Nome.NomeDoArquivo, item.Nome.NomeOriginal,
                     item.Nome.ExtensaoDoArquivo, item.Tamanho);                
                anexosVM.Add(anexoVM);
            }

            return anexosVM.ToList();
        }

        private async Task<Pasta> ObterPastaDoSistema(ComunicadoCommand comando)
        {
            var categoriaDaPastaDoSistema = ObterCategoriaDePastaDeSistema(comando.Categoria);

            var pasta = await _arquivoDigitalQuery.ObterPastaDeSistema
                   (categoriaDaPastaDoSistema, comando.CondominioId);

            if (pasta == null)
            {
                var comandoCadastrarPasta = CadastrarPastaCommandFactory(comando.CondominioId, categoriaDaPastaDoSistema);
                var ResultadoCadastroPasta = await _mediatorHandler.EnviarComando(comandoCadastrarPasta);
                if (!ResultadoCadastroPasta.IsValid)
                    CustomResponse(ResultadoCadastroPasta);
                pasta = await _arquivoDigitalQuery.ObterPorId(comandoCadastrarPasta.Id);
            }

            return pasta;

        }

        private CategoriaDaPastaDeSistema ObterCategoriaDePastaDeSistema(CategoriaComunicado categoria)
        {
            switch (categoria)
            {
                case CategoriaComunicado.ATA:
                    return CategoriaDaPastaDeSistema.ATA;

                case CategoriaComunicado.AVISO:
                    return CategoriaDaPastaDeSistema.AVISO;

                case CategoriaComunicado.BALANCETE:
                    return CategoriaDaPastaDeSistema.BALANCETE;

                case CategoriaComunicado.COBRANÇA:
                    return CategoriaDaPastaDeSistema.COBRANÇA;

                case CategoriaComunicado.COMUNICADO:
                    return CategoriaDaPastaDeSistema.COMUNICADO;

                case CategoriaComunicado.MANUTENÇÃO:
                    return CategoriaDaPastaDeSistema.MANUTENÇÃO;

                case CategoriaComunicado.OBRA_REFORMA:
                    return CategoriaDaPastaDeSistema.OBRA_REFORMA;

                case CategoriaComunicado.OUTROS:
                    return CategoriaDaPastaDeSistema.OUTROS;

                case CategoriaComunicado.URGENCIA:
                    return CategoriaDaPastaDeSistema.URGENCIA;

                default:
                    return 0;
            }
        }

        private async Task ExcluirAnexos(ComunicadoCommand comando)
        {
            var anexosExistentes = await _arquivoDigitalQuery.ObterArquivosPorAnexadoPorId(comando.ComunicadoId);
            foreach (Arquivo item in anexosExistentes)
            {
                var comandoExcluiArquivo = new RemoverArquivoCommand(item.Id);
                await _mediatorHandler.EnviarComando(comandoExcluiArquivo);
            }
        }

        #endregion


    }
}
