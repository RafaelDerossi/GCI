﻿using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Messages;
using CondominioApp.Correspondencias.Aplication.Events;
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
         IRequestHandler<AdicionarCorrespondenciaCommand, ValidationResult>,
         IRequestHandler<MarcarCorrespondenciaVistaCommand, ValidationResult>,
         IRequestHandler<MarcarCorrespondenciaRetiradaCommand, ValidationResult>,
         IRequestHandler<MarcarCorrespondenciaDevolvidaCommand, ValidationResult>,
         IRequestHandler<DispararAlertaDeCorrespondenciaCommand, ValidationResult>,
         IRequestHandler<ApagarCorrespondenciaCommand, ValidationResult>,
         IRequestHandler<GerarExcelCorrespondenciaCommand, ValidationResult>,
         IDisposable
    {

        private readonly ICorrespondenciaRepository _CorrespondenciaRepository;

        public CorrespondenciaCommandHandler(ICorrespondenciaRepository correspondenciaRepository)
        {
            _CorrespondenciaRepository = correspondenciaRepository;
        }


        public async Task<ValidationResult> Handle(AdicionarCorrespondenciaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var correspondencia = CorrespondenciaFactory(request);           

            _CorrespondenciaRepository.Adicionar(correspondencia);

            correspondencia.EnviarPush();
            correspondencia.EnviarEmail();

            correspondencia.AdicionarEvento(
                new RegistraHistoricoEvent(correspondencia.Id, AcoesCorrespondencia.CADASTRO,
                                           correspondencia.CadastradaPorId, correspondencia.CadastradaPorNome,
                                           false));

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

            correspondenciaBd.AdicionarEvento(new MarcarComoVistoEvent(correspondenciaBd.Id));

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
                (request.NomeRetirante, request.ObservacaoDaRetirada, request.EntreguePorId, 
                 request.EntreguePorNome, request.FotoRetirante);

            if (!retorno.IsValid)
                return retorno;


            correspondenciaBd.EnviarPush();
            correspondenciaBd.EnviarEmail();

            _CorrespondenciaRepository.Atualizar(correspondenciaBd);

            correspondenciaBd.AdicionarEvento(
                new RegistraHistoricoEvent(correspondenciaBd.Id, AcoesCorrespondencia.RETIRADA,
                                           correspondenciaBd.EntreguePorId, correspondenciaBd.EntreguePorNome,
                                           true));

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
               (request.Observacao, request.CadastradaPorId, request.CadastradaPorNome);
            if (!retorno.IsValid)
                return retorno;

            correspondenciaBd.EnviarPush();

            correspondenciaBd.EnviarEmail();

            _CorrespondenciaRepository.Atualizar(correspondenciaBd);

            correspondenciaBd.AdicionarEvento(
                new RegistraHistoricoEvent(correspondenciaBd.Id, AcoesCorrespondencia.DEVOLUCAO,
                                           correspondenciaBd.CadastradaPorId, correspondenciaBd.CadastradaPorNome,
                                           false));

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

            correspondenciaBd.AdicionarEvento(
                new RegistraHistoricoEvent(correspondenciaBd.Id, AcoesCorrespondencia.NOTIFICACAO,
                                           correspondenciaBd.CadastradaPorId, correspondenciaBd.CadastradaPorNome,
                                           false));

            return await PersistirDados(_CorrespondenciaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ApagarCorrespondenciaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var correspondenciaBd = await _CorrespondenciaRepository.ObterPorId(request.CorrespondenciaId);
            if (correspondenciaBd == null)
            {
                AdicionarErro("Correspondência não encontrada.");
                return ValidationResult;
            }

            _CorrespondenciaRepository.Apagar(x=>x.Id == correspondenciaBd.Id);

            correspondenciaBd.AdicionarEvento(
               new RegistraHistoricoEvent(correspondenciaBd.Id, AcoesCorrespondencia.EXCLUSAO,
                                          correspondenciaBd.CadastradaPorId, correspondenciaBd.CadastradaPorNome,
                                          false));

            return await PersistirDados(_CorrespondenciaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(GerarExcelCorrespondenciaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var correspondencias = await _CorrespondenciaRepository.ObterPorIds(request.ListaCorrespondenciaId);

            var listaCorrespondenciasDTO = new List<CorrespondenciaExcelDTO>();

            foreach (var correspondencia in correspondencias)
            {
                var CorrespondenciaDTO = new CorrespondenciaExcelDTO
                {
                    DataDaChegada = correspondencia.DataDeCadastroFormatada,
                    CadastradaPor = correspondencia.CadastradaPorNome,
                    ObservacaoChegada = correspondencia.Observacao,                   
                    DataDaRetirada = correspondencia.DataDaRetirada.ToString(),
                    EntreguePor = correspondencia.EntreguePorNome,
                    RetiradoPor = correspondencia.NomeRetirante,
                    ObservacaoDaRetirada = correspondencia.ObservacaoDaRetirada
                };
                listaCorrespondenciasDTO.Add(CorrespondenciaDTO);
            }

            List<string> cabecalho = new List<string>
            {
                "Data da Chegada",
                "Cadastrada por",
                "Observação da Chegada",
                "Data da Retirada",
                "Entregue por",
                "Retirado por",
                "Observação da Retirada"
            };           

            var geradorExcel = new GeradorDeExcel<CorrespondenciaExcelDTO>
                (cabecalho, listaCorrespondenciasDTO, "Relatório de Correspondência", request.Ms);

            return geradorExcel.GerarExcel();
        }


        private Correspondencia CorrespondenciaFactory(AdicionarCorrespondenciaCommand request)
        {
            var correspondencia = new Correspondencia(
                request.DataDeChegada, request.CondominioId, request.UnidadeId, request.NumeroUnidade,
                request.Grupo, request.CadastradaPorId, request.CadastradaPorNome, request.Observacao,
                request.FotoCorrespondencia, request.NumeroRastreamentoCorreio, request.TipoDeCorrespondencia,
                request.Localizacao, request.EnviarNotificacao);

            return correspondencia;
        }


        public void Dispose()
        {
            _CorrespondenciaRepository?.Dispose();
        }


    }
}