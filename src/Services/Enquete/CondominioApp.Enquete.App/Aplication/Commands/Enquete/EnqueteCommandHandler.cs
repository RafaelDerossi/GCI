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
         IRequestHandler<AdicionarEnqueteCommand, ValidationResult>,
         IRequestHandler<AtualizarEnqueteCommand, ValidationResult>,
         IRequestHandler<AtualizarDataFimDaEnqueteCommand, ValidationResult>,
         IRequestHandler<ApagarEnqueteCommand, ValidationResult>,
         IDisposable
    {

        private readonly IEnqueteRepository _EnqueteRepository;

        public EnqueteCommandHandler(IEnqueteRepository enqueteRepository)
        {
            _EnqueteRepository = enqueteRepository;
        }


        public async Task<ValidationResult> Handle(AdicionarEnqueteCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var enquete = EnqueteFactory(request);           

            foreach (var alternativa in request.Alternativas)
            {                
                var resultado = enquete.AdicionarAlternativa(alternativa);
                if (!resultado.IsValid)
                    return resultado;
            }

            _EnqueteRepository.Adicionar(enquete);

            enquete.EnviarEmailNovaEnquete();

            return await PersistirDados(_EnqueteRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarEnqueteCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var enqueteBd = await _EnqueteRepository.ObterPorId(request.Id);
            if (enqueteBd == null)
            {
                AdicionarErro("Enquete não encontrada.");
                return ValidationResult;
            }

            var retorno = enqueteBd.Editar
               (request.Descricao, request.DataInicio, request.DataFim, request.ApenasProprietarios);
            if (!retorno.IsValid)
                return retorno;

            retorno = EditarAlternativasDaEnquete(enqueteBd, request);
            if (!retorno.IsValid)
                return retorno;
            

            _EnqueteRepository.Atualizar(enqueteBd);

            return await PersistirDados(_EnqueteRepository.UnitOfWork);
        }
        private ValidationResult EditarAlternativasDaEnquete(Enquete enqueteBd, AtualizarEnqueteCommand request)
        {
            foreach (var item in enqueteBd.Alternativas)
            {
                _EnqueteRepository.RemoverAlternativa(item);
            }
            enqueteBd.RemoverTodasAsAlternativa();

            foreach (var alternativa in request.Alternativas)
            {
                var resultado = enqueteBd.AdicionarAlternativa(alternativa);
                if (!resultado.IsValid)
                    return resultado;
                _EnqueteRepository.AdicionarAlternativa(alternativa);
            }

            return ValidationResult;
        }

        public async Task<ValidationResult> Handle(AtualizarDataFimDaEnqueteCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var enqueteBd = await _EnqueteRepository.ObterPorId(request.Id);
            if (enqueteBd == null)
            {
                AdicionarErro("Enquete não encontrada.");
                return ValidationResult;
            }           
            
            var retorno = enqueteBd.SetDataFim(request.DataFim);
            if (!retorno.IsValid)
                return retorno;

            _EnqueteRepository.Atualizar(enqueteBd);

            return await PersistirDados(_EnqueteRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ApagarEnqueteCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var enqueteBd = await _EnqueteRepository.ObterPorId(request.Id);
            if (enqueteBd == null)
            {
                AdicionarErro("Enquete não encontrada.");
                return ValidationResult;
            }            
           
            _EnqueteRepository.Apagar(x=>x.Id == enqueteBd.Id);

            return await PersistirDados(_EnqueteRepository.UnitOfWork);
        }



        private Enquete EnqueteFactory(AdicionarEnqueteCommand request)
        {
            var enquete = new Enquete(request.Descricao, request.DataInicio, request.DataFim, request.CondominioId, 
                request.CondominioNome, request.ApenasProprietarios, request.FuncionarioId, request.FuncionarioNome);

            return enquete;
        }


        public void Dispose()
        {
            _EnqueteRepository?.Dispose();
        }


    }
}
