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

        private ICondominioCredencialRepository _CondominioCredencialRepository;

        public CondominioCredencialCommandHandler(ICondominioCredencialRepository condominioCredencialRepository)
        {
            _CondominioCredencialRepository = condominioCredencialRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarCondominioCredencialCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var comunicado =  new CondominioCredencial(request.Email, request.Senha, request.CondominioId);
                                   
            _CondominioCredencialRepository.Adicionar(comunicado);

            return await PersistirDados(_CondominioCredencialRepository.UnitOfWork);
        }

                
        public void Dispose()
        {
            _CondominioCredencialRepository?.Dispose();
        }


    }
}
