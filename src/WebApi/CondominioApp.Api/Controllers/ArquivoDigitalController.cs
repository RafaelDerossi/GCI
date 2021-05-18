using AutoMapper;
using CondominioApp.ArquivoDigital.App.Aplication.Commands;
using CondominioApp.ArquivoDigital.App.Aplication.Query;
using CondominioApp.ArquivoDigital.App.Models;
using CondominioApp.Core.Mediator;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Usuarios.App.Aplication.Query;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("api/arquivo_digital")]
    public class ArquivoDigitalController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IArquivoDigitalQuery _arquivoDigitalQuery;
        public readonly IMapper _mapper;
        private readonly IPrincipalQuery _principalQuery;
        private readonly IUsuarioQuery _usuarioQuery;        

        public ArquivoDigitalController
            (IMediatorHandler mediatorHandler, IArquivoDigitalQuery arquivoDigitalQuery,
            IMapper mapper, IPrincipalQuery principalQuery, IUsuarioQuery usuarioQuery)
        {
            _mediatorHandler = mediatorHandler;
            _arquivoDigitalQuery = arquivoDigitalQuery;
            _mapper = mapper;
            _principalQuery = principalQuery;
            _usuarioQuery = usuarioQuery;
        }


        #region Pasta

        [HttpGet("raiz-por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<SubPastaViewModel>>> ObterPastasRaizesPorCondominio(Guid condominioId)
        {
            var pastas = await _arquivoDigitalQuery.ObterPastasRaizesPorCondominio(condominioId);
            if (pastas.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var pastasVM = new List<SubPastaViewModel>();
            foreach (Pasta item in pastas)
            {
                var pastaVM = _mapper.Map<SubPastaViewModel>(item);
                pastasVM.Add(pastaVM);
            }
            return pastasVM;
        }

        [HttpGet("conteudo/{pastaId:Guid}")]
        public async Task<ActionResult<ConteudoPastaViewModel>> ObterConteudoDaPasta(Guid pastaId)
        {
            var pasta = await _arquivoDigitalQuery.ObterPastaComConteudo(pastaId);
            if (pasta == null)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            ConteudoPastaViewModel conteudoPastaViewModel = _mapper.Map<ConteudoPastaViewModel>(pasta);
            conteudoPastaViewModel.Subpastas = new List<SubPastaViewModel>();
            foreach (var subpasta in pasta.Pastas)
            {
                var subpastaViewModel = _mapper.Map<SubPastaViewModel>(subpasta);
                conteudoPastaViewModel.Subpastas.Add(subpastaViewModel);
            }
            
            
            return conteudoPastaViewModel;
        }



        [HttpPost("pasta-raiz")]
        public async Task<ActionResult> PostPastaRaiz(AdicionaPastaRaizViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var condominio = await _principalQuery.ObterPorId(viewModel.CondominioId);
            if (condominio == null)
            {
                AdicionarErroProcessamento("Condominio não encontrado!");
                return CustomResponse();
            }

            var comando = new AdicionarPastaRaizCommand
                (viewModel.Titulo, viewModel.Descricao, viewModel.CondominioId, viewModel.Publica);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        [HttpPost("subpasta")]
        public async Task<ActionResult> PostSubPasta(AdicionaSubPastaViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);            

            var comando = new AdicionarSubPastaCommand
                (viewModel.Titulo, viewModel.Descricao, viewModel.Publica, viewModel.PastaMaeId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }


        [HttpPut("pasta")]
        public async Task<ActionResult> PutPasta(AtualizaPastaViewModel pastaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AtualizarPastaCommand(pastaVM.Id, pastaVM.Titulo, pastaVM.Descricao, pastaVM.Publica);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        [HttpPut("marcar-pasta-como-publica/{pastaId:Guid}")]
        public async Task<ActionResult> PutMarcarPastaPublica(Guid pastaId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new MarcarPastaComoPublicaCommand(pastaId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("marcar-pasta-como-privada/{pastaId:Guid}")]
        public async Task<ActionResult> PutMarcarPastaPrivada(Guid pastaId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new MarcarPastaComoPrivadaCommand(pastaId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("mover-pasta-para-raiz/{pastaId:Guid}")]
        public async Task<ActionResult> PutMoverParaRaiz(Guid pastaId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new MoverPastaParaRaizCommand(pastaId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("mover-subpasta")]
        public async Task<ActionResult> PutMoverParaRaiz(Guid pastaId, Guid pastaMaeId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new MoverSubPastaCommand(pastaId, pastaMaeId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }


        [HttpDelete("pasta/{pastaId:Guid}")]
        public async Task<ActionResult> DeletePasta(Guid pastaId)
        {
            var comando = new ApagarPastaCommand(pastaId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        #endregion



        #region Arquivo

        [HttpGet("arquivo/{id:Guid}")]
        public async Task<ActionResult<ArquivoViewModel>> ObterArquivoPorId(Guid id)
        {
            var arquivo = await _arquivoDigitalQuery.ObterArquivoPorId(id);
            if (arquivo == null)
            {
                AdicionarErroProcessamento("Arquivo não encontrado.");
                return CustomResponse();
            }

            var arquivoVM = _mapper.Map<ArquivoViewModel>(arquivo);

            return arquivoVM;
        }

        [HttpGet("arquivos-por-pasta/{pastaId:Guid}")]
        public async Task<ActionResult<IEnumerable<ArquivoViewModel>>> ObterArquivosPorPasta(Guid pastaId)
        {
            var arquivos = await _arquivoDigitalQuery.ObterArquivosPorPasta(pastaId);
            if (arquivos.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var arquivosVM = new List<ArquivoViewModel>();
            foreach (Arquivo item in arquivos)
            {
                var arquivoVM = _mapper.Map<ArquivoViewModel>(item);
                arquivosVM.Add(arquivoVM);
            }
            return arquivosVM;
        }

        [HttpGet("arquivos-por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<ArquivoViewModel>>> ObterArquivosPorCondominio(Guid condominioId)
        {
            var arquivos = await _arquivoDigitalQuery.ObterArquivosPorCondominio(condominioId);
            if (arquivos.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var arquivosVM = new List<ArquivoViewModel>();
            foreach (Arquivo item in arquivos)
            {
                var arquivoVM = _mapper.Map<ArquivoViewModel>(item);
                arquivosVM.Add(arquivoVM);
            }
            return arquivosVM;
        }



        [HttpPost("arquivo")]
        public async Task<ActionResult> PostArquivo([FromForm]AdicionaArquivoViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var funcionario = await _usuarioQuery.ObterFuncionarioPorId(viewModel.FuncionarioId);
            if (funcionario == null)
            {
                AdicionarErroProcessamento("Funcionário não encontrado!");
                return CustomResponse();
            }            
                
            var comando = new AdicionarArquivoCommand
                (viewModel.PastaId, viewModel.Publico, funcionario.Id, funcionario.NomeCompleto, viewModel.Titulo,
                 viewModel.Descricao, Guid.Empty, viewModel.Arquivo);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        [HttpPut("arquivo")]
        public async Task<ActionResult> Put(AtualizaArquivoViewModel arquivoVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AtualizarArquivoCommand
                (arquivoVM.Id, arquivoVM.Titulo, arquivoVM.Descricao, arquivoVM.Publico,
                 arquivoVM.NomeOriginal);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);

        }

        [HttpPut("alterar-pasta-do-arquivo")]
        public async Task<ActionResult> PutAlterarPastaDoArquivo(Guid arquivoId, Guid pastaId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AlterarPastaDoArquivoCommand(arquivoId, pastaId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("marcar-arquivo-como-publico/{arquivoId:Guid}")]
        public async Task<ActionResult> PutMarcarArquivoComoPublico(Guid arquivoId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new MarcarArquivoComoPublicoCommand(arquivoId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("marcar-arquivo-como-privado/{arquivoId:Guid}")]
        public async Task<ActionResult> PutMarcarArquivoComoPrivado(Guid arquivoId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new MarcarArquivoComoPrivadoCommand(arquivoId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }



        [HttpDelete("arquivo/{arquivoId:Guid}")]
        public async Task<ActionResult> DeleteArquivo(Guid arquivoId)
        {
            var comando = new ApagarArquivoCommand(arquivoId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        #endregion


    }
}
