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
    public class OcorrenciaCommandHandler : CommandHandler,
         IRequestHandler<CadastrarOcorrenciaCommand, ValidationResult>,
         IRequestHandler<ColocarOcorrenciaEmAndamentoCommand, ValidationResult>,
         IRequestHandler<MarcarOcorrenciaComoResolvidaCommand, ValidationResult>,
         IRequestHandler<RemoverOcorrenciaCommand, ValidationResult>,
         IDisposable
    {

        private IOcorrenciaRepository _ocorrenciaRepository;

        public OcorrenciaCommandHandler(IOcorrenciaRepository ocorrenciaRepository)
        {
            _ocorrenciaRepository = ocorrenciaRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarOcorrenciaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var ocorrencia = OcorrenciaFactory(request);           
           
            _ocorrenciaRepository.Adicionar(ocorrencia);

            return await PersistirDados(_ocorrenciaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ColocarOcorrenciaEmAndamentoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var ocorrencia = await _ocorrenciaRepository.ObterPorId(request.Id);
            if (ocorrencia == null)
            {
                AdicionarErro("Ocorrência não encontrada!");
                return ValidationResult;
            }

            ocorrencia.ColocarEmAndamento(request.Parecer);

            _ocorrenciaRepository.Atualizar(ocorrencia);

            return await PersistirDados(_ocorrenciaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(MarcarOcorrenciaComoResolvidaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var ocorrencia = await _ocorrenciaRepository.ObterPorId(request.Id);
            if (ocorrencia == null)
            {
                AdicionarErro("Ocorrência não encontrada!");
                return ValidationResult;
            }

            ocorrencia.MarcarComoResolvida(request.Parecer);

            _ocorrenciaRepository.Atualizar(ocorrencia);

            return await PersistirDados(_ocorrenciaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoverOcorrenciaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var ocorrencia = await _ocorrenciaRepository.ObterPorId(request.Id);
            if (ocorrencia == null)
            {
                AdicionarErro("Ocorrência não encontrada!");
                return ValidationResult;
            }

            ocorrencia.EnviarParaLixeira();

            _ocorrenciaRepository.Atualizar(ocorrencia);            

            return await PersistirDados(_ocorrenciaRepository.UnitOfWork);
        }



        private Ocorrencia OcorrenciaFactory(CadastrarOcorrenciaCommand request)
        {
            var ocorrencia = new Ocorrencia(
                request.Descricao, request.Foto, request.Publica, request.UnidadeId, request.UsuarioId,
                request.CondominioId, request.Panico);
           
            return ocorrencia;
        }


        public void Dispose()
        {
            _ocorrenciaRepository?.Dispose();
        }


    }
}
