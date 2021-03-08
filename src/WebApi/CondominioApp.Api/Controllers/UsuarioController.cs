using CondominioApp.Core.Mediator;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Usuarios.App.Aplication.Query;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CondominioApp.Usuarios.App.ViewModels;
using AutoMapper;
using CondominioApp.Usuarios.App.Aplication.Commands;
using System.Linq;
using CondominioApp.Usuarios.App.FlatModel;
using System.Collections.Generic;

namespace CondominioApp.Api.Controllers
{
    [Route("/api/usuario")]
    public class UsuarioController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IUsuarioQuery _usuarioQuery;
        private readonly ICondominioQuery _condominioQuery;
        private readonly IMapper _mapper;

        public UsuarioController(IMediatorHandler mediatorHandler, IUsuarioQuery usuarioQuery,
            ICondominioQuery condominioQuery, IMapper mapper)
        {
            _mediatorHandler = mediatorHandler;            
            _usuarioQuery = usuarioQuery;
            _condominioQuery = condominioQuery;
            _mapper = mapper;
        }



        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<UsuarioViewModel>> ObterPorId(Guid id)
        {
            var usuario = await _usuarioQuery.ObterPorId(id);
            if (usuario == null)
            {
                AdicionarErroProcessamento("Usuário não encontrado.");
                return CustomResponse();
            }

            return _mapper.Map<UsuarioViewModel>(usuario); ;
        }

        [HttpGet("moradores/{usuarioId:Guid}")]
        public async Task<ActionResult<IEnumerable<MoradorFlat>>> ObterMoradoresPorUsuarioId(Guid usuarioId)
        {
            var morador = await _usuarioQuery.ObterMoradoresPorUsuarioId(usuarioId);
            if (morador.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum morador encontrado.");
                return CustomResponse();
            }

            return morador.ToList();
        }

        [HttpGet("funcionarios/{usuarioId:Guid}")]
        public async Task<ActionResult<IEnumerable<FuncionarioFlat>>> ObterFuncionariosPorUsuarioId(Guid usuarioId)
        {
            var funcionario = await _usuarioQuery.ObterFuncionariosPorUsuarioId(usuarioId);
            if (funcionario.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum funcionario encontrado.");
                return CustomResponse();
            }

            return funcionario.ToList();
        }




        [HttpPost("registrar-dispositivo")]
        public async Task<ActionResult> Post(CadastraMobileViewModel mobileVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var usuario = await _usuarioQuery.ObterPorId(mobileVM.UsuarioId);
            if (usuario == null)
            {
                AdicionarErroProcessamento("Usuario não encontrado!");
                return CustomResponse();
            }

            if (!usuario.Mobiles.Any(m => m.MobileId == mobileVM.MobileId))
            {
                var cadastrarComando = new CadastrarMobileCommand
                (mobileVM.DeviceKey, mobileVM.MobileId, mobileVM.Modelo, mobileVM.Plataforma, mobileVM.Versao, mobileVM.UsuarioId);

                var result = await _mediatorHandler.EnviarComando(cadastrarComando);

                if (!result.IsValid)
                    CustomResponse(result);


                return CustomResponse();
            }

            var mobileBD = usuario.Mobiles.Where(m => m.MobileId == mobileVM.MobileId).FirstOrDefault();

            var editarComando = new EditarMobileCommand
                (mobileBD.Id, mobileVM.DeviceKey, mobileVM.MobileId, mobileVM.Modelo, mobileVM.Plataforma, mobileVM.Versao, mobileVM.UsuarioId);

            var resultado = await _mediatorHandler.EnviarComando(editarComando);

            if (!resultado.IsValid)
                CustomResponse(resultado);


            return CustomResponse();

        }


        [HttpPost("vincular-morador-unidade")]        
        public async Task<ActionResult> Post(VincularMoradorUnidadeViewModel vincularViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var morador = await _usuarioQuery.ObterMoradorPorId(vincularViewModel.UsuarioId);
            if (morador == null)
            {
                AdicionarErroProcessamento("Morador não encontrado!");
                return CustomResponse();
            }

            var unidade = await _condominioQuery.ObterUnidadePorId(vincularViewModel.UnidadeId);
            if (unidade == null)
            {
                AdicionarErroProcessamento("Unidade não encontrada!");
                return CustomResponse();
            }

            var comando = new CadastrarMoradorCommand
                (morador.UsuarioId, unidade.CondominioId, unidade.CondominioNome, unidade.Id,
                unidade.Numero, unidade.Andar, unidade.GrupoDescricao, vincularViewModel.Proprietario,
                vincularViewModel.Principal);

            var resultado = await _mediatorHandler.EnviarComando(comando);

            if (!resultado.IsValid)
                CustomResponse(resultado);


            return CustomResponse();

        }


        [HttpPost("vincular-funcionario-condominio")]
        public async Task<ActionResult> Post(VincularFuncionarioCondominioViewModel vincularViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var funcionario = await _usuarioQuery.ObterFuncionarioPorId(vincularViewModel.UsuarioId);
            if (funcionario == null)
            {
                AdicionarErroProcessamento("Funcionario não encontrado!");
                return CustomResponse();
            }

            var condominio = await _condominioQuery.ObterPorId(vincularViewModel.CondominioId);
            if (condominio == null)
            {
                AdicionarErroProcessamento("Condomínio não encontrado!");
                return CustomResponse();
            }

            var comando = new CadastrarFuncionarioCommand
                (funcionario.UsuarioId, condominio.Id, condominio.Nome, vincularViewModel.Atribuicao,
                vincularViewModel.Funcao, vincularViewModel.Permissao);

            var resultado = await _mediatorHandler.EnviarComando(comando);

            if (!resultado.IsValid)
                CustomResponse(resultado);


            return CustomResponse();

        }


        [HttpPost("marcar-como-unidadePrincipal/{moradorId:Guid}")]
        public async Task<ActionResult> Post(Guid moradorId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var morador = await _usuarioQuery.ObterMoradorPorId(moradorId);
            if (morador == null)
            {
                AdicionarErroProcessamento("Morador não encontrado!");
                return CustomResponse();
            }

            var comando = new MarcarComoUnidadePrincipalCommand(morador.Id);

            var resultado = await _mediatorHandler.EnviarComando(comando);

            if (!resultado.IsValid)
                CustomResponse(resultado);


            return CustomResponse();

        }


        [HttpPost("marcar-como-proprietario/{moradorId:Guid}")]
        public async Task<ActionResult> PostMarcarComoProprietario(Guid moradorId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var morador = await _usuarioQuery.ObterMoradorPorId(moradorId);
            if (morador == null)
            {
                AdicionarErroProcessamento("Morador não encontrado!");
                return CustomResponse();
            }

            var comando = new MarcarComoProprietarioCommand(morador.Id);

            var resultado = await _mediatorHandler.EnviarComando(comando);

            if (!resultado.IsValid)
                CustomResponse(resultado);


            return CustomResponse();
        }


        [HttpPost("desmarcar-como-proprietario/{moradorId:Guid}")]
        public async Task<ActionResult> PostDesmarcarComoProprietario(Guid moradorId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var morador = await _usuarioQuery.ObterMoradorPorId(moradorId);
            if (morador == null)
            {
                AdicionarErroProcessamento("Morador não encontrado!");
                return CustomResponse();
            }

            var comando = new DesmarcarComoProprietarioCommand(morador.Id);

            var resultado = await _mediatorHandler.EnviarComando(comando);

            if (!resultado.IsValid)
                CustomResponse(resultado);


            return CustomResponse();
        }

    }
}