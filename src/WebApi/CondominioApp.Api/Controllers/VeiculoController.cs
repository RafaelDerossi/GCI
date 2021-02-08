using CondominioApp.Core.Mediator;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Usuarios.App.Aplication.Commands;
using CondominioApp.Usuarios.App.Aplication.Query;
using CondominioApp.Usuarios.App.FlatModel;
using CondominioApp.Usuarios.App.Models;
using CondominioApp.WebApi.Core.Controllers;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CondominioApp.Api.Controllers
{
    [Route("/api/veiculo")]
    public class VeiculoController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ICondominioQuery _condominioQuery;
        private readonly IUsuarioQuery _usuarioQuery;

        public VeiculoController(IMediatorHandler mediatorHandler, ICondominioQuery condominioQuery, IUsuarioQuery usuarioQuery)
        {
            _mediatorHandler = mediatorHandler;
            _condominioQuery = condominioQuery;
            _usuarioQuery = usuarioQuery;
        }



        [HttpGet("por-placa-e-condominio")]
        public async Task<ActionResult<VeiculoFlat>> ObterPorPlacaECondominio(string placa, Guid condominioId)
        {
            var veiculo = await _usuarioQuery.ObterVeiculoPorPlacaECondominio(placa, condominioId);
            if (veiculo == null)
            {
                AdicionarErroProcessamento("Veiculo não encontrado.");
                return CustomResponse();
            }
            return veiculo;
        }

        [HttpGet("por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<VeiculoFlat>>> ObterPorCondominio(Guid condominioId)
        {
            var veiculos = await _usuarioQuery.ObterVeiculosPorCondominio(condominioId);
            if (veiculos.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }
            return veiculos.ToList();
        }

        [HttpGet("por-usuario/{usuarioId:Guid}")]
        public async Task<ActionResult<IEnumerable<VeiculoFlat>>> ObterPorUsuario(Guid usuarioId)
        {
            var veiculos = await _usuarioQuery.ObterVeiculosPorUsuario(usuarioId);
            if (veiculos.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }
            return veiculos.ToList();
        }



        [HttpPost]
        public async Task<ActionResult> Post(CadastraVeiculoViewModel veiculoVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var unidade = await _condominioQuery.ObterUnidadePorId(veiculoVM.UnidadeId);
            if (unidade == null)
            {
                AdicionarErroProcessamento("Unidade não encontrada!");
                return CustomResponse();
            }

            var comando = new CadastrarVeiculoCommand(
                 veiculoVM.UsuarioId, veiculoVM.Placa, veiculoVM.Modelo, veiculoVM.Cor,
                 unidade.Id, unidade.Numero, unidade.Andar, unidade.GrupoDescricao,
                 unidade.CondominioId, unidade.CondominioNome);

             var resultado = await _mediatorHandler.EnviarComando(comando);

             if (!resultado.IsValid)
                CustomResponse(resultado);
           

            return CustomResponse();

        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid veiculoId, Guid condominioId)
        {
            var comando = new RemoverVeiculoCommand(veiculoId, condominioId);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

    }
}