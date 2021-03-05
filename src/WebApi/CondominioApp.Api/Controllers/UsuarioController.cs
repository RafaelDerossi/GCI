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

namespace CondominioApp.Api.Controllers
{
    [Route("/api/usuario")]
    public class UsuarioController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;        
        private readonly IUsuarioQuery _usuarioQuery;
        private readonly IMapper _mapper;

        public UsuarioController(IMediatorHandler mediatorHandler, IUsuarioQuery usuarioQuery, IMapper mapper)
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

    }
}