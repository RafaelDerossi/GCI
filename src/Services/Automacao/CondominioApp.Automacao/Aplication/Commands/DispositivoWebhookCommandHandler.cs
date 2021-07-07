using CondominioApp.Automacao.App.Models;
using CondominioApp.Automacao.Models;
using CondominioApp.Core.Messages;
using FluentValidation.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Automacao.App.Aplication.Commands
{
    public class DispositivoWebhookCommandHandler : CommandHandler,
         IRequestHandler<AdicionarDispositivoWebhookCommand, ValidationResult>,
         IRequestHandler<AtualizarDispositivoWebhookCommand, ValidationResult>,
         IRequestHandler<ApagarDispositivoWebhookCommand, ValidationResult>,
         IRequestHandler<LigarDesligarDispositivoWebhookCommand, ValidationResult>,
         IDisposable
    {

        private readonly IAutomacaoRepository _condominioCredencialRepository;

        public DispositivoWebhookCommandHandler(IAutomacaoRepository condominioCredencialRepository)
        {
            _condominioCredencialRepository = condominioCredencialRepository;
        }


        public async Task<ValidationResult> Handle(AdicionarDispositivoWebhookCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var dispositivo =  new DispositivoWebhook(
                request.Nome, request.UrlLigar, request.UrlDesligar, request.CondominioId);
            

            if (await _condominioCredencialRepository.VerificaDispositivoWebhookJaEstaCadastrado(dispositivo.CondominioId, dispositivo.Nome))
            {
                AdicionarErro("Dispositivo com o mesmo nome ja cadastrado!");
                return ValidationResult;
            }

            _condominioCredencialRepository.AdicionarDispositivoWebhook(dispositivo);

            return await PersistirDados(_condominioCredencialRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarDispositivoWebhookCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var dispositivo = await _condominioCredencialRepository.ObterDispositivoWebhookPorId(request.Id);
            if (dispositivo == null)
            {
                AdicionarErro("Dispositivo não encontrado!");
                return ValidationResult;
            }
            if (dispositivo.Nome != request.Nome)
            {
               if (await _condominioCredencialRepository.VerificaDispositivoWebhookJaEstaCadastrado(request.CondominioId, request.Nome))
                {
                    AdicionarErro("Dispositivo com o mesmo nome ja cadastrado!");
                    return ValidationResult;
                }
            }

            dispositivo.SetNome(request.Nome);
            dispositivo.SetUrlLigar(request.UrlLigar);
            dispositivo.SetUrlDesligar(request.UrlDesligar);

            _condominioCredencialRepository.AtualizarDispositivoWebhook(dispositivo);

            return await PersistirDados(_condominioCredencialRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ApagarDispositivoWebhookCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var dispositivo = await _condominioCredencialRepository.ObterDispositivoWebhookPorId(request.Id);
            if (dispositivo == null)
            {
                AdicionarErro("Dispositivo não encontrado!");
                return ValidationResult;
            }

            _condominioCredencialRepository.ApagarDispositivoWebhook(x => x.Id == dispositivo.Id);

            return await PersistirDados(_condominioCredencialRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(LigarDesligarDispositivoWebhookCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var dispositivo = await _condominioCredencialRepository.ObterDispositivoWebhookPorId(request.Id);
            if (dispositivo == null)
            {
                AdicionarErro("Dispositivo não encontrado!");
                return ValidationResult;
            }

            if (dispositivo.Ligado)
                dispositivo.Desligar();
            else
                dispositivo.Ligar();

            _condominioCredencialRepository.AtualizarDispositivoWebhook(dispositivo);

            return await PersistirDados(_condominioCredencialRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _condominioCredencialRepository?.Dispose();
        }


    }
}
