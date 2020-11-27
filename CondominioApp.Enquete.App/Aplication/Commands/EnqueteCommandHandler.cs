using CondominioApp.Core.Messages;
using CondominioApp.Enquetes.App.Models;
using FluentValidation.Results;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Enquetes.App.Aplication.Commands
{
    public class EnqueteCommandHandler : CommandHandler,
         IRequestHandler<CadastrarEnqueteCommand, ValidationResult>,
         IDisposable
    {

        private IEnqueteRepository _enqueteRepository;

        public EnqueteCommandHandler(IEnqueteRepository enqueteRepository)
        {
            _enqueteRepository = enqueteRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarEnqueteCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var enquete = EnqueteFactory(request);
                        
            _enqueteRepository.Adicionar(enquete);

            //enquete.AdicionarEvento(
            //    new EnqueteCadastradaEvent(enquete.Id, enquete.DataDeCadastro, enquete.DataDeAlteracao,
            //    enquete.Descricao, ));

            return await PersistirDados(_enqueteRepository.UnitOfWork);
        }

       

        private Enquete EnqueteFactory(CadastrarEnqueteCommand request)
        {
            var enquete = new Enquete(request.Descricao, request.DataInicio, request.DataFim, request.CondominioId, 
                request.CondominioNome, request.ApenasProprietarios, request.UsuarioId, request.UsuarioNome,
                request.Alternativas);

            return enquete;
        }


        public void Dispose()
        {
            _enqueteRepository?.Dispose();
        }


    }
}
