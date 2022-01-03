using FluentValidation.Results;
using MediatR;
using GCI.Acoes.Aplication.Events;
using GCI.Acoes.Domain;
using GCI.Acoes.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using GCI.Core.Messages.CommonHandlers;

namespace GCI.Acoes.Aplication.Commands
{
    public class AcaoCommandHandler : CommandHandler,
         IRequestHandler<AdicionarAcaoCommand, ValidationResult>,
         IDisposable
    {

        private readonly IAcaoRepository _acaoRepository;        

        public AcaoCommandHandler(IAcaoRepository acaoRepository)
        {
            _acaoRepository = acaoRepository;
        }

        public async Task<ValidationResult> Handle(AdicionarAcaoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var acao = new Acao(request.Codigo, request.RazaoSocial);
           
            if (await _acaoRepository.VerificaCodigoJaCadastrado(acao.Codigo))
            {
                AdicionarErro("Código informado já consta no sistema!");
                return ValidationResult;
            }

            _acaoRepository.Adicionar(acao);

            //Evento
            acao.AdicionarEvento(new AcaoAdicionadaEvent
                (acao.Id, acao.DataDeCadastro, acao.Codigo, acao.RazaoSocial));
            
            return await PersistirDados(_acaoRepository.UnitOfWork); ;
        }               

        public void Dispose()
        {
            _acaoRepository?.Dispose();
        }

    }
}
