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
    public class AlternativaEnqueteCommandHandler : CommandHandler,        
         IRequestHandler<AlterarAlternativaCommand, ValidationResult>,        
         IDisposable
    {

        private IEnqueteRepository _EnqueteRepository;

        public AlternativaEnqueteCommandHandler(IEnqueteRepository enqueteRepository)
        {
            _EnqueteRepository = enqueteRepository;
        }


        public async Task<ValidationResult> Handle(AlterarAlternativaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var alternativa = await _EnqueteRepository.ObterAlternativaPorId(request.Id);

            alternativa.SetDescricao(request.Descricao);

            var enquete = await _EnqueteRepository.ObterPorId(alternativa.EnqueteId);

            var resultado = enquete.AlterarAlternativa(alternativa);
            if (!resultado.IsValid) return resultado;
                       
            _EnqueteRepository.Atualizar(enquete);           

            return await PersistirDados(_EnqueteRepository.UnitOfWork);
        }

     


        public void Dispose()
        {
            _EnqueteRepository?.Dispose();
        }


    }
}
