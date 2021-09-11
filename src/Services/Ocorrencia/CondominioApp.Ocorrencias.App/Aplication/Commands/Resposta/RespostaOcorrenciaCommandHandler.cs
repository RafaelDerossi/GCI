﻿using CondominioApp.Core.Messages;
using CondominioApp.Ocorrencias.App.Models;
using FluentValidation.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands
{
    public class RespostaOcorrenciaCommandHandler : CommandHandler,
         IRequestHandler<AdicionarRespostaOcorrenciaAdministracaoCommand, ValidationResult>,
         IRequestHandler<AdicionarRespostaOcorrenciaMoradorCommand, ValidationResult>,
         IRequestHandler<AtualizarRespostaOcorrenciaCommand, ValidationResult>,
         IRequestHandler<MarcarRespostaOcorrenciaComoVistaCommand, ValidationResult>,
         IRequestHandler<ApagarRespostaOcorrenciaCommand, ValidationResult>,
         IDisposable
    {

        private readonly IOcorrenciaRepository _ocorrenciaRepository;

        public RespostaOcorrenciaCommandHandler(IOcorrenciaRepository ocorrenciaRepository)
        {
            _ocorrenciaRepository = ocorrenciaRepository;
        }


        public async Task<ValidationResult> Handle(AdicionarRespostaOcorrenciaAdministracaoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var ocorrencia = await _ocorrenciaRepository.ObterPorId(request.OcorrenciaId);
            if (ocorrencia == null)
            {
                AdicionarErro("Ocorrência não encontrada!");
                return ValidationResult;
            }              

           
            var resposta = RespostaOcorrenciaFactory(request);

            var retorno = ocorrencia.AdicionarRespostaDeSindico(resposta, request.Status);
            if (!retorno.IsValid)
                return retorno;

            resposta.EnviarPushParaMorador(ocorrencia.MoradorId, request.Status);

            resposta.EnviarEmailParaMorador(ocorrencia.MoradorId, request.Status, ocorrencia.Descricao);

            _ocorrenciaRepository.AdicionarResposta(resposta);            

            _ocorrenciaRepository.Atualizar(ocorrencia);

            return await PersistirDados(_ocorrenciaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AdicionarRespostaOcorrenciaMoradorCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var ocorrencia = await _ocorrenciaRepository.ObterPorId(request.OcorrenciaId);
            if (ocorrencia == null)
            {
                AdicionarErro("Ocorrência não encontrada!");
                return ValidationResult;
            }                     

            var resposta = RespostaOcorrenciaFactory(request);
            
            var retorno = ocorrencia.AdicionarRespostaDeMorador(resposta);
            if (!retorno.IsValid)
                return retorno;

            resposta.EnviarPushParaAdministracao(ocorrencia.CondominioId);

            resposta.EnviarEmailParaAdministracao(ocorrencia.CondominioId, request.Status, ocorrencia.Descricao);

            _ocorrenciaRepository.AdicionarResposta(resposta);

            return await PersistirDados(_ocorrenciaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(MarcarRespostaOcorrenciaComoVistaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var resposta = await _ocorrenciaRepository.ObterRespostaPorId(request.Id);
            if (resposta == null)
            {
                AdicionarErro("Resposta não encontrada!");
                return ValidationResult;
            }

            resposta.MarcarComoVisto();

            _ocorrenciaRepository.AtualizarResposta(resposta);

            return await PersistirDados(_ocorrenciaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarRespostaOcorrenciaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var resposta = await _ocorrenciaRepository.ObterRespostaPorId(request.Id);
            if (resposta == null)
            {
                AdicionarErro("Resposta não encontrada!");
                return ValidationResult;
            }

            var retorno = resposta.Editar(request.Descricao, request.Foto, request.AutorId);
            if (!retorno.IsValid)
                return retorno;

            _ocorrenciaRepository.AtualizarResposta(resposta);

            return await PersistirDados(_ocorrenciaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ApagarRespostaOcorrenciaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var resposta = await _ocorrenciaRepository.ObterRespostaPorId(request.Id);
            if (resposta == null)
            {
                AdicionarErro("Resposta não encontrada!");
                return ValidationResult;
            }

            var retorno = resposta.Apagar(request.AutorId);
            if (!retorno.IsValid)
                return retorno;

            _ocorrenciaRepository.ApagarResposta(x=>x.Id == resposta.Id);

            return await PersistirDados(_ocorrenciaRepository.UnitOfWork);
        }


        private RespostaOcorrencia RespostaOcorrenciaFactory(RespostaOcorrenciaCommand request)
        {
            var ocorrencia = new RespostaOcorrencia(
                request.OcorrenciaId, request.Descricao, request.TipoAutor, request.AutorId,
                request.NomeDoAutor, request.Visto, request.Foto, request.ArquivoAnexo);
           
            return ocorrencia;
        }


        public void Dispose()
        {
            _ocorrenciaRepository?.Dispose();
        }


    }
}