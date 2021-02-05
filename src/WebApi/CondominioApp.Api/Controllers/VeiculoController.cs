using CondominioApp.Core.Mediator;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Usuarios.App.Aplication.Commands;
using CondominioApp.Usuarios.App.Models;
using CondominioApp.WebApi.Core.Controllers;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("/api/veiculo")]
    public class VeiculoController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ICondominioQuery _condominioQuery;

        public VeiculoController(IMediatorHandler mediatorHandler, ICondominioQuery condominioQuery)
        {
            _mediatorHandler = mediatorHandler;
            _condominioQuery = condominioQuery;
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
    }
}