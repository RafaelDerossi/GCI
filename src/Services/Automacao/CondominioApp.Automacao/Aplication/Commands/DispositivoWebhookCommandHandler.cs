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

            var credencial = await _condominioCredencialRepository.ObterPorId(request.Id);
            if (credencial == null)
            {
                AdicionarErro("Credencial não encontrada!");
                return ValidationResult;
            }

            credencial.SetCredencial(request.Email, request.Senha, request.TipoApiAutomacao);

            _condominioCredencialRepository.Atualizar(credencial);

            return await PersistirDados(_condominioCredencialRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ApagarDispositivoWebhookCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var credencial = await _condominioCredencialRepository.ObterPorId(request.Id);
            if (credencial == null)
            {
                AdicionarErro("Credencial não encontrada!");
                return ValidationResult;
            }

            _condominioCredencialRepository.Apagar(x => x.Id == credencial.Id);

            return await PersistirDados(_condominioCredencialRepository.UnitOfWork);
        }


        public void Dispose()
        {
            _condominioCredencialRepository?.Dispose();
        }


    }
}
