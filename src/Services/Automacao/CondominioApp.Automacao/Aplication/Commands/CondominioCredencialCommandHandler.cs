using CondominioApp.Automacao.App.Models;
using CondominioApp.Automacao.Models;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Messages;
using FluentValidation.Results;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Automacao.App.Aplication.Commands
{
    public class CondominioCredencialCommandHandler : CommandHandler,
         IRequestHandler<CadastrarCondominioCredencialCommand, ValidationResult>,
         IRequestHandler<EditarCondominioCredencialCommand, ValidationResult>,
         IRequestHandler<RemoverCondominioCredencialCommand, ValidationResult>,
         IDisposable
    {

        private readonly IAutomacaoRepository _condominioCredencialRepository;

        public CondominioCredencialCommandHandler(IAutomacaoRepository condominioCredencialRepository)
        {
            _condominioCredencialRepository = condominioCredencialRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarCondominioCredencialCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var credencial =  new CondominioCredencial(
                request.Email, request.Senha, request.CondominioId, request.TipoApiAutomacao);           
            

            if (await _condominioCredencialRepository.VerificaSeJaEstaCadastrado(credencial.CondominioId, credencial.TipoApiAutomacao))
            {
                AdicionarErro("Credencial ja cadastrada!");
                return ValidationResult;
            }

            _condominioCredencialRepository.Adicionar(credencial);

            return await PersistirDados(_condominioCredencialRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(EditarCondominioCredencialCommand request, CancellationToken cancellationToken)
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

        public async Task<ValidationResult> Handle(RemoverCondominioCredencialCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var credencial = await _condominioCredencialRepository.ObterPorId(request.Id);
            if (credencial == null)
            {
                AdicionarErro("Credencial não encontrada!");
                return ValidationResult;
            }

            credencial.EnviarParaLixeira();

            _condominioCredencialRepository.Atualizar(credencial);

            return await PersistirDados(_condominioCredencialRepository.UnitOfWork);
        }


        public void Dispose()
        {
            _condominioCredencialRepository?.Dispose();
        }


    }
}
