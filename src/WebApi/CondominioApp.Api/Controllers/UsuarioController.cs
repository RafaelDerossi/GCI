using CondominioApp.Core.Mediator;
using CondominioApp.Usuarios.App.Aplication.Query;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CondominioApp.Usuarios.App.ViewModels;
using AutoMapper;
using CondominioApp.Usuarios.App.Aplication.Commands;
using System.Linq;

namespace CondominioApp.Api.Controllers
{
    [Route("/api/usuario")]
    public class UsuarioController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IUsuarioQuery _usuarioQuery;        
        private readonly IMapper _mapper;

        public UsuarioController(IMediatorHandler mediatorHandler, IUsuarioQuery usuarioQuery,
            IMapper mapper)
        {
            _mediatorHandler = mediatorHandler;            
            _usuarioQuery = usuarioQuery;            
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

        [HttpPut]
        public async Task<ActionResult> Put(EditaUsuarioViewModel usuarioVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

           var editarComando = new EditarUsuarioCommand
                (usuarioVM.Id, usuarioVM.Nome, usuarioVM.Sobrenome, usuarioVM.Email,
                 usuarioVM.Rg, usuarioVM.Cpf, usuarioVM.Foto, usuarioVM.NomeOriginal,
                 usuarioVM.Celular, usuarioVM.Telefone, usuarioVM.Logradouro,
                 usuarioVM.Complemento, usuarioVM.Numero, usuarioVM.Cep, usuarioVM.Bairro,
                 usuarioVM.Bairro, usuarioVM.Estado, usuarioVM.DataNascimento);            

            return CustomResponse(await _mediatorHandler.EnviarComando(editarComando));
        }

    }
}