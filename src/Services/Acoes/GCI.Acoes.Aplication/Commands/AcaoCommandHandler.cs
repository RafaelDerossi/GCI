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
         IRequestHandler<AdicionarOperacaoCommand, ValidationResult>,
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


        public async Task<ValidationResult> Handle(AdicionarOperacaoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var operacao = new Operacao
                (request.CodigoDaAcao, request.Preco, request.Quantidade,
                 request.DataDaOperacao, request.Tipo);            

            _acaoRepository.AdicionarOperacao(operacao);

            //Evento
            operacao.AdicionarEvento(new OperacaoAdicionadaEvent
                (operacao.Id, operacao.DataDeCadastro, operacao.CodigoDaAcao,
                 operacao.Preco, operacao.Quantidade, operacao.DataDaOperacao,
                 operacao.CustoDaOperacao, operacao.ValorTotal, operacao.Tipo));

            return await PersistirDados(_acaoRepository.UnitOfWork); ;
        }


        public void Dispose()
        {
            _acaoRepository?.Dispose();
        }

    }
}
