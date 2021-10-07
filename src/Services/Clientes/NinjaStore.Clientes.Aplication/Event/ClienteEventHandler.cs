using MediatR;
using NinjaStore.Core.Messages;
using NinjaStore.Clientes.Domain.FlatModel;
using NinjaStore.Clientes.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Rebus.Bus;
using Rebus.Handlers;

namespace NinjaStore.Clientes.Aplication.Events
{
    public class ClienteEventHandler : CommandHandler,
         IHandleMessages<ClienteAdicionadoEvent>,
         System.IDisposable
    {

        private readonly IClienteQueryRepository _clienteQueryRepository;
        private readonly IBus _bus;

        public ClienteEventHandler(IClienteQueryRepository clienteQueryRepository, IBus bus)
        {
            _clienteQueryRepository = clienteQueryRepository;
            _bus = bus;
        }

        public async Task Handle(ClienteAdicionadoEvent notification)
        {
            var clienteFlat = new ClienteFlat
                (notification.Id, notification.Nome, notification.Email, notification.Aldeia);
           
            _clienteQueryRepository.Adicionar(clienteFlat);
           
            await PersistirDados(_clienteQueryRepository.UnitOfWork);
        }
               

        public void Dispose()
        {
            _clienteQueryRepository?.Dispose();
        }

    }
}
