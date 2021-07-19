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
        private readonly IReservaAreaComumQuery _reservaAreaComumQuery;
        private readonly IPrincipalQuery _principalQuery;
        private readonly IAzureStorageService _azureStorageService;

        public AreaComumController(IMediatorHandler mediatorHandler, IMapper mapper,
                                   IReservaAreaComumQuery areaComumQuery, IPrincipalQuery principalQuery,
                                   IAzureStorageService azureStorageService)
        {
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
            _reservaAreaComumQuery = areaComumQuery;
            _principalQuery = principalQuery;
            _azureStorageService = azureStorageService;
        }


        /// <summary>
        /// Retorna uma área comum
        /// </summary>
        /// <param name="id">Id(Guid) da área comum</param>
        /// <returns></returns>
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<AreaComumFlat>> ObterPorId(Guid id)
        {
            var areaComum = await _reservaAreaComumQuery.ObterPorId(id);
            if (areaComum == null)
            {
                AdicionarErroProcessamento("Área Comum não encontrada.");
                return CustomResponse();
            }
            return areaComum;
        }

        /// <summary>
        /// Retorna as áreas comuns do condomínio
        /// </summary>
        /// <param name="condominioId">Id(Guid) do condomínio</param>
        /// <returns></returns>
        [HttpGet("por-condominio/{condominioId:Guid}")]
        public async Task<ActionResult<IEnumerable<AreaComumFlat>>> ObterPorCondominio(Guid condominioId)
        {
            var areasComuns = await _reservaAreaComumQuery.ObterPorCondominio(condominioId);
            if (areasComuns.Count() == 0)
            {
                AdicionarErroProcessamento("Nenhum registro encontrado.");
                return CustomResponse();
            }
            return areasComuns.ToList();
        }


        /// <summary>
        /// Cadastra uma área comum
        /// </summary>
        /// <param name="areaComumVM">
        /// Nome                                     :Nome da Área Comum (200 caracteres);   
        /// Descricao                                :Breve descrição da área comum (200 caracteres);   
        /// TermoDeUso                               :Texto do termo de uso (500 caracteres);   
        /// CondominioId                             :Id(Guid) do condomínio da área comum;   
        /// Capacidade                               :Capacidade de pessoas da área comum;   
        /// DiasPermitidos:                          :Dias da semana(em inglês separados por |) em que o uso da área comum é permitido (200 caracteres);   
        /// AntecedenciaMaximaEmMeses:               :Antecedência máxima em meses em que uma reserva pode ser feita nesta área comum;   
        /// AntecedenciaMaximaEmDias:                :Antecedência máxima em dias em que uma reserva pode ser feita nesta área comum;   
        /// AntecedenciaMinimaEmDias:                :Antecedência mínima em dias em que uma reserva pode ser feita nesta área comum;   
        /// AntecedenciaMinimaParaCancelamentoEmDias :Antecedência mínima em dias em que uma reserva pode ser cancelada nesta área comum;   
        /// RequerAprovacaoDeReserva                 :Informa se as reservas vão ser aprovadas automáticamente ou vão precisar da aprovação da adminitração;   
        /// TemHorariosEspecificos                   :Informa se a área comum tem horarios fixos para as reservas ou se é horário livre;   
        /// TempoDeIntervaloEntreReservas            :Informa o tempo de intervalo entre as reservas no formato "00:00"(hora:minuto) para quando a área tiver horário livre;   
        /// Ativa                                    :Informa se a área comum esta ativa(podendo fazer reservas) ou não;   
        /// TempoDeDuracaoDeReserva                  :Informa o tempo máximo de duração de uma reserva para quando a área tiver horário livre;    
        /// NumeroLimiteDeReservaPorUnidade          :Quantidade limite de reservas que uma unidade pode fazer por dia;   
        /// PermiteReservaSobreposta                 :Informa se a área comum permite realizar mais de uma reserva para o mesmo dia e horário;   
        /// NumeroLimiteDeReservaSobreposta          :Quantidade limite de reservas que podem ser realizadas no mesmo dia e horário;   
        /// NumeroLimiteDeReservaSobrepostaPorUnidade:Quantidade limite de reservas que uma unidade pode realizar no mesmo dia e horário limitado ao "NumeroLimiteDeReservaSobreposta" e ao "NumeroLimiteDeReservaPorUnidade";   
        /// TempoDeIntervaloEntreReservasPorUnidade  :Determina o tempo mínimo de intervalo entre reservas de uma unidade, no formato "00:00"(hora:minuto);   
        /// DataInicioBloqueio                       :Data de inicio do bloqueio para reservas da área comum.(Opcional);   
        /// DataFimBloqueio                          :Data de fim do bloqueio para reservas da área comum.(Opcional);   
        /// ArquivoAnexo                             :Arquivo anexo da área comum. (será realizado o upload para o storage)(.pdf, .xlsx, .jpg, .png, .jpeg);   
        /// Periodos                                 :Lista de períodos permitidos para reservar e seus valores.(Ex: HoraInicio:"00:00"; HoraFim:"00:00"; Valor:100,00.);   
        /// ArquivosDasFotos                         :Lista de arquivos das fotos da área comum.(será realizado o upload para o storage de cada arquivo)(.jpg, .png, .jpeg)
        /// </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post(AdicionaAreaComumViewModel areaComumVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var condominio = await _principalQuery.ObterPorId(areaComumVM.CondominioId);
            if (condominio == null)
            {
                AdicionarErroProcessamento("Condomínio não encontrado!");
                return CustomResponse();
            }


            var comando = AdicionarAreaComumCommandFactory(areaComumVM, condominio);

            if (areaComumVM.ArquivoAnexo != null && comando.EstaValido())
            {
                var retorno = await _azureStorageService.SubirArquivo
                              (areaComumVM.ArquivoAnexo,
                               comando.NomeArquivoAnexo.NomeDoArquivo,
                               comando.CondominioId.ToString());

                if (!retorno.IsValid)
                {
                    AdicionarErroProcessamento("Falha ao carregar arquivo anexo!");
                    return CustomResponse();
                }
            }

            var resultado = await _mediatorHandler.EnviarComando(comando);
            if (!resultado.IsValid)
                return CustomResponse(resultado);

            if (areaComumVM.ArquivosDasFotos != null)
            {
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
            }           

            return CustomResponse(resultado);
        }

        /// <summary>
        /// Cadastrar ou Trocar o arquivo anexo da área comum
        /// </summary>
        /// <param name="arquivo">Arquivo(será realizado o upload para o storage)</param>
        /// <param name="areaComumId">Id(Guid) da área comum</param>
        /// <returns></returns>
        [HttpPut("atualiza-arquivo-anexo")]
        public async Task<ActionResult> PutAtualizarArquivoAnexo(IFormFile arquivo, Guid areaComumId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var areaComum = await _reservaAreaComumQuery.ObterPorId(areaComumId);
            if (areaComum == null)
            {
                AdicionarErroProcessamento("Área Comum não encontrada!");
                return CustomResponse();
            }

            var nomeOriginalArquivo = StorageHelper.ObterNomeDoArquivo(arquivo);

            var comando = new AtualizarArquivoAnexoDaAreaComumCommand(areaComumId, nomeOriginalArquivo);

            if (comando.EstaValido())
            {
                var retorno = await _azureStorageService.SubirArquivo
                              (arquivo,
                               comando.NomeArquivoAnexo.NomeDoArquivo,
                               areaComum.CondominioId.ToString());

                if (!retorno.IsValid)
                {
                    AdicionarErroProcessamento("Falha ao carregar arquivo anexo!");
                    return CustomResponse();
                }
            }

            var resultado = await _mediatorHandler.EnviarComando(comando);            

            return CustomResponse(resultado);
        }

        /// <summary>
        /// Atualiza a área comum
        /// </summary>
        /// <param name="areaComumVM">
        /// Id                                       :Id(Guid) da área comum a ser atualizada;      
        /// Nome                                     :Nome da Área Comum (200 caracteres);   
        /// Descricao                                :Breve descrição da área comum (200 caracteres);   
        /// TermoDeUso                               :Texto do termo de uso (500 caracteres);           
        /// Capacidade                               :Capacidade de pessoas da área comum;   
        /// DiasPermitidos:                          :Dias da semana(em inglês separados por |) em que o uso da área comum é permitido (200 caracteres);   
        /// AntecedenciaMaximaEmMeses:               :Antecedência máxima em meses em que uma reserva pode ser feita nesta área comum;   
        /// AntecedenciaMaximaEmDias:                :Antecedência máxima em dias em que uma reserva pode ser feita nesta área comum;   
        /// AntecedenciaMinimaEmDias:                :Antecedência mínima em dias em que uma reserva pode ser feita nesta área comum;   
        /// AntecedenciaMinimaParaCancelamentoEmDias :Antecedência mínima em dias em que uma reserva pode ser cancelada nesta área comum;   
        /// RequerAprovacaoDeReserva                 :Informa se as reservas vão ser aprovadas automáticamente ou vão precisar da aprovação da adminitração;   
        /// TemHorariosEspecificos                   :Informa se a área comum tem horarios fixos para as reservas ou se é horário livre;   
        /// TempoDeIntervaloEntreReservas            :Informa o tempo de intervalo entre as reservas no formato "00:00"(hora:minuto) para quando a área tiver horário livre;           
        /// TempoDeDuracaoDeReserva                  :Informa o tempo máximo de duração de uma reserva para quando a área tiver horário livre;    
        /// NumeroLimiteDeReservaPorUnidade          :Quantidade limite de reservas que uma unidade pode fazer por dia;   
        /// PermiteReservaSobreposta                 :Informa se a área comum permite realizar mais de uma reserva para o mesmo dia e horário;   
        /// NumeroLimiteDeReservaSobreposta          :Quantidade limite de reservas que podem ser realizadas no mesmo dia e horário;   
        /// NumeroLimiteDeReservaSobrepostaPorUnidade:Quantidade limite de reservas que uma unidade pode realizar no mesmo dia e horário limitado ao "NumeroLimiteDeReservaSobreposta" e ao "NumeroLimiteDeReservaPorUnidade";   
        /// TempoDeIntervaloEntreReservasPorUnidade  :Determina o tempo mínimo de intervalo entre reservas de uma unidade, no formato "00:00"(hora:minuto);   
        /// DataInicioBloqueio                       :Data de inicio do bloqueio para reservas da área comum.(Opcional);   
        /// DataFimBloqueio                          :Data de fim do bloqueio para reservas da área comum.(Opcional);           
        /// Periodos                                 :Lista de períodos permitidos para reservar e seus valores.(Ex: HoraInicio:"00:00"; HoraFim:"00:00"; Valor:100,00.);   
        /// </param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put(AtualizaAreaComumViewModel areaComumVM)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = AtualizarAreaComumCommandFactory(areaComumVM);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        /// <summary>
        /// Remove o arquivo anexo de uma área comum
        /// </summary>
        /// <param name="Id">Id(Guid) da área comum</param>
        /// <returns></returns>
        [HttpDelete("remover-arquivo-anexo/{Id:Guid}")]
        public async Task<ActionResult> DeleteArquivoAnexo(Guid Id)
        {
            var comando = new RemoverArquivoAnexoDaAreaComumCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        /// <summary>
        /// Envia uma área comum para a lixeira
        /// </summary>
        /// <param name="Id">Id(Guid) da área comum</param>
        /// <returns></returns>
        [HttpDelete("{Id:Guid}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            var comando = new ApagarAreaComumCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        /// <summary>
        /// Habilita uma área comum para que reservas possam ser feitas
        /// </summary>
        /// <param name="Id">Id(Guid) da área comum</param>
        /// <returns></returns>
        [HttpPut("ativar/{Id:Guid}")]
        public async Task<ActionResult> AtivarAreaComum(Guid Id)
        {
            var comando = new AtivarAreaComumCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }

        /// <summary>
        /// Desabilita uma área comum para que reservas não possam ser feitas
        /// </summary>
        /// <param name="Id">Id(Guid) da área comum</param>
        /// <returns></returns>
        [HttpPut("desativar/{Id:Guid}")]
        public async Task<ActionResult> DesativarAreaComum(Guid Id)
        {
            var comando = new DesativarAreaComumCommand(Id);

            var Resultado = await _mediatorHandler.EnviarComando(comando);

            return CustomResponse(Resultado);
        }



        /// <summary>
        /// Retorna as fotos de uma área comum
        /// </summary>
        /// <param name="areaComumId">Id(Guid) da área comum</param>
        /// <returns></returns>
        [HttpGet("obter-fotos-da-area-comum/{areaComumId:Guid}")]
        public async Task<ActionResult<IEnumerable<FotoDaAreaViewModel>>> ObterFotosPorAreaComum(Guid areaComumId)
        {
            var fotos = await _reservaAreaComumQuery.ObterFotosDaAreaComum(areaComumId);
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

        /// <summary>
        /// Cadastra uma foto na área comum
        /// </summary>
        /// <param name="arquivo">Arquivo da foto(será realizado o upload para o storage)</param>
        /// <param name="areaComumId">Id(Guid) da área comum</param>
        /// <returns></returns>
        [HttpPost("foto-area-comum")]
        public async Task<ActionResult> PostFotoAreaComum(IFormFile arquivo, Guid areaComumId)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var areaComum = await _reservaAreaComumQuery.ObterPorId(areaComumId);
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
                               areaComum.CondominioId.ToString());

                if (!retorno.IsValid)
                {
                    AdicionarErroProcessamento("Falha ao carregar foto!");
                    return CustomResponse();
                }
            }

            var resultado = await _mediatorHandler.EnviarComando(comando);                       

            return CustomResponse(resultado);
        }

        /// <summary>
        /// Exclui uma foto de uma área comum
        /// </summary>
        /// <param name="Id">Id(Guid) da foto a ser excluída</param>
        /// <returns></returns>
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

            var nomeOriginalArquivo = StorageHelper.ObterNomeDoArquivo(areaComumVM.ArquivoAnexo);

            return new AdicionarAreaComumCommand(
                 areaComumVM.Nome, areaComumVM.Descricao, areaComumVM.TermoDeUso, condominio.Id,
                 condominio.Nome, areaComumVM.Capacidade, areaComumVM.DiasPermitidos,
                 areaComumVM.AntecedenciaMaximaEmMeses, areaComumVM.AntecedenciaMaximaEmDias,
                 areaComumVM.AntecedenciaMinimaEmDias, areaComumVM.AntecedenciaMinimaParaCancelamentoEmDias,
                 areaComumVM.RequerAprovacaoDeReserva, areaComumVM.TemHorariosEspecificos,
                 areaComumVM.TempoDeIntervaloEntreReservas, areaComumVM.Ativa, areaComumVM.TempoDeDuracaoDeReserva,
                 areaComumVM.NumeroLimiteDeReservaPorUnidade, areaComumVM.PermiteReservaSobreposta,
                 areaComumVM.NumeroLimiteDeReservaSobreposta, areaComumVM.NumeroLimiteDeReservaSobrepostaPorUnidade,
                 areaComumVM.TempoDeIntervaloEntreReservasPorUnidade,  areaComumVM.DataInicioBloqueio, 
                 areaComumVM.DataFimBloqueio, nomeOriginalArquivo, listaPeriodos);
        }

        private AdicionarFotoDeAreaComumCommand AdicionarFotoDeAreaComumCommandFactory(Guid condominioId, Guid areaComumId, IFormFile arquivo)
        {
            var nomeOriginalArquivo = StorageHelper.ObterNomeDoArquivo(arquivo);
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
                  areaComumVM.TempoDeIntervaloEntreReservasPorUnidade, areaComumVM.DataInicioBloqueio,
                  areaComumVM.DataFimBloqueio, listaPeriodos);
        }
    }
}
