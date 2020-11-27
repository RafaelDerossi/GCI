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
         IRequestHandler<AlterarEnqueteCommand, ValidationResult>,
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
                        
            _EnqueteRepository.Adicionar(enquete);           

            return await PersistirDados(_EnqueteRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AlterarEnqueteCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;


            var enqueteBd = await _EnqueteRepository.ObterPorId(request.Id);
            if (enqueteBd == null)
            {
                AdicionarErro("Enquete não encontrada.");
                return ValidationResult;
            }
           
            enqueteBd.SetDescricao(request.Descricao);
            enqueteBd.SetDataInicial(request.DataInicio);
            enqueteBd.SetDataFim(request.DataFim);
            enqueteBd.SetApenasProprietarios(request.ApenasProprietarios);
           
            _EnqueteRepository.Atualizar(enqueteBd);


            return await PersistirDados(_EnqueteRepository.UnitOfWork);
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
            _EnqueteRepository?.Dispose();
        }


    }
}
