using NinjaStore.Clientes.Domain.FlatModel;
using NinjaStore.Clientes.Domain.Interfaces;
using System.Threading.Tasks;
using Rebus.Handlers;
using NinjaStore.Core.Messages.CommonHandlers;

namespace NinjaStore.Clientes.Aplication.Events
{
    public class ClienteEventHandler : EventHandler,
         IHandleMessages<ClienteAdicionadoEvent>,
         System.IDisposable
    {

        private readonly IClienteQueryRepository _clienteQueryRepository;        

        public ClienteEventHandler(IClienteQueryRepository clienteQueryRepository)
        {
            _clienteQueryRepository = clienteQueryRepository;            
        }

        public async Task Handle(ClienteAdicionadoEvent message)
        {
            var clienteFlat = new ClienteFlat
                (message.Id, message.Nome, message.Email, message.Aldeia);
           
            _clienteQueryRepository.Adicionar(clienteFlat);
           
            await PersistirDados(_clienteQueryRepository.UnitOfWork);            
        }
               

        public void Dispose()
        {
            _clienteQueryRepository?.Dispose();
        }

    }
}
