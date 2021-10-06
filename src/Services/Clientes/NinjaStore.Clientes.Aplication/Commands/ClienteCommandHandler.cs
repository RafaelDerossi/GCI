using FluentValidation.Results;
using MediatR;
using NinjaStore.Core.Messages;
using NinjaStore.Clientes.Aplication.Events;
using NinjaStore.Clientes.Domain;
using NinjaStore.Clientes.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using Rebus.Bus;

namespace NinjaStore.Clientes.Aplication.Commands
{
    public class ClienteCommandHandler : CommandHandler,
         IRequestHandler<AdicionarClienteCommand, ValidationResult>,
         IDisposable
    {

        private readonly IClienteRepository _clienteRepository;
        private readonly IBus _bus;

        public ClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }


        public async Task<ValidationResult> Handle(AdicionarClienteCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var cliente = new Cliente(request.Nome, request.Email, request.Aldeia);
           
            if (await _clienteRepository.VerificaEmailJaCadastrado(cliente.Email.Endereco))
            {
                AdicionarErro("E-mail informado já consta no sistema! Informe outro e-mail.");
                return ValidationResult;
            }

            _clienteRepository.Adicionar(cliente);            

            var retorno = await PersistirDados(_clienteRepository.UnitOfWork);
            if (!retorno.IsValid)
                return retorno;

            //Evento            
            _bus.Publish(new ClienteAdicionadoEvent
                (cliente.Id, cliente.Nome, cliente.Email, cliente.Aldeia)).Wait();

            return retorno;
        }
               

        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }

    }
}
