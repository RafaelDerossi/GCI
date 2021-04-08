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
         IRequestHandler<EditarEnqueteCommand, ValidationResult>,
         IRequestHandler<RemoverEnqueteCommand, ValidationResult>,
         IDisposable
    {

        private IEnqueteRepository _EnqueteRepository;

        public EnqueteCommandHandler(IEnqueteRepository enqueteRepository)
        {
            _EnqueteRepository = enqueteRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarEnqueteCommand request, CancellationToken cancellationToken)
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

        public async Task<ValidationResult> Handle(EditarEnqueteCommand request, CancellationToken cancellationToken)
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
           

            return await PersistirDados(_EnqueteRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoverEnqueteCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var enqueteBd = await _EnqueteRepository.ObterPorId(request.Id);
            if (enqueteBd == null)
            {
                AdicionarErro("Enquete não encontrada.");
                return ValidationResult;
            }

            enqueteBd.EnviarParaLixeira();
           
            _EnqueteRepository.Atualizar(enqueteBd);


            return await PersistirDados(_EnqueteRepository.UnitOfWork);
        }



        private Enquete EnqueteFactory(CadastrarEnqueteCommand request)
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
