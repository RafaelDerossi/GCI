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
    [Route("/api/funcionario")]
    public class FuncionarioController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IUsuarioQuery _usuarioQuery;
        private readonly IPrincipalQuery _principalQuery;        

        public FuncionarioController(IMediatorHandler mediatorHandler, IUsuarioQuery usuarioQuery,
            IPrincipalQuery principalQuery)
        {
            _mediatorHandler = mediatorHandler;            
            _usuarioQuery = usuarioQuery;
            _principalQuery = principalQuery;            
        }


        [HttpGet("{funcionarioId:Guid}")]
        public async Task<ActionResult<FuncionarioFlat>> ObterFuncionarioPorId(Guid funcionarioId)
        {
            var funcionario = await _usuarioQuery.ObterFuncionarioPorId(funcionarioId);
            if (funcionario == null)
            {
                AdicionarErroProcessamento("Nenhum funcionario encontrado.");
                return CustomResponse();
            }

            return funcionario;
        }

        [HttpGet("funcionarios-por-usuario/{usuarioId:Guid}")]
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

        [HttpGet("funcionarios-por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<FuncionarioFlat>>> ObterFuncionariosPorCondominio(Guid condominioId)
        {
            var funcionario = await _usuarioQuery.ObterFuncionariosPorCondominioId(condominioId);
            if (funcionario.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum funcionario encontrado.");
                return CustomResponse();
            }

            return funcionario.ToList();
        }


        [HttpPost("vincular-funcionario-condominio")]
        public async Task<ActionResult> Post(VincularFuncionarioCondominioViewModel vincularViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var usuario = await _usuarioQuery.ObterPorId(vincularViewModel.UsuarioId);
            if (usuario == null)
            {
                AdicionarErroProcessamento("Usuário não encontrado!");
                return CustomResponse();
            }

            var condominio = await _principalQuery.ObterPorId(vincularViewModel.CondominioId);
            if (condominio == null)
            {
                AdicionarErroProcessamento("Condomínio não encontrado!");
                return CustomResponse();
            }

            var comando = new CadastrarFuncionarioCommand
                (usuario.Id, condominio.Id, condominio.Nome, vincularViewModel.Atribuicao,
                vincularViewModel.Funcao, vincularViewModel.Permissao);

            var resultado = await _mediatorHandler.EnviarComando(comando);

            if (!resultado.IsValid)
                CustomResponse(resultado);


            return CustomResponse();

        }

        [HttpPost("registrar-dispositivo")]
        public async Task<ActionResult> PostRegistrarDispositivo(CadastraMobileFuncionarioViewModel mobileVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var registrarComando = new RegistrarFuncionarioMobileCommand
                (mobileVM.DeviceKey, mobileVM.MobileId, mobileVM.Modelo, mobileVM.Plataforma, mobileVM.Versao,
                mobileVM.FuncionarioId);

            var result = await _mediatorHandler.EnviarComando(registrarComando);
            return CustomResponse(result);
        }



        [HttpPut("editar-funcionario")]
        public async Task<ActionResult> Put(EditaFuncionarioViewModel editaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var funcionario = await _usuarioQuery.ObterFuncionarioPorId(editaViewModel.FuncionarioId);
            if (funcionario == null)
            {
                AdicionarErroProcessamento("Funcionario não encontrado!");
                return CustomResponse();
            }

            var comando = new EditarFuncionarioCommand
                (funcionario.Id, editaViewModel.Atribuicao, editaViewModel.Funcao, editaViewModel.Permissao);

            var resultado = await _mediatorHandler.EnviarComando(comando);

            if (!resultado.IsValid)
                CustomResponse(resultado);


            return CustomResponse();

        }


        [HttpPut("ativar/{funcionarioId:Guid}")]
        public async Task<ActionResult> PutAtivar(Guid funcionarioId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
           
            var comando = new AtivarFuncionarioCommand(funcionarioId);

            var resultado = await _mediatorHandler.EnviarComando(comando);

            if (!resultado.IsValid)
                CustomResponse(resultado);


            return CustomResponse();

        }


        [HttpPut("desativar/{funcionarioId:Guid}")]
        public async Task<ActionResult> PutDesativar(Guid funcionarioId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new DesativarFuncionarioCommand(funcionarioId);

            var resultado = await _mediatorHandler.EnviarComando(comando);

            if (!resultado.IsValid)
                CustomResponse(resultado);


            return CustomResponse();

        }

    }
}