using AutoMapper;
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

            var funcionario = await _usuarioQuery.ObterFuncionarioPorId(comunicado.Id);
            comunicadoVM.NomeFuncionario = funcionario.NomeCompleto;
            comunicadoVM.FotoFuncionario = funcionario.Foto;

            //Obtem Anexos
            if (comunicado.TemAnexos)
            {
                var anexos = await ObterAnexos(comunicado);
                comunicadoVM.Anexos = anexos;
            }

            return comunicadoVM;
        }

        [HttpGet("por-unidade-e-proprietario")]
        public async Task<ActionResult<IEnumerable<ComunicadoViewModel>>> ObterPorCondominioUnidadeEProprietario
            (Guid unidadeId, bool IsProprietario)
        {
            var unidade = await _principalQuery.ObterUnidadePorId(unidadeId);
            if (unidade == null)
            {
                AdicionarErroProcessamento("Unidade não encontrada!");
                return CustomResponse();
            }

            var comunicados = await _comunicadoQuery.ObterPorCondominioEUnidadeEProprietario(
               unidade.CondominioId, unidadeId, IsProprietario);
            if (comunicados.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var comunicadosVM = MapperListEntityToViewModel(comunicados);

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

            var comunicadosVM = MapperListEntityToViewModel(comunicados);

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

            var comunicadosVM = MapperListEntityToViewModel(comunicados);

            return comunicadosVM;
        }



        [HttpPost]
        public async Task<ActionResult> Post(AdicionaComunicadoViewModel comunicadoVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var funcionario = await _usuarioQuery.ObterFuncionarioPorId(comunicadoVM.FuncionarioId);
            if (funcionario == null)
            {
                AdicionarErroProcessamento("Funcionário não encontrado!");
                return CustomResponse();
            }

            var condominio = await _principalQuery.ObterPorId(funcionario.CondominioId);
            if(condominio == null)
            {
                AdicionarErroProcessamento("Condominio não encontrado!");
                return CustomResponse();
            }
            
            var comando = AdicionarComunicadoCommandFactory(comunicadoVM, condominio, funcionario);
            
            //Salva Anexos
            if (comunicadoVM.TemAnexos)
            {
                await SalvarAnexos(comunicadoVM.Anexos.ToList(), comando);
                if (!OperacaoValida())
                    return CustomResponse();                
            }

            var resultado = await _mediatorHandler.EnviarComando(comando);
            if (!resultado.IsValid)
            {
                await ApagarAnexos(comando);
                return CustomResponse(resultado);
            }

            return CustomResponse();

        }

        [HttpPut]
        public async Task<ActionResult> Put(AtualizaComunicadoViewModel comunicadoVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
                        

            var funcionario = await _usuarioQuery.ObterFuncionarioPorId(comunicadoVM.FuncionarioId);
            if (funcionario == null)
            {
                AdicionarErroProcessamento("Funcionário não encontrado!");
                return CustomResponse();
            }

            var comunicado = await _comunicadoQuery.ObterPorId(comunicadoVM.ComunicadoId);
            if (comunicado == null)
            {
                AdicionarErroProcessamento("Comunicado não encontrado!");
                return CustomResponse();
            }

            var comando = AtualizarComunicadoCommandFactory(comunicadoVM, funcionario);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            //Salva Anexos
            if (Resultado.IsValid && comunicadoVM.TemAnexos)
            {
                await SalvarAnexos(comunicadoVM.Anexos.ToList(), comando);
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
            var comando = new ApagarComunicadoCommand(id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            //Remover Anexos
            if (Resultado.IsValid)
            {
               await ApagarAnexos(comando);
            }

            return CustomResponse(Resultado);
        }


        [HttpDelete("anexo/{arquivoId:Guid}")]
        public async Task<ActionResult> DeleteAnexo(Guid arquivoId)
        {
            var comando = new ApagarArquivoCommand(arquivoId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);            

            return CustomResponse(Resultado);
        }





        #region Metodos Auxiliares
        
        private List<ComunicadoViewModel> MapperListEntityToViewModel(IEnumerable<Comunicado> comunicados)
        {
            var comunicadosVM = new List<ComunicadoViewModel>();
            foreach (Comunicado comunicado in comunicados)
            {
                var comunicadoVM = _mapper.Map<ComunicadoViewModel>(comunicado);

                var funcionario = _usuarioQuery.ObterFuncionarioPorId(comunicado.FuncionarioId).Result;
                comunicadoVM.NomeFuncionario = funcionario.NomeCompleto;
                comunicadoVM.FotoFuncionario = funcionario.Foto;

                //Obtem Anexos
                if (comunicado.TemAnexos)
                {
                    var anexos = ObterAnexos(comunicado).Result;
                    comunicadoVM.Anexos = anexos;
                }

                comunicadosVM.Add(comunicadoVM);
            }
            return comunicadosVM;
        }


        private AdicionarComunicadoCommand AdicionarComunicadoCommandFactory
            (AdicionaComunicadoViewModel comunicadoVM, CondominioFlat condominio, FuncionarioFlat funcionario)
        {
            var listaUnidadesComunicado = new List<UnidadeComunicado>();
            if (comunicadoVM.UnidadesId != null)
            {
                foreach (Guid unidadeId in comunicadoVM.UnidadesId)
                {
                    var unidade = _principalQuery.ObterUnidadePorId(unidadeId).Result;
                    if (unidade != null)
                    {
                        var unidadeComunicado = new UnidadeComunicado
                            (unidade.Id, unidade.Numero, unidade.Andar, unidade.GrupoId, unidade.GrupoDescricao);
                        listaUnidadesComunicado.Add(unidadeComunicado);
                    }                        
                }
            }
           
           return new AdicionarComunicadoCommand(
                comunicadoVM.Titulo, comunicadoVM.Descricao, comunicadoVM.DataDeRealizacao,
                condominio.Id, condominio.Nome, funcionario.Id,
                funcionario.NomeCompleto, comunicadoVM.Visibilidade, comunicadoVM.Categoria,
                comunicadoVM.TemAnexos, comunicadoVM.CriadoPelaAdministradora, listaUnidadesComunicado);
        }

        private AtualizarComunicadoCommand AtualizarComunicadoCommandFactory
            (AtualizaComunicadoViewModel comunicadoVM, FuncionarioFlat funcionario)
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
            return new AtualizarComunicadoCommand(
                comunicadoVM.ComunicadoId, comunicadoVM.Titulo, comunicadoVM.Descricao, comunicadoVM.DataDeRealizacao,
                funcionario.Id, funcionario.NomeCompleto, comunicadoVM.Visibilidade, comunicadoVM.Categoria,
                comunicadoVM.TemAnexos, listaUnidadesComunicado);

        }


        private async Task SalvarAnexos
            (List<AdicionaAnexoComunicadoViewModel> anexos, ComunicadoCommand comando)
        {
            var pasta = await ObterPastaDoSistema(comando);

            await ApagarAnexos(comando);

            foreach (AdicionaAnexoComunicadoViewModel anexo in anexos)
            {
                var comandoCadastraArquivo = AdicionarArquivoCommandFactory(anexo, comando, pasta.Id);
                var ResultadoCadastroArquivo = await _mediatorHandler.EnviarComando(comandoCadastraArquivo);
                if (!ResultadoCadastroArquivo.IsValid)
                    CustomResponse(ResultadoCadastroArquivo);
            }
        }        

        private AdicionarPastaDeSistemaCommand AdicionarPastaDeSistemaCommandFactory
            (Guid condominioId, CategoriaDaPastaDeSistema categoriaDaPastaDeSistema)
        {
            return new AdicionarPastaDeSistemaCommand
                (categoriaDaPastaDeSistema.ToString(), "Pasta de ocorrências do sistema",
                 condominioId, categoriaDaPastaDeSistema);
        }

        private AdicionarArquivoCommand AdicionarArquivoCommandFactory
            (AdicionaAnexoComunicadoViewModel anexo, ComunicadoCommand comunicadoCommand, Guid pastaId)
        {
            var arquivoPublico = false;
            if (comunicadoCommand.Visibilidade == VisibilidadeComunicado.PUBLICO)
                arquivoPublico = true;

            return new AdicionarArquivoCommand
                (pastaId, arquivoPublico, comunicadoCommand.FuncionarioId, comunicadoCommand.NomeFuncionario,
                 "Anexo de Comunicado", "", comunicadoCommand.ComunicadoId, null);
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
                var comandoCadastrarPasta = AdicionarPastaDeSistemaCommandFactory(comando.CondominioId, categoriaDaPastaDoSistema);
                var ResultadoCadastroPasta = await _mediatorHandler.EnviarComando(comandoCadastrarPasta);
                if (!ResultadoCadastroPasta.IsValid)
                    CustomResponse(ResultadoCadastroPasta);
                pasta = await _arquivoDigitalQuery.ObterPorId(comandoCadastrarPasta.Id);
            }

            return pasta;

        }

        private CategoriaDaPastaDeSistema ObterCategoriaDePastaDeSistema(CategoriaComunicado categoria)
        {
            return categoria switch
            {
                CategoriaComunicado.ATA => CategoriaDaPastaDeSistema.ATA,
                CategoriaComunicado.AVISO => CategoriaDaPastaDeSistema.AVISO,
                CategoriaComunicado.BALANCETE => CategoriaDaPastaDeSistema.BALANCETE,
                CategoriaComunicado.COBRANÇA => CategoriaDaPastaDeSistema.COBRANÇA,
                CategoriaComunicado.COMUNICADO => CategoriaDaPastaDeSistema.COMUNICADO,
                CategoriaComunicado.MANUTENÇÃO => CategoriaDaPastaDeSistema.MANUTENÇÃO,
                CategoriaComunicado.OBRA_REFORMA => CategoriaDaPastaDeSistema.OBRA_REFORMA,
                CategoriaComunicado.OUTROS => CategoriaDaPastaDeSistema.OUTROS,
                CategoriaComunicado.URGENCIA => CategoriaDaPastaDeSistema.URGENCIA,
                _ => 0,
            };
        }

        private async Task ApagarAnexos(ComunicadoCommand comando)
        {
            var anexosExistentes = await _arquivoDigitalQuery.ObterArquivosPorAnexadoPorId(comando.ComunicadoId);
            foreach (Arquivo item in anexosExistentes)
            {
                var comandoApagarArquivo = new ApagarArquivoCommand(item.Id);
                await _mediatorHandler.EnviarComando(comandoApagarArquivo);
            }
        }

        #endregion


    }
}
