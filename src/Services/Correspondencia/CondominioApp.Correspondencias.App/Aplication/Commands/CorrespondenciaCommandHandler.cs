using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Messages;
using CondominioApp.Correspondencias.App.DTO;
using CondominioApp.Correspondencias.App.Models;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Correspondencias.App.Aplication.Commands
{
    public class CorrespondenciaCommandHandler : CommandHandler,
         IRequestHandler<CadastrarCorrespondenciaCommand, ValidationResult>,
         IRequestHandler<MarcarCorrespondenciaVistaCommand, ValidationResult>,
         IRequestHandler<MarcarCorrespondenciaRetiradaCommand, ValidationResult>,
         IRequestHandler<MarcarCorrespondenciaDevolvidaCommand, ValidationResult>,
         IRequestHandler<DispararAlertaDeCorrespondenciaCommand, ValidationResult>,
         IRequestHandler<RemoverCorrespondenciaCommand, ValidationResult>,
         IRequestHandler<GerarExcelCorrespondenciaCommand, ValidationResult>,
         IDisposable
    {

        private ICorrespondenciaRepository _CorrespondenciaRepository;

        public CorrespondenciaCommandHandler(ICorrespondenciaRepository correspondenciaRepository)
        {
            _CorrespondenciaRepository = correspondenciaRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarCorrespondenciaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var correspondencia = CorrespondenciaFactory(request);           

            _CorrespondenciaRepository.Adicionar(correspondencia);

            correspondencia.EnviarPushNovaCorrespondencia();

            return await PersistirDados(_CorrespondenciaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(MarcarCorrespondenciaVistaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var correspondenciaBd = await _CorrespondenciaRepository.ObterPorId(request.CorrespondenciaId);
            if (correspondenciaBd == null)
            {
                AdicionarErro("Correspondência não encontrada.");
                return ValidationResult;
            }

            correspondenciaBd.SetVisto();

            _CorrespondenciaRepository.Atualizar(correspondenciaBd);

            return await PersistirDados(_CorrespondenciaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(MarcarCorrespondenciaRetiradaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var correspondenciaBd = await _CorrespondenciaRepository.ObterPorId(request.CorrespondenciaId);
            if (correspondenciaBd == null)
            {
                AdicionarErro("Correspondência não encontrada.");
                return ValidationResult;
            }

            var retorno = correspondenciaBd.MarcarComRetirada
                (request.NomeRetirante, request.Observacao, request.FuncionarioId, request.NomeFuncionario);
            if (!retorno.IsValid)
                return retorno;

            correspondenciaBd.EnviarPushCorrespondenciaRetirada();

            _CorrespondenciaRepository.Atualizar(correspondenciaBd);

            return await PersistirDados(_CorrespondenciaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(MarcarCorrespondenciaDevolvidaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var correspondenciaBd = await _CorrespondenciaRepository.ObterPorId(request.CorrespondenciaId);
            if (correspondenciaBd == null)
            {
                AdicionarErro("Correspondência não encontrada.");
                return ValidationResult;
            }

            var retorno = correspondenciaBd.MarcarComDevolvida
               (request.Observacao, request.FuncionarioId, request.NomeFuncionario);
            if (!retorno.IsValid)
                return retorno;

            correspondenciaBd.EnviarPushCorrespondenciaDevolvida();

            return await PersistirDados(_CorrespondenciaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(DispararAlertaDeCorrespondenciaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var correspondenciaBd = await _CorrespondenciaRepository.ObterPorId(request.CorrespondenciaId);
            if (correspondenciaBd == null)
            {
                AdicionarErro("Correspondência não encontrada.");
                return ValidationResult;
            }
                       
           
            var retorno = correspondenciaBd.SomarAlerta();
            if (!retorno.IsValid)
                return retorno;

            correspondenciaBd.EnviarPushDeAlerta();

            _CorrespondenciaRepository.Atualizar(correspondenciaBd);

            return await PersistirDados(_CorrespondenciaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoverCorrespondenciaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var correspondenciaBd = await _CorrespondenciaRepository.ObterPorId(request.CorrespondenciaId);
            if (correspondenciaBd == null)
            {
                AdicionarErro("Correspondência não encontrada.");
                return ValidationResult;
            }

            correspondenciaBd.EnviarParaLixeira();

            _CorrespondenciaRepository.Atualizar(correspondenciaBd);

            return await PersistirDados(_CorrespondenciaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(GerarExcelCorrespondenciaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var listaCorrespondencias = new List<CorrespondenciaExcelDTO>();

            foreach (Guid correspondenciaId in request.ListaCorrespondenciaId)
            {                
                var correspondencia = await _CorrespondenciaRepository.ObterPorId(correspondenciaId);

                if (!correspondencia.Lixeira)
                {
                    var CorrespondenciaDTO = new CorrespondenciaExcelDTO
                    {
                        DataDaChegada = correspondencia.DataDeCadastroFormatada,
                        EntreguePor = correspondencia.NomeFuncionario,
                        DataDaRetirada = correspondencia.DataDaRetirada.ToString(),
                        RetiradoPor = correspondencia.NomeRetirante,
                        Observacao = correspondencia.Observacao
                    };
                    listaCorrespondencias.Add(CorrespondenciaDTO);
                }              
            }

            List<string> cabecalho = new List<string>();
            cabecalho.Add("Data da Chegada");
            cabecalho.Add("Data da Retirada");
            cabecalho.Add("Entregue por");           
            cabecalho.Add("Retirado por");
            cabecalho.Add("Observação");

            var geradorExcel = new GeradorDeExcel<CorrespondenciaExcelDTO>
                (cabecalho, listaCorrespondencias, request.NomeArquivo, "Relatório de Correspondência",
                request.CaminhoRaiz);
                        

            return geradorExcel.GerarExcel();
        }


        private Correspondencia CorrespondenciaFactory(CadastrarCorrespondenciaCommand request)
        {
            var correspondencia = new Correspondencia(
                request.CondominioId, request.UnidadeId, request.NumeroUnidade, request.Bloco, request.Visto, request.NomeRetirante,
                request.Observacao, request.DataDaRetirada, request.FuncionarioId, request.NomeFuncionario, request.Foto,
                request.NumeroRastreamentoCorreio, request.DataDeChegada, request.QuantidadeDeAlertasFeitos,
                request.TipoDeCorrespondencia, request.Status);

            return correspondencia;
        }


        public void Dispose()
        {
            _CorrespondenciaRepository?.Dispose();
        }


    }
}
