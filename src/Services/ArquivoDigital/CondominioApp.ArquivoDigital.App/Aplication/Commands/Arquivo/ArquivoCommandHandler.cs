using CondominioApp.ArquivoDigital.App.Models;
using CondominioApp.Core.Messages;
using FluentValidation.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class ArquivoCommandHandler : CommandHandler,
         IRequestHandler<CadastrarArquivoCommand, ValidationResult>,
         IRequestHandler<EditarArquivoCommand, ValidationResult>,
         IRequestHandler<AlterarPastaDoArquivoCommand, ValidationResult>,
         IRequestHandler<MarcarArquivoComoPublicoCommand, ValidationResult>,
         IRequestHandler<MarcarArquivoComoPrivadoCommand, ValidationResult>,
         IRequestHandler<RemoverArquivoCommand, ValidationResult>,
         IDisposable
    {

        private IArquivoDigitalRepository _arquivoDigitalRepository;

        public ArquivoCommandHandler(IArquivoDigitalRepository arquivoDigitalRepository)
        {
            _arquivoDigitalRepository = arquivoDigitalRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarArquivoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var arquivo = ArquivoFactory(request);

            var pasta = _arquivoDigitalRepository.ObterPorId(arquivo.PastaId);
            if (pasta == null)
            {
                AdicionarErro("Pasta não encontrada!");
                return ValidationResult;
            }

            _arquivoDigitalRepository.AdicionarArquivo(arquivo);           

            return await PersistirDados(_arquivoDigitalRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(EditarArquivoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;


            var arquivoBd = await _arquivoDigitalRepository.ObterArquivoPorId(request.Id);
            if (arquivoBd == null)
            {
                AdicionarErro("Arquivo não encontrado.");
                return ValidationResult;
            }

            arquivoBd.SetNomeOriginal(request.NomeOriginal);
            arquivoBd.MarcarComoPrivado();
            if (request.Publico)
                arquivoBd.MarcarComoPublico();

            _arquivoDigitalRepository.AtualizarArquivo(arquivoBd);


            return await PersistirDados(_arquivoDigitalRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AlterarPastaDoArquivoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;


            var arquivoBd = await _arquivoDigitalRepository.ObterArquivoPorId(request.Id);
            if (arquivoBd == null)
            {
                AdicionarErro("Arquivo não encontrado.");
                return ValidationResult;
            }

            arquivoBd.SetNomeOriginal(request.NomeOriginal);
            arquivoBd.MarcarComoPrivado();
            if (request.Publico)
                arquivoBd.MarcarComoPublico();

            _arquivoDigitalRepository.AtualizarArquivo(arquivoBd);


            return await PersistirDados(_arquivoDigitalRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(MarcarArquivoComoPublicoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;


            var arquivoBd = await _arquivoDigitalRepository.ObterArquivoPorId(request.Id);
            if (arquivoBd == null)
            {
                AdicionarErro("Arquivo não encontrado.");
                return ValidationResult;
            }

            arquivoBd.SetNomeOriginal(request.NomeOriginal);
            arquivoBd.MarcarComoPrivado();
            if (request.Publico)
                arquivoBd.MarcarComoPublico();

            _arquivoDigitalRepository.AtualizarArquivo(arquivoBd);


            return await PersistirDados(_arquivoDigitalRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(MarcarArquivoComoPrivadoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;


            var arquivoBd = await _arquivoDigitalRepository.ObterArquivoPorId(request.Id);
            if (arquivoBd == null)
            {
                AdicionarErro("Arquivo não encontrado.");
                return ValidationResult;
            }

            arquivoBd.SetNomeOriginal(request.NomeOriginal);
            arquivoBd.MarcarComoPrivado();
            if (request.Publico)
                arquivoBd.MarcarComoPublico();

            _arquivoDigitalRepository.AtualizarArquivo(arquivoBd);


            return await PersistirDados(_arquivoDigitalRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoverArquivoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;


            var pastaBd = await _pastaRepository.ObterPorId(request.Id);
            if (pastaBd == null)
            {
                AdicionarErro("Pasta não encontrada.");
                return ValidationResult;
            }

            pastaBd.EnviarParaLixeira();

            _pastaRepository.Atualizar(pastaBd);


            return await PersistirDados(_pastaRepository.UnitOfWork);
        }



        private Arquivo ArquivoFactory(CadastrarArquivoCommand request)
        {
            return new Arquivo(request.Nome, request.NomeOriginal, request.Extensao, request.Tamanho, request.CondominioId, request.PastaId);
        }


        public void Dispose()
        {
            _arquivoDigitalRepository?.Dispose();
        }


    }
}
