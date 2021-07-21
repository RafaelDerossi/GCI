using AutoMapper;
using CondominioApp.Core.Mediator;
using CondominioApp.Portaria.Aplication.Commands;
using CondominioApp.Portaria.Aplication.ViewModels;
using CondominioApp.Portaria.Aplication.Query;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CondominioApp.Portaria.Domain.FlatModel;
using CondominioApp.Core.Enumeradores;
using System.Linq;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Usuarios.App.Aplication.Query;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.Usuarios.App.Models;
using CondominioApp.Usuarios.App.FlatModel;
using CondominioApp.Core.Helpers;
using CondominioApp.ArquivoDigital.AzureStorageBlob.Services;

namespace CondominioApp.Api.Controllers
{
    [Route("api/visita")]
    public class VisitaController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;      
        private readonly IPortariaQuery _portariaQuery;
        private readonly IPrincipalQuery _principalQuery;
        private readonly IUsuarioQuery _usuarioQuery;
        private readonly IAzureStorageService _azureStorageService;

        public VisitaController
            (IMediatorHandler mediatorHandler, IPortariaQuery portariaQuery,
             IPrincipalQuery principalQuery, IUsuarioQuery usuarioQuery,
             IAzureStorageService azureStorageService)
        {
            _mediatorHandler = mediatorHandler;           
            _portariaQuery = portariaQuery;
            _principalQuery = principalQuery;
            _usuarioQuery = usuarioQuery;
            _azureStorageService = azureStorageService;
        }


        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<VisitaFlat>> ObterPorId(Guid id)
        {
            var visita = await _portariaQuery.ObterVisitaPorId(id);
            if (visita == null)
            {
                AdicionarErroProcessamento("Visita não encontrada.");
                return CustomResponse();
            }
            return visita;
        }

        [HttpGet("por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<VisitaFlat>>> ObterPorCondominio(Guid condominioId)
        {
            var visitas = await _portariaQuery.ObterVisitasPorCondominio(condominioId);
            if (visitas.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }
            return visitas.ToList();
        }

        [HttpGet("por-unidade/{unidadeId:Guid}")]
        public async Task<ActionResult<IEnumerable<VisitaFlat>>> ObterPorUnidade(Guid unidadeId)
        {            
            var visitas = await _portariaQuery.ObterVisitasPorUnidade(unidadeId);
            if (visitas.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }
            return visitas.ToList();
        }

        [HttpGet("por-usuario/{usuarioId:Guid}")]
        public async Task<ActionResult<IEnumerable<VisitaFlat>>> ObterPorUsuario(Guid usuarioId)
        {            
            var visitas = await _portariaQuery.ObterVisitasPorUsuario(usuarioId);
            if (visitas.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }
            return visitas.ToList();
        }

        [HttpGet("por-condominio-e-placaOuModelo/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<VisitaFlat>>> ObterPorCondominioEPlacaOuModelo(Guid condominioId, string pesquisa)
        {
            var visitas = await _portariaQuery.ObterVisitasPorPlacaOuModeloDoVeiculo(pesquisa, condominioId);
            if (visitas.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }
            return visitas.ToList();
        }



        [HttpPost("por-morador")]
        public async Task<ActionResult> PostPorMorador(AdicionaVisitaMoradorViewModel visitaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var dias = (visitaVM.DataDeEntradaFim.Date - visitaVM.DataDeEntradaInicio.Date).Days + 1;

            var morador = await _usuarioQuery.ObterMoradorPorId(visitaVM.MoradorId);
            if (morador == null)
            {
                AdicionarErroProcessamento("Morador não encontrado!");
                return CustomResponse();
            }

            var unidade = await _principalQuery.ObterUnidadePorId(visitaVM.UnidadeId);
            if (unidade == null)
            {
                AdicionarErroProcessamento("Unidade não encontrada!");
                return CustomResponse();
            }

            for (int i = 0; i < dias; i++)
            {
                var cadastrarVisitaComando = 
                    AdicionarVisitaPorMoradorCommandFactory
                    (visitaVM, visitaVM.DataDeEntradaInicio.AddDays(i).Date, unidade, morador);

                var resultado = await _mediatorHandler.EnviarComando(cadastrarVisitaComando);

                if (!resultado.IsValid)
                    return CustomResponse(resultado);

            }            

            return CustomResponse();
        }

        [HttpPost("por-porteiro")]
        public async Task<ActionResult> PostPorPorteiro([FromForm]AdicionaVisitaPorteiroViewModel visitaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var morador = await _usuarioQuery.ObterMoradorPorId(visitaVM.MoradorId);
            if (morador == null)
            {
                AdicionarErroProcessamento("Morador não encontrado!");
                return CustomResponse();
            }

            var unidade = await _principalQuery.ObterUnidadePorId(visitaVM.UnidadeId);
            if (unidade == null)
            {
                AdicionarErroProcessamento("Unidade não encontrada!");
                return CustomResponse();
            }

            var funcionario = await _usuarioQuery.ObterFuncionarioPorId(visitaVM.FuncionarioId);
            if (funcionario == null)
            {
                AdicionarErroProcessamento("Morador não encontrado!");
                return CustomResponse();
            }

            if (visitaVM.VisitanteId == Guid.Empty)
            {
                visitaVM.VisitanteId = Guid.NewGuid();

                var cadastrarVisitanteComando = 
                    AdicionarVisitantePorPorteiroCommandFactory(visitaVM, unidade, funcionario);

                if (visitaVM.ArquivoFotoVisitante != null && cadastrarVisitanteComando.EstaValido())
                {
                    var retornoStorage = await _azureStorageService.SubirArquivo
                                  (visitaVM.ArquivoFotoVisitante,
                                   cadastrarVisitanteComando.Foto.NomeDoArquivo,
                                   unidade.CondominioId.ToString());

                    if (!retornoStorage.IsValid)
                    {                        
                        return CustomResponse(retornoStorage);
                    }
                }

                var retorno = await _mediatorHandler.EnviarComando(cadastrarVisitanteComando);
                if (!retorno.IsValid)
                    return CustomResponse(retorno);

                var comando = AdicionarVisitaPorPorteiroCommandFactory(visitaVM, unidade, morador);

                retorno = await _mediatorHandler.EnviarComando(comando);

                return CustomResponse(retorno);
            }
           

            var editarVisitanteComando = AtualizarVisitantePorPorteiroCommandFactory(visitaVM);

            if (visitaVM.ArquivoFotoVisitante != null && editarVisitanteComando.EstaValido())
            {
                var retornoStorage = await _azureStorageService.SubirArquivo
                              (visitaVM.ArquivoFotoVisitante,
                               editarVisitanteComando.Foto.NomeDoArquivo,
                               unidade.CondominioId.ToString());

                if (!retornoStorage.IsValid)
                {
                    return CustomResponse(retornoStorage);
                }
            }

            var result = await _mediatorHandler.EnviarComando(editarVisitanteComando);
            if (!result.IsValid)
                return CustomResponse(result);

            var cadastrarVisitaComando = AdicionarVisitaPorPorteiroCommandFactory(visitaVM, unidade, morador);
            result = await _mediatorHandler.EnviarComando(cadastrarVisitaComando);
          

            return CustomResponse(result);
        }


        [HttpPut]
        public async Task<ActionResult> Put(AtualizaVisitaViewModel visitaVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var morador = await _usuarioQuery.ObterMoradorPorId(visitaVM.MoradorId);
            if (morador == null)
            {
                AdicionarErroProcessamento("Morador não encontrado!");
                return CustomResponse();
            }

            var unidade = await _principalQuery.ObterUnidadePorId(visitaVM.MoradorId);
            if (unidade == null)
            {
                AdicionarErroProcessamento("Unidade não encontrada!");
                return CustomResponse();
            }

            var comando = AtualizarVisitaCommandFactory(visitaVM, unidade, morador);

            var resultado = await _mediatorHandler.EnviarComando(comando);

            if (!resultado.IsValid)
                return CustomResponse(resultado);


            var editarVisitanteComando = AtualizarVisitantePorPorteiroCommandFactory(visitaVM);

            resultado = await _mediatorHandler.EnviarComando(editarVisitanteComando);

            return CustomResponse(resultado);
        }


        [HttpDelete("{Id:Guid}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            var comando = new ApagarVisitaCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("aprovar/{Id:Guid}")]
        public async Task<ActionResult> PutAprovarVisita(Guid Id)
        {
            var comando = new AprovarVisitaCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("reprovar/{Id:Guid}")]
        public async Task<ActionResult> PutReprovarVisita(Guid Id)
        {
            var comando = new ReprovarVisitaCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("iniciar/{Id:Guid}")]
        public async Task<ActionResult> PutIniciarVisita(Guid Id)
        {
            var comando = new IniciarVisitaCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("terminar/{Id:Guid}")]
        public async Task<ActionResult> PutTerminarVisita(Guid Id)
        {
            var comando = new TerminarVisitaCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }



        private AdicionarVisitaPorPorteiroCommand AdicionarVisitaPorPorteiroCommandFactory
            (AdicionaVisitaPorteiroViewModel viewModel, UnidadeFlat unidade, MoradorFlat morador)
        {
            var nomeOriginalArquivo = StorageHelper.ObterNomeDoArquivo(viewModel.ArquivoFotoVisitante);

            return new AdicionarVisitaPorPorteiroCommand(
                  viewModel.Observacao, StatusVisita.PENDENTE, viewModel.VisitanteId,
                  viewModel.NomeVisitante, viewModel.TipoDoDocumento, viewModel.Documento, viewModel.EmailVisitante,
                  viewModel.NomeArquivoFotoVisitante, nomeOriginalArquivo, viewModel.TipoDeVisitante,
                  viewModel.NomeEmpresaVisitante, unidade.CondominioId, unidade.CondominioNome, unidade.Id,
                  unidade.Numero, unidade.Andar, unidade.GrupoDescricao, viewModel.TemVeiculo, viewModel.PlacaVeiculo, 
                  viewModel.ModeloVeiculo, viewModel.CorVeiculo, morador.Id, morador.NomeCompleto);
        }

        private AdicionarVisitaPorMoradorCommand AdicionarVisitaPorMoradorCommandFactory
            (AdicionaVisitaMoradorViewModel viewModel, DateTime dataDeEntrada, UnidadeFlat unidade, MoradorFlat morador)
        {
            return new AdicionarVisitaPorMoradorCommand(
                  dataDeEntrada, viewModel.Observacao, StatusVisita.APROVADA, viewModel.VisitanteId,
                  unidade.CondominioId, unidade.CondominioNome, unidade.Id, unidade.Numero,
                  unidade.Andar, unidade.GrupoDescricao, viewModel.TemVeiculo,viewModel.PlacaVeiculo,
                  viewModel.ModeloVeiculo,viewModel.CorVeiculo, morador.Id, morador.NomeCompleto);
        }

        private AtualizarVisitaCommand AtualizarVisitaCommandFactory(AtualizaVisitaViewModel viewModel, UnidadeFlat unidade, MoradorFlat morador)
        {
            var nomeOriginalArquivo = StorageHelper.ObterNomeDoArquivo(viewModel.ArquivoFotoVisitante);

            return new AtualizarVisitaCommand(
                   viewModel.Id,viewModel.Observacao, viewModel.NomeVisitante,viewModel.TipoDoDocumento, viewModel.Documento,
                   viewModel.EmailVisitante, viewModel.NomeArquivoFotoVisitante, nomeOriginalArquivo,
                   viewModel.TipoDeVisitante, viewModel.NomeEmpresaVisitante, unidade.Id, unidade.Numero,
                   unidade.Andar, unidade.GrupoDescricao, viewModel.TemVeiculo, viewModel.PlacaVeiculo,
                   viewModel.ModeloVeiculo, viewModel.CorVeiculo, morador.Id, morador.NomeCompleto);
        }




        private AdicionarVisitantePorPorteiroCommand AdicionarVisitantePorPorteiroCommandFactory
            (AdicionaVisitaPorteiroViewModel visitaVM, UnidadeFlat unidade, FuncionarioFlat funcionario)
        {
            var nomeOriginalArquivo = StorageHelper.ObterNomeDoArquivo(visitaVM.ArquivoFotoVisitante);

            return new AdicionarVisitantePorPorteiroCommand(
                  visitaVM.VisitanteId, visitaVM.NomeVisitante, visitaVM.TipoDoDocumento, visitaVM.Documento,
                  visitaVM.EmailVisitante, nomeOriginalArquivo, unidade.CondominioId, unidade.CondominioNome,
                  unidade.Id, unidade.Numero, unidade.Andar, unidade.GrupoDescricao, visitaVM.TipoDeVisitante,
                  visitaVM.NomeEmpresaVisitante, visitaVM.TemVeiculo, funcionario.Id, funcionario.NomeCompleto);
        }
       
        private AtualizarVisitantePorPorteiroCommand AtualizarVisitantePorPorteiroCommandFactory
            (AdicionaVisitaPorteiroViewModel visitaVM)
        {
            var nomeOriginalArquivo = StorageHelper.ObterNomeDoArquivo(visitaVM.ArquivoFotoVisitante);

            return new AtualizarVisitantePorPorteiroCommand(
                  visitaVM.VisitanteId, visitaVM.NomeVisitante,visitaVM.TipoDoDocumento, visitaVM.Documento,
                  visitaVM.EmailVisitante, visitaVM.NomeArquivoFotoVisitante, nomeOriginalArquivo, visitaVM.TipoDeVisitante,
                  visitaVM.NomeEmpresaVisitante, visitaVM.TemVeiculo);
        }

        private AtualizarVisitantePorPorteiroCommand AtualizarVisitantePorPorteiroCommandFactory
            (AtualizaVisitaViewModel visitaVM)
        {
            var nomeOriginalArquivo = StorageHelper.ObterNomeDoArquivo(visitaVM.ArquivoFotoVisitante);

            return new AtualizarVisitantePorPorteiroCommand(
                  visitaVM.VisitanteId, visitaVM.NomeVisitante, visitaVM.TipoDoDocumento, visitaVM.Documento,
                  visitaVM.EmailVisitante, visitaVM.NomeArquivoFotoVisitante, nomeOriginalArquivo,
                  visitaVM.TipoDeVisitante, visitaVM.NomeEmpresaVisitante, visitaVM.TemVeiculo);
        }

    }
}
