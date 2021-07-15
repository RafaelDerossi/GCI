using AutoMapper;
using CondominioApp.ArquivoDigital.AzureStorageBlob.Services;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Mediator;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Principal.Domain.FlatModel;
using CondominioApp.ReservaAreaComum.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Aplication.ViewModels;
using CondominioApp.ReservaAreaComum.App.Aplication.Query;
using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Domain.FlatModel;
using CondominioApp.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioApp.Api.Controllers
{
    [Route("api/areacomum")]
    public class AreaComumController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;
        private readonly IReservaAreaComumQuery _areaComumQuery;
        private readonly IPrincipalQuery _principalQuery;
        private readonly IAzureStorageService _azureStorageService;

        public AreaComumController(IMediatorHandler mediatorHandler, IMapper mapper,
                                   IReservaAreaComumQuery areaComumQuery, IPrincipalQuery principalQuery,
                                   IAzureStorageService azureStorageService)
        {
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
            _areaComumQuery = areaComumQuery;
            _principalQuery = principalQuery;
            _azureStorageService = azureStorageService;
        }



        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<AreaComumFlat>> ObterPorId(Guid id)
        {
            var areaComum = await _areaComumQuery.ObterPorId(id);
            if (areaComum == null)
            {
                AdicionarErroProcessamento("Área Comum não encontrada.");
                return CustomResponse();
            }
            return areaComum;
        }

        [HttpGet("por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<AreaComumFlat>>> ObterPorCondominio(Guid condominioId)
        {
            var areasComuns = await _areaComumQuery.ObterPorCondominio(condominioId);
            if (areasComuns.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }
            return areasComuns.ToList();
        }



        [HttpPost]
        public async Task<ActionResult> Post([FromForm]AdicionaAreaComumViewModel areaComumVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var condominio = await _principalQuery.ObterPorId(areaComumVM.CondominioId);
            if (condominio == null)
            {
                AdicionarErroProcessamento("Condomínio não encontrado!");
                return CustomResponse();
            }

            var comando = AdicionarAreaComumCommandFactory(areaComumVM, condominio);

            var resultado = await _mediatorHandler.EnviarComando(comando);
            if (!resultado.IsValid)
                return CustomResponse(resultado);


            foreach (var arquivoDefoto in areaComumVM.ArquivosDasFotos)
            {
                var comandoAddFoto = AdicionarFotoDeAreaComumCommandFactory(comando.CondominioId, comando.Id, arquivoDefoto);
                if (comandoAddFoto.EstaValido())
                {
                    var retorno = await _azureStorageService.SubirArquivo
                                  (arquivoDefoto,
                                   comandoAddFoto.Foto.NomeDoArquivo,
                                   comandoAddFoto.CondominioId.ToString());

                    if (!retorno.IsValid)
                    {
                        AdicionarErroProcessamento("Falha ao carregar foto!");
                        return CustomResponse();
                    }
                }

                var resultadoAddFoto = await _mediatorHandler.EnviarComando(comandoAddFoto);
                if (!resultadoAddFoto.IsValid)
                    return CustomResponse(resultadoAddFoto);
            }           

            return CustomResponse(resultado);
        }

        [HttpPut]
        public async Task<ActionResult> Put(AtualizaAreaComumViewModel areaComumVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = AtualizarAreaComumCommandFactory(areaComumVM);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpDelete("{Id:Guid}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            var comando = new ApagarAreaComumCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }


        [HttpPut("ativar/{Id:Guid}")]
        public async Task<ActionResult> AtivarAreaComum(Guid Id)
        {
            var comando = new AtivarAreaComumCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        [HttpPut("desativar/{Id:Guid}")]
        public async Task<ActionResult> DesativarAreaComum(Guid Id)
        {
            var comando = new DesativarAreaComumCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }




        [HttpGet("obter-fotos-da-area-comum/{areaComumId:Guid}")]
        public async Task<ActionResult<IEnumerable<FotoDaAreaViewModel>>> ObterFotosPorAreaComum(Guid areaComumId)
        {
            var fotos = await _areaComumQuery.ObterFotosDaAreaComum(areaComumId);
            if (fotos.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }

            var fotosViewModel = new List<FotoDaAreaViewModel>();
            foreach (var item in fotos)
            {
                var fotoViewModel = new FotoDaAreaViewModel(item);
                fotosViewModel.Add(fotoViewModel);
            }

            return fotosViewModel.ToList();
        }


        [HttpPost("foto-area-comum")]
        public async Task<ActionResult> PostFotoAreaComum([FromForm] IFormFile arquivo, Guid areaComumId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var areaComum = await _areaComumQuery.ObterPorId(areaComumId);
            if (areaComum == null)
            {
                AdicionarErroProcessamento("Área comum não encontrada!");
                return CustomResponse();
            }

            var comando = AdicionarFotoDeAreaComumCommandFactory(areaComum.CondominioId, areaComum.Id, arquivo);

            if (comando.EstaValido())
            {
                var retorno = await _azureStorageService.SubirArquivo
                              (arquivo,
                               comando.Foto.NomeDoArquivo,
                               comando.CondominioId.ToString());

                if (!retorno.IsValid)
                {
                    AdicionarErroProcessamento("Falha ao carregar foto!");
                    return CustomResponse();
                }
            }

            var resultado = await _mediatorHandler.EnviarComando(comando);                       

            return CustomResponse(resultado);
        }
        

        [HttpDelete("foto-area-comum/{Id:Guid}")]
        public async Task<ActionResult> DeleteFotoAreaComum(Guid Id)
        {
            var comando = new RemoverFotoDaAreaComumCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }       

       



        private AdicionarAreaComumCommand AdicionarAreaComumCommandFactory(AdicionaAreaComumViewModel areaComumVM, CondominioFlat condominio)
        {
            var listaPeriodos = new List<Periodo>();
            if (areaComumVM.Periodos != null)
            {
                foreach (PeriodoViewModel periodoVM in areaComumVM.Periodos)
                {
                    var periodo = _mapper.Map<Periodo>(periodoVM);                   
                    listaPeriodos.Add(periodo);
                }
            }           

            return new AdicionarAreaComumCommand(
                 areaComumVM.Nome, areaComumVM.Descricao, areaComumVM.TermoDeUso, condominio.Id,
                 condominio.Nome, areaComumVM.Capacidade, areaComumVM.DiasPermitidos,
                 areaComumVM.AntecedenciaMaximaEmMeses, areaComumVM.AntecedenciaMaximaEmDias,
                 areaComumVM.AntecedenciaMinimaEmDias, areaComumVM.AntecedenciaMinimaParaCancelamentoEmDias,
                 areaComumVM.RequerAprovacaoDeReserva, areaComumVM.TemHorariosEspecificos,
                 areaComumVM.TempoDeIntervaloEntreReservas, areaComumVM.Ativa, areaComumVM.TempoDeDuracaoDeReserva,
                 areaComumVM.NumeroLimiteDeReservaPorUnidade, areaComumVM.PermiteReservaSobreposta,
                 areaComumVM.NumeroLimiteDeReservaSobreposta, areaComumVM.NumeroLimiteDeReservaSobrepostaPorUnidade,
                 areaComumVM.TempoDeIntervaloEntreReservasPorUnidade, listaPeriodos);
        }

        private AdicionarFotoDeAreaComumCommand AdicionarFotoDeAreaComumCommandFactory(Guid condominioId, Guid areaComumId, IFormFile arquivo)
        {
            var nomeOriginalArquivo = StoragePaths.ObterNomeDoArquivo(arquivo);
            return new AdicionarFotoDeAreaComumCommand(areaComumId, condominioId, nomeOriginalArquivo);
        }

        private AtualizarAreaComumCommand AtualizarAreaComumCommandFactory(AtualizaAreaComumViewModel areaComumVM)
        {
            var listaPeriodos = new List<Periodo>();
            if (areaComumVM.Periodos != null)
            {
                foreach (PeriodoViewModel periodoVM in areaComumVM.Periodos)
                {
                    var periodo = _mapper.Map<Periodo>(periodoVM);                   
                    listaPeriodos.Add(periodo);
                }
            }
            return new AtualizarAreaComumCommand(
                  areaComumVM.Id, areaComumVM.Nome, areaComumVM.Descricao, areaComumVM.TermoDeUso, 
                  areaComumVM.Capacidade, areaComumVM.DiasPermitidos, areaComumVM.AntecedenciaMaximaEmMeses,
                  areaComumVM.AntecedenciaMaximaEmDias, areaComumVM.AntecedenciaMinimaEmDias, 
                  areaComumVM.AntecedenciaMinimaParaCancelamentoEmDias,
                  areaComumVM.RequerAprovacaoDeReserva, areaComumVM.TemHorariosEspecificos,
                  areaComumVM.TempoDeIntervaloEntreReservas, areaComumVM.TempoDeDuracaoDeReserva,
                  areaComumVM.NumeroLimiteDeReservaPorUnidade, areaComumVM.PermiteReservaSobreposta,
                  areaComumVM.NumeroLimiteDeReservaSobreposta, areaComumVM.NumeroLimiteDeReservaSobrepostaPorUnidade,
                  areaComumVM.TempoDeIntervaloEntreReservasPorUnidade, listaPeriodos);
        }
    }
}
