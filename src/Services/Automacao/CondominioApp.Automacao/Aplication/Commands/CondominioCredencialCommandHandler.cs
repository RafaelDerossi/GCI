using CondominioApp.Automacao.App.Models;
using CondominioApp.Automacao.Models;
using CondominioApp.Core.Enumeradores;
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
         IDisposable
    {

        private ICondominioCredencialRepository _condominioCredencialRepository;

        public CondominioCredencialCommandHandler(ICondominioCredencialRepository condominioCredencialRepository)
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



      

        public void Dispose()
        {
            _condominioCredencialRepository?.Dispose();
        }


    }
}
