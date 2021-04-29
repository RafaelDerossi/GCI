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
    [Route("/api/morador")]
    public class MoradorController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IUsuarioQuery _usuarioQuery;
        private readonly IPrincipalQuery _principalQuery;       

        public MoradorController(IMediatorHandler mediatorHandler, IUsuarioQuery usuarioQuery,
            IPrincipalQuery principalQuery)
        {
            _mediatorHandler = mediatorHandler;            
            _usuarioQuery = usuarioQuery;
            _principalQuery = principalQuery;          
        }



        [HttpGet("{moradorId:Guid}")]
        public async Task<ActionResult<MoradorFlat>> ObterMoradorPorId(Guid moradorId)
        {
            var morador = await _usuarioQuery.ObterMoradorPorId(moradorId);
            if (morador == null)
            {
                AdicionarErroProcessamento("Nenhum morador encontrado.");
                return CustomResponse();
            }

            return morador;
        }

        [HttpGet("moradores-por-usuario/{usuarioId:Guid}")]
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

        [HttpGet("moradores-por-unidade/{unidadeId:Guid}")]
        public async Task<ActionResult<IEnumerable<MoradorFlat>>> ObterMoradoresPorUnidadeId(Guid unidadeId)
        {
            var morador = await _usuarioQuery.ObterMoradoresPorUnidadeId(unidadeId);
            if (morador.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum morador encontrado.");
                return CustomResponse();
            }

            return morador.ToList();
        }

        [HttpGet("moradores-por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<MoradorFlat>>> ObterMoradoresPorCondominioId(Guid condominioId)
        {
            var morador = await _usuarioQuery.ObterMoradoresPorCondominioId(condominioId);
            if (morador.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum morador encontrado.");
                return CustomResponse();
            }

            return morador.ToList();
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

            var unidade = await _principalQuery.ObterUnidadePorId(vincularViewModel.UnidadeId);
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

        [HttpPost("registrar-dispositivo")]
        public async Task<ActionResult> PostRegistrarDispositivo(CadastraMobileMoradorViewModel mobileVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var registrarComando = new RegistrarMoradorMobileCommand
                (mobileVM.DeviceKey, mobileVM.MobileId, mobileVM.Modelo, mobileVM.Plataforma,
                mobileVM.Versao, mobileVM.MoradorId);

            var result = await _mediatorHandler.EnviarComando(registrarComando);
            return CustomResponse(result);

        }


        [HttpPut("marcar-como-unidadePrincipal/{moradorId:Guid}")]
        public async Task<ActionResult> Post(Guid moradorId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);            

            var comando = new MarcarComoUnidadePrincipalCommand(moradorId);

            var resultado = await _mediatorHandler.EnviarComando(comando);

            if (!resultado.IsValid)
                CustomResponse(resultado);


            return CustomResponse();

        }


        [HttpPut("marcar-como-proprietario/{moradorId:Guid}")]
        public async Task<ActionResult> PostMarcarComoProprietario(Guid moradorId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new MarcarComoProprietarioCommand(moradorId);

            var resultado = await _mediatorHandler.EnviarComando(comando);

            if (!resultado.IsValid)
                CustomResponse(resultado);


            return CustomResponse();
        }


        [HttpPut("desmarcar-como-proprietario/{moradorId:Guid}")]
        public async Task<ActionResult> PostDesmarcarComoProprietario(Guid moradorId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new DesmarcarComoProprietarioCommand(moradorId);

            var resultado = await _mediatorHandler.EnviarComando(comando);

            if (!resultado.IsValid)
                CustomResponse(resultado);


            return CustomResponse();
        }


        [HttpDelete("{moradorId:Guid}")]
        public async Task<ActionResult> DeleteRemoverMorador(Guid moradorId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
           
            var comando = new RemoverMoradorCommand(moradorId);

            var resultado = await _mediatorHandler.EnviarComando(comando);

            if (!resultado.IsValid)
                CustomResponse(resultado);


            return CustomResponse();
        }

    }
}