using AutoMapper;
using CondominioApp.ArquivoDigital.App.Aplication.Commands;
using CondominioApp.ArquivoDigital.App.Aplication.Query;
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
                await SalvarAnexos(comunicadoVM, comando);
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
        public async Task<ActionResult> Put(EditarComunicadoViewModel comunicadoVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
                        

            var usuario = await _usuarioQuery.ObterPorId(comunicadoVM.UsuarioId);
            if (usuario == null)
            {
                AdicionarErroProcessamento("Usuario não encontrado!");
                return CustomResponse();
            }

            var comando = EditarComunicadoCommandFactory(comunicadoVM, usuario);

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




        private CadastrarComunicadoCommand CadastrarComunicadoCommandFactory(CadastrarComunicadoViewModel comunicadoVM, CondominioFlat condominio, Usuario usuario)
        {
            var listaUnidadesComunicado = new List<UnidadeComunicado>();
            if (comunicadoVM.UnidadesId != null)
            {
                foreach (Guid unidadeId in comunicadoVM.UnidadesId)
                {
                    var unidade = _principalQuery.ObterUnidadePorId(unidadeId).Result;
                    var unidadeComunicado = new UnidadeComunicado(unidade.Id, unidade.Numero, unidade.Andar, unidade.GrupoId, unidade.GrupoDescricao);
                    listaUnidadesComunicado.Add(unidadeComunicado);
                }
            }
           
           return new CadastrarComunicadoCommand(
                comunicadoVM.Titulo, comunicadoVM.Descricao, comunicadoVM.DataDeRealizacao,
                comunicadoVM.CondominioId, condominio.Nome, usuario.Id,
                usuario.NomeCompleto, comunicadoVM.Visibilidade, comunicadoVM.Categoria,
                comunicadoVM.TemAnexos, comunicadoVM.CriadoPelaAdministradora, listaUnidadesComunicado);
        }

        private EditarComunicadoCommand EditarComunicadoCommandFactory(EditarComunicadoViewModel comunicadoVM, Usuario usuario)
        {
            var listaUnidadesComunicado = new List<UnidadeComunicado>();
            if (comunicadoVM.UnidadesId != null)
            {
                foreach (Guid unidadeId in comunicadoVM.UnidadesId)
                {
                    var unidade = _principalQuery.ObterUnidadePorId(unidadeId).Result;
                    var unidadeComunicado = new UnidadeComunicado(unidade.Id, unidade.Numero, unidade.Andar, unidade.GrupoId, unidade.GrupoDescricao);
                    listaUnidadesComunicado.Add(unidadeComunicado);
                }
            }

            //Edita Comunicado
            return new EditarComunicadoCommand(
                comunicadoVM.ComunicadoId, comunicadoVM.Titulo, comunicadoVM.Descricao, comunicadoVM.DataDeRealizacao,
                usuario.Id, usuario.NomeCompleto, comunicadoVM.Visibilidade, comunicadoVM.Categoria,
                comunicadoVM.TemAnexos, listaUnidadesComunicado);

        }


        private async Task SalvarAnexos(CadastrarComunicadoViewModel comunicadoVM, CadastrarComunicadoCommand comando)
        {
            var categoriaDaPastaDoSistema = ObterCategoriaDePastaDeSistema(comunicadoVM.Categoria);
            var pasta = await _arquivoDigitalQuery.ObterPastaDeSistema
                   (categoriaDaPastaDoSistema, comunicadoVM.CondominioId);

            if (pasta == null)
            {
                var comandoCadastrarPasta = CadastrarPastaCommandFactory(comunicadoVM.CondominioId, categoriaDaPastaDoSistema);
                var ResultadoCadastroPasta = await _mediatorHandler.EnviarComando(comandoCadastrarPasta);
                if (!ResultadoCadastroPasta.IsValid)
                    CustomResponse(ResultadoCadastroPasta);
            }
            foreach (AnexoComunicadoViewModel anexo in comunicadoVM.Anexos)
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
                condominioId, false, true, categoriaDaPastaDeSistema);
        }

        private CadastrarArquivoCommand CadastrarArquivoCommandFactory
            (AnexoComunicadoViewModel anexo, CadastrarComunicadoCommand ocorrenciaCommand, Guid pastaId)
        {
            var arquivoPublico = false;
            if (ocorrenciaCommand.Visibilidade == VisibilidadeComunicado.PUBLICO)
                arquivoPublico = true;

            return new CadastrarArquivoCommand
                (anexo.NomeOriginal, anexo.Tamanho, pastaId, arquivoPublico, ocorrenciaCommand.UsuarioId,
                anexo.NomeOriginal, "Anexo de Ocorrencia", "", ocorrenciaCommand.ComunicadoId);
        }

        private CategoriaDaPastaDeSistema ObterCategoriaDePastaDeSistema(CategoriaComunicado categoriaComunicado)
        {
            switch (categoriaComunicado)
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
    }
}
