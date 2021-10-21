using NinjaStore.Clientes.Domain.FlatModel;
using System.Threading.Tasks;
using Rebus.Handlers;
using NinjaStore.Core.Messages.CommonHandlers;
using NinjaStore.Core.Data;

namespace NinjaStore.Clientes.Aplication.Events
{
    public class ClienteEventHandler : EventHandler,
         IHandleMessages<ClienteAdicionadoEvent>,
         System.IDisposable
    {        
        private readonly IMongoRepository<ClienteFlat> _clienteFlatRepository;

        public ClienteEventHandler(IMongoRepository<ClienteFlat> clienteFlatRepository)
        {
            _clienteFlatRepository = clienteFlatRepository;
        }

        public async Task Handle(ClienteAdicionadoEvent message)
        {
            var clienteFlat = new ClienteFlat
                (message.ClienteId, message.DataDeCadastro, message.Nome, message.Email, message.Aldeia);

            await _clienteFlatRepository.AdicionarAsync(clienteFlat);            
        }
               

        public void Dispose()
        {            
        }

    }
}
