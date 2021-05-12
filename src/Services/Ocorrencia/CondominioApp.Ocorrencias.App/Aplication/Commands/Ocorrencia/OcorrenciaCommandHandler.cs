using CondominioApp.Core.Messages;
using CondominioApp.Ocorrencias.App.Models;
using FluentValidation.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands
{
    public class OcorrenciaCommandHandler : CommandHandler,
         IRequestHandler<CadastrarOcorrenciaCommand, ValidationResult>,
         IRequestHandler<EditarOcorrenciaCommand, ValidationResult>,
         IRequestHandler<ApagarOcorrenciaCommand, ValidationResult>,
         IDisposable
    {

        private readonly IOcorrenciaRepository _ocorrenciaRepository;

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

            ocorrencia.EnviarPushNovaOcorrencia();

            ocorrencia.EnviarEmailNovaOcorrencia();

            return await PersistirDados(_ocorrenciaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(EditarOcorrenciaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var ocorrencia = await _ocorrenciaRepository.ObterPorId(request.Id);
            if (ocorrencia == null)
            {
                AdicionarErro("Ocorrência não encontrada!");
                return ValidationResult;
            }

            var retorno = ocorrencia.Editar(request.Descricao, request.Foto, request.Publica);
            if (!retorno.IsValid)
                return retorno;
                       

            _ocorrenciaRepository.Atualizar(ocorrencia);

            ocorrencia.EnviarPushOcorrenciaEditada();

            ocorrencia.EnviarEmailOcorrenciaEditada();

            return await PersistirDados(_ocorrenciaRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ApagarOcorrenciaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var ocorrencia = await _ocorrenciaRepository.ObterPorId(request.Id);
            if (ocorrencia == null)
            {
                AdicionarErro("Ocorrência não encontrada!");
                return ValidationResult;
            }
           
            var retorno = ocorrencia.Remover();
            if (!retorno.IsValid)
                return retorno;

            _ocorrenciaRepository.Apagar(x=>x.Id == ocorrencia.Id);

            ocorrencia.EnviarPushOcorrenciaRemovida();

            ocorrencia.EnviarEmailOcorrenciaRemovida();

            return await PersistirDados(_ocorrenciaRepository.UnitOfWork);
        }



        private Ocorrencia OcorrenciaFactory(CadastrarOcorrenciaCommand request)
        {
            var ocorrencia = new Ocorrencia(
                request.Descricao, request.Foto, request.Publica, request.UnidadeId, request.MoradorId,
                request.NomeMorador, request.CondominioId, request.Panico);
           
            return ocorrencia;
        }


        public void Dispose()
        {
            _ocorrenciaRepository?.Dispose();
        }


    }
}
