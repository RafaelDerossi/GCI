using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Ocorrencias.App.Aplication.Commands;
using CondominioApp.Ocorrencias.App.Models;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Comunicados.App.Aplication.Commands
{
    public class RespostaOcorrenciaCommandHandler : CommandHandler,
         IRequestHandler<CadastrarRespostaOcorrenciaSindicoCommand, ValidationResult>,
         IRequestHandler<CadastrarRespostaOcorrenciaMoradorCommand, ValidationResult>,
         IRequestHandler<MarcarRespostaOcorrenciaComoVistaCommand, ValidationResult>,
         IDisposable
    {

        private IOcorrenciaRepository _ocorrenciaRepository;

        public RespostaOcorrenciaCommandHandler(IOcorrenciaRepository ocorrenciaRepository)
        {
            _ocorrenciaRepository = ocorrenciaRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarRespostaOcorrenciaSindicoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var ocorrencia = await _ocorrenciaRepository.ObterPorId(request.OcorrenciaId);
            if (ocorrencia == null)
            {
                AdicionarErro("Ocorrência não encontrada!");
                return ValidationResult;
            }

            if (ocorrencia.Status == StatusDaOcorrencia.RESOLVIDA)
            {
                AdicionarErro("Ocorrência já está resolvida!");
                return ValidationResult;
            }


            var resposta = RespostaOcorrenciaFactory(request);

            ocorrencia.AdicionarResposta(resposta);

            if (request.Status == StatusDaOcorrencia.EM_ANDAMENTO)
                ocorrencia.ColocarEmAndamento();

            if (request.Status == StatusDaOcorrencia.RESOLVIDA)
                ocorrencia.MarcarComoResolvida();

            _ocorrenciaRepository.AdicionarResposta(resposta);

            return await PersistirDados(_ocorrenciaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(CadastrarRespostaOcorrenciaMoradorCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var ocorrencia = await _ocorrenciaRepository.ObterPorId(request.OcorrenciaId);
            if (ocorrencia == null)
            {
                AdicionarErro("Ocorrência não encontrada!");
                return ValidationResult;
            }

            if (ocorrencia.Status == StatusDaOcorrencia.RESOLVIDA)
            {
                AdicionarErro("Ocorrência já está resolvida!");
                return ValidationResult;
            }

            if (ocorrencia.UsuarioId != request.UsuarioId && !ocorrencia.Publica)
            {
                AdicionarErro("Somente o usuário que criou a ocorrência privada pode responder!");
                return ValidationResult;
            }

            var resposta = RespostaOcorrenciaFactory(request);
            
            ocorrencia.AdicionarResposta(resposta);
            
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


        private RespostaOcorrencia RespostaOcorrenciaFactory(RespostaOcorrenciaCommand request)
        {
            var ocorrencia = new RespostaOcorrencia(
                request.OcorrenciaId, request.Descricao, request.TipoAutor, request.UsuarioId,
                request.NomeUsuario, request.Visto, request.Foto);
           
            return ocorrencia;
        }


        public void Dispose()
        {
            _ocorrenciaRepository?.Dispose();
        }


    }
}
