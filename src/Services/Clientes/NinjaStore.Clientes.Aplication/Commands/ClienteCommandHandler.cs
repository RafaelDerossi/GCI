using FluentValidation.Results;
using MediatR;
using NinjaStore.Core.Messages;
using NinjaStore.Clientes.Aplication.Events;
using NinjaStore.Clientes.Domain;
using NinjaStore.Clientes.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NinjaStore.Clientes.Aplication.Commands
{
    public class ClienteCommandHandler : CommandHandler,
         IRequestHandler<AdicionarClienteCommand, ValidationResult>,
         IDisposable
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }


        public async Task<ValidationResult> Handle(AdicionarClienteCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var produto = new Cliente(request.Nome, request.Email, request.Aldeia);
           
            _clienteRepository.Adicionar(produto);

            //Evento
            produto.AdicionarEvento
                (new ClienteAdicionadoEvent
                (produto.Id, produto.Nome, produto.Email, produto.Aldeia));

            return await PersistirDados(_clienteRepository.UnitOfWork);
        }
               

        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }

    }
}
