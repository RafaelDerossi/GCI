using CondominioApp.ArquivoDigital.App.Models;
using CondominioApp.Core.Messages;
using FluentValidation.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class PastaCommandHandler : CommandHandler,
         IRequestHandler<CadastrarPastaCommand, ValidationResult>,
         IRequestHandler<EditarPastaCommand, ValidationResult>,
         IRequestHandler<MarcarPastaComoPublicaCommand, ValidationResult>,
         IRequestHandler<MarcarPastaComoPrivadaCommand, ValidationResult>,
         IRequestHandler<ApagarPastaCommand, ValidationResult>,
         IDisposable
    {

        private readonly IArquivoDigitalRepository _arquivoDigitalRepository;

        public PastaCommandHandler(IArquivoDigitalRepository arquivoDigitalRepository)
        {
            _arquivoDigitalRepository = arquivoDigitalRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarPastaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var pasta = PastaFactory(request);            

            _arquivoDigitalRepository.Adicionar(pasta);           

            return await PersistirDados(_arquivoDigitalRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(EditarPastaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;


            var pastaBd = await _arquivoDigitalRepository.ObterPorId(request.Id);
            if (pastaBd == null)
            {
                AdicionarErro("Pasta não encontrada.");
                return ValidationResult;
            }

            pastaBd.SetTitulo(request.Titulo);
            pastaBd.SetDescricao(request.Descricao);
            pastaBd.MarcarComoPrivada();
            if (request.Publica)
                pastaBd.MarcarComoPublica();
            
            _arquivoDigitalRepository.Atualizar(pastaBd);


            return await PersistirDados(_arquivoDigitalRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(MarcarPastaComoPublicaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;


            var pastaBd = await _arquivoDigitalRepository.ObterPorId(request.Id);
            if (pastaBd == null)
            {
                AdicionarErro("Pasta não encontrada.");
                return ValidationResult;
            }            
            
            pastaBd.MarcarComoPublica();

            _arquivoDigitalRepository.Atualizar(pastaBd);


            return await PersistirDados(_arquivoDigitalRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(MarcarPastaComoPrivadaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;


            var pastaBd = await _arquivoDigitalRepository.ObterPorId(request.Id);
            if (pastaBd == null)
            {
                AdicionarErro("Pasta não encontrada.");
                return ValidationResult;
            }

            pastaBd.MarcarComoPrivada();

            _arquivoDigitalRepository.Atualizar(pastaBd);


            return await PersistirDados(_arquivoDigitalRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ApagarPastaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;


            var pastaBd = await _arquivoDigitalRepository.ObterPorId(request.Id);
            if (pastaBd == null)
            {
                AdicionarErro("Pasta não encontrada.");
                return ValidationResult;
            }

            _arquivoDigitalRepository.Apagar(x => x.Id == pastaBd.Id);

            return await PersistirDados(_arquivoDigitalRepository.UnitOfWork);
        }



        private Pasta PastaFactory(CadastrarPastaCommand request)
        {
            var pasta = new Pasta
                (request.Titulo, request.Descricao, request.CondominioId, request.Publica,
                request.PastaDoSistema, request.CategoriaDaPastaDeSistema);

            pasta.SetEntidadeId(request.Id);

            return pasta;
        }


        public void Dispose()
        {
            _arquivoDigitalRepository?.Dispose();
        }


    }
}
