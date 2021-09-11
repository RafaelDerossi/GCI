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
    public class RespostaEnqueteCommandHandler : CommandHandler,
         IRequestHandler<CadastrarRespostaCommand, ValidationResult>,        
         IDisposable
    {

        private readonly IEnqueteRepository _EnqueteRepository;

        public RespostaEnqueteCommandHandler(IEnqueteRepository enqueteRepository)
        {
            _EnqueteRepository = enqueteRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarRespostaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var respostaEnquete = RespostaEnqueteFactory(request);           

            var alternativa = await _EnqueteRepository.ObterAlternativaPorId(request.AlternativaId);
            if (alternativa == null)
            {
                AdicionarErro("Alternativa não encontrada!");
                return ValidationResult;
            }

            var resultado = alternativa.AdicionarResposta(respostaEnquete);

            if (!resultado.IsValid) return resultado;

            _EnqueteRepository.AdicionarResposta(respostaEnquete);           

            return await PersistirDados(_EnqueteRepository.UnitOfWork);
        }

        


        private RespostaEnquete RespostaEnqueteFactory(CadastrarRespostaCommand request)
        {
            return new RespostaEnquete(request.UnidadeId, request.Unidade, request.Bloco,
                request.UsuarioId, request.UsuarioNome, request.TipoDeUsuario, request.AlternativaId);
            
        }


        public void Dispose()
        {
            _EnqueteRepository?.Dispose();
        }


    }
}
