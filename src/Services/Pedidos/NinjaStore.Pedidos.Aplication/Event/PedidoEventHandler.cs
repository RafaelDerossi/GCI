using NinjaStore.Core.Data;
using NinjaStore.Core.Messages.CommonHandlers;
using NinjaStore.Core.Messages.Events.Pedidos;
using NinjaStore.Pedidos.Aplication.Commands;
using NinjaStore.Pedidos.Domain.FlatModel;
using NinjaStore.Pedidos.Domain.Interfaces;
using Rebus.Bus;
using Rebus.Handlers;
using System.Threading;
using System.Threading.Tasks;

namespace NinjaStore.Pedidos.Aplication.Events
{
    public class PedidoEventHandler : EventHandler,
         IHandleMessages<PedidoAdicionadoEvent>,
         IHandleMessages<EstoqueDoPedidoInsuficienteEvent>,
         IHandleMessages<EstoqueDoPedidoDebitadoEvent>,
         IHandleMessages<PedidoAprovadoEvent>,
         IHandleMessages<PedidoCanceladoEvent>,
         System.IDisposable
    {
        private readonly IMongoRepository<PedidoFlat> _pedidoFlatRepository;        
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IBus _bus;

        public PedidoEventHandler
            (IMongoRepository<PedidoFlat> pedidoFlatRepository,
             IPedidoRepository pedidoRepository, IBus bus)
        {
            _pedidoFlatRepository = pedidoFlatRepository;
            _pedidoRepository = pedidoRepository;
            _bus = bus;
        }

        public async Task Handle(PedidoAdicionadoEvent message)
        {
            var pedidoFlat = new PedidoFlat
                (message.PedidoId, message.DataDeCadastro, message.Numero, message.Status,
                 message.Valor, message.Desconto, message.ValorTotal, message.Cliente.Id,
                 message.Cliente.Nome, message.Cliente.Email, message.Cliente.Aldeia);

            foreach (var item in message.Produtos)
            {                
                pedidoFlat.AdicionarProduto(new ProdutoDoPedidoFlat(item.Id, item.ProdutoId, 
                                                                    item.Descricao, item.Foto, 
                                                                    item.Valor, item.Quantidade,
                                                                    item.Desconto, item.ValorTotal));

            }

            pedidoFlat.SetNumero(await _pedidoRepository.ObterNumeroDoPedidoPorId(pedidoFlat.PedidoId));

            await _pedidoFlatRepository.AdicionarAsync(pedidoFlat);            
        }               

        
        public Task Handle(EstoqueDoPedidoInsuficienteEvent message)
        {
            _bus.Send(new CancelarPedidoCommand(message.PedidoId, $"Estoque do produto {message.Descricao} não disponível!")).Wait();

            return Task.CompletedTask;
        }


        public async Task Handle(EstoqueDoPedidoDebitadoEvent message)
        {
            await _bus.Send(new AprovarPedidoCommand(message.PedidoId));
        }


        public async Task Handle(PedidoAprovadoEvent message)
        {
            var pedidoFlat = await _pedidoFlatRepository.ObterDocumentoAsync(x => x.PedidoId == message.PedidoId);
            if (pedidoFlat == null)
                return;

            pedidoFlat.AprovarPedido();

            await _pedidoFlatRepository.AtualizarAsync(pedidoFlat);
        }


        public async Task Handle(PedidoCanceladoEvent message)
        {
            var pedidoFlat = await _pedidoFlatRepository.ObterDocumentoAsync(x => x.PedidoId == message.PedidoId);
            if (pedidoFlat == null)
                return;

            pedidoFlat.CancelarPedido(message.Justificativa);

            await _pedidoFlatRepository.AtualizarAsync(pedidoFlat);
        }


        public void Dispose()
        {
            _pedidoRepository?.Dispose();
        }
    }
}
