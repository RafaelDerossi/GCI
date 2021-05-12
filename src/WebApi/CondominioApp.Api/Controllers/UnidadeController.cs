using AutoMapper;
using CondominioApp.Core.Mediator;
using CondominioApp.Principal.Aplication.Commands;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Principal.Aplication.ViewModels;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;
using CondominioApp.Usuarios.App.Aplication.Query;

namespace CondominioApp.Api.Controllers
{
    [Route("api/unidade")]
    public class UnidadeController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IPrincipalQuery _principalQuery;
        private readonly IUsuarioQuery _usuarioQuery;

        public UnidadeController
            (IMapper mapper, IMediatorHandler mediatorHandler, IPrincipalQuery principalQuery, IUsuarioQuery usuarioQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _principalQuery = principalQuery;
            _usuarioQuery = usuarioQuery;
        }



        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<UnidadeFlatViewModel>> ObterUnidadePorId(Guid id)
        {
            var unidade = await _principalQuery.ObterUnidadePorId(id);
            if (unidade == null)
            {
                AdicionarErroProcessamento("Unidade não encontrada.");
                return CustomResponse();
            }

            var unidadeViewModel = _mapper.Map<UnidadeFlatViewModel>(unidade);
            unidadeViewModel.Moradores = new List<MoradorFlatViewModel>();
            unidadeViewModel.Veiculos = new List<VeiculoFlatViewModel>();

            var moradores = await _usuarioQuery.ObterMoradoresPorUnidadeId(unidade.Id);
            if (moradores != null)
            {
                foreach (var morador in moradores)
                {
                    unidadeViewModel.Moradores.Add(_mapper.Map<MoradorFlatViewModel>(morador));
                }
            }

            var veiculos = await _usuarioQuery.ObterVeiculosPorUnidade(unidade.Id);
            if (veiculos != null)
            {
                foreach (var veiculo in veiculos)
                {
                    unidadeViewModel.Veiculos.Add(_mapper.Map<VeiculoFlatViewModel>(veiculo));
                }
            }

            return unidadeViewModel;
        }

        [HttpGet("por-grupo/{grupoId:Guid}")]
        public async Task<ActionResult<IEnumerable<UnidadeFlat>>> ObterUnidadesPorGrupo(Guid grupoId)
        {            
            var unidades = await _principalQuery.ObterUnidadesPorGrupo(grupoId);
            if (unidades.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }
            return unidades.ToList();
        }

        [HttpGet("por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<UnidadeFlat>>> ObterUnidadesPorCondominio(Guid condominioId)
        {            
            var unidades = await _principalQuery.ObterUnidadesPorCondominio(condominioId);
            if (unidades.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }
            return unidades.ToList();
        }

        [HttpGet("por-codigo/{codigo}")]
        public async Task<ActionResult<UnidadeFlat>> ObterUnidadesPorCodigo(string codigo)
        {
            var unidade = await _principalQuery.ObterUnidadePorCodigo(codigo);
            if (unidade == null)
            {
                AdicionarErroProcessamento("Unidade não encontrada.");
                return CustomResponse();
            }
            return unidade;
        }




        [HttpPost]
        public async Task<ActionResult> Post(CadastraUnidadeViewModel unidadeVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
                        
            for (int i = unidadeVM.NumeroInicial; i <= unidadeVM.NumeroFinal; i++)
            {
                var comando = new CadastrarUnidadeCommand(
                 unidadeVM.Codigo, i.ToString(), unidadeVM.Andar,
                 unidadeVM.Vagas, unidadeVM.Telefone, unidadeVM.Ramal,
                 unidadeVM.Complemento, unidadeVM.GrupoId);

                var resultado = await _mediatorHandler.EnviarComando(comando);

                if (!resultado.IsValid)
                    CustomResponse(resultado);
            }            

            return CustomResponse();
            
        }



        [HttpPut("{Id:Guid}")]
        public async Task<ActionResult> Put(Guid Id, EditaUnidadeViewModel unidadeVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (Id != unidadeVM.Id)
            {
                AdicionarErroProcessamento("Id não confere!");
                return CustomResponse();
            }

            var comando = new EditarUnidadeCommand(
            unidadeVM.Id, unidadeVM.Numero, unidadeVM.Andar,
            unidadeVM.Vagas, unidadeVM.Telefone, unidadeVM.Ramal, unidadeVM.Complemento);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }


        [HttpPut("atualizar-codigo/{Id:Guid}")]
        public async Task<ActionResult> PutAtualizarCodigo(Guid Id)
        {
            var comando = new ResetCodigoUnidadeCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("atualizar-vagas")]
        public async Task<ActionResult> PutAtualizarVagas(EditaVagaDeUnidadeViewModel viewModel)
        {
            var comando = new EditarVagasDaUnidadeCommand(viewModel.Id, viewModel.Vagas);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpDelete("{Id:Guid}")]
        public async Task<ActionResult> DeleteUnidade(Guid Id)
        {
            var comando = new ApagarUnidadeCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

    }
}