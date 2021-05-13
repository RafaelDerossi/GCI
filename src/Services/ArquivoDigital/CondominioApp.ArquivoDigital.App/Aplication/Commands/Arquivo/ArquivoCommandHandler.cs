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
         IRequestHandler<AdicionarArquivoCommand, ValidationResult>,
         IRequestHandler<AtualizarArquivoCommand, ValidationResult>,
         IRequestHandler<AlterarPastaDoArquivoCommand, ValidationResult>,
         IRequestHandler<MarcarArquivoComoPublicoCommand, ValidationResult>,
         IRequestHandler<MarcarArquivoComoPrivadoCommand, ValidationResult>,
         IRequestHandler<ApagarArquivoCommand, ValidationResult>,
         IDisposable
    {

        private readonly IArquivoDigitalRepository _arquivoDigitalRepository;

        public ArquivoCommandHandler(IArquivoDigitalRepository arquivoDigitalRepository)
        {
            _arquivoDigitalRepository = arquivoDigitalRepository;
        }


        public async Task<ValidationResult> Handle(AdicionarArquivoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;           

            var pasta = await _arquivoDigitalRepository.ObterPorId(request.PastaId);
            if (pasta == null)
            {
                AdicionarErro("Pasta não encontrada!");
                return ValidationResult;
            }

            var arquivo = ArquivoFactory(request, pasta.CondominioId);

            _arquivoDigitalRepository.AdicionarArquivo(arquivo);           

            return await PersistirDados(_arquivoDigitalRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarArquivoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;


            var arquivoBd = await _arquivoDigitalRepository.ObterArquivoPorId(request.Id);
            if (arquivoBd == null)
            {
                AdicionarErro("Arquivo não encontrado.");
                return ValidationResult;
            }

            arquivoBd.SetTitulo(request.Titulo);
            arquivoBd.SetDescricao(request.Descricao);
            arquivoBd.MarcarComoPrivado();
            if (request.Publico)
                arquivoBd.MarcarComoPublico();
            arquivoBd.SetNome(request.Nome);

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

            var pastaBd = await _arquivoDigitalRepository.ObterPorId(request.PastaId);
            if (pastaBd == null)
            {
                AdicionarErro("Pasta não encontrada.");
                return ValidationResult;
            }

            arquivoBd.SetPastaId(request.PastaId);           

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
                        
            arquivoBd.MarcarComoPrivado();
            
            _arquivoDigitalRepository.AtualizarArquivo(arquivoBd);


            return await PersistirDados(_arquivoDigitalRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ApagarArquivoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;


            var arquivoBd = await _arquivoDigitalRepository.ObterArquivoPorId(request.Id);
            if (arquivoBd == null)
            {
                AdicionarErro("Arquivo não encontrado.");
                return ValidationResult;
            }

            _arquivoDigitalRepository.ApagarArquivo(x=>x.Id == arquivoBd.Id);

            return await PersistirDados(_arquivoDigitalRepository.UnitOfWork);
        }



        private Arquivo ArquivoFactory(AdicionarArquivoCommand request, Guid condominioId)
        {
            var arquivo = new Arquivo(request.Nome, request.Tamanho, condominioId, request.PastaId, request.Publico, 
                                      request.FuncionarioId, request.NomeFuncionario, request.Titulo, request.Descricao,
                                      request.AnexadoPorId);

            arquivo.SetEntidadeId(request.Id);
            return arquivo;
        }


        public void Dispose()
        {
            _arquivoDigitalRepository?.Dispose();
        }


    }
}
