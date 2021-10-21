using NinjaStore.Core.Data;
using NinjaStore.Core.Messages.CommonHandlers;
using NinjaStore.Core.Messages.Events.Pedidos;
using NinjaStore.Produtos.Aplication.Commands;
using NinjaStore.Produtos.Domain.FlatModel;
using NinjaStore.Produtos.Domain.Interfaces;
using Rebus.Bus;
using Rebus.Handlers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NinjaStore.Produtos.Aplication.Events
{
    public class ProdutoEventHandler : EventHandler,
         IHandleMessages<ProdutoAdicionadoEvent>,
         IHandleMessages<PedidoAdicionadoEvent>,
         IHandleMessages<EstoqueDoProdutoDebitadoEvent>,
         System.IDisposable
    {

        private readonly IMongoRepository<ProdutoFlat> _produtoFlatRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IBus _bus;

        public ProdutoEventHandler(IMongoRepository<ProdutoFlat> produtoFlatRepository, IProdutoRepository produtoRepository, IBus bus)
        {
            _produtoFlatRepository = produtoFlatRepository;
            _produtoRepository = produtoRepository;
            _bus = bus;
        }

        public async Task Handle(ProdutoAdicionadoEvent message)
        {
            var produtoFlat = new ProdutoFlat
                (message.ProdutoId, message.DataDeCadastro, message.Descricao,
                 message.Valor, message.Estoque, message.Foto);
           
            await _produtoFlatRepository.AdicionarAsync(produtoFlat);            
        }

        public async Task Handle(PedidoAdicionadoEvent message)
        {
            var listaComandos = new List<DebitarEstoqueCommand>();
            foreach (var produto in message.Produtos)
            {
                var produtoBD = await _produtoRepository.ObterPorId(produto.ProdutoId);
                if (produtoBD == null || !produtoBD.TemEstoque(produto.Quantidade))
                {
                    _bus.Publish(new EstoqueDoPedidoInsuficienteEvent
                        (message.AggregateId, produto.ProdutoId, produto.Descricao)).Wait();
                    return;
                }

                listaComandos.Add(new DebitarEstoqueCommand(produtoBD.Id, produto.Quantidade));
            }

            foreach (var comando in listaComandos)
            {
                _bus.Send(comando).Wait();
            }

            _bus.Publish(new EstoqueDoPedidoDebitadoEvent(message.PedidoId)).Wait();
        }

        public async Task Handle(EstoqueDoProdutoDebitadoEvent message)
        {
            var produtoFlat = await _produtoFlatRepository.ObterDocumentoAsync(x => x.ProdutoId == message.ProdutoId);
            if (produtoFlat == null)
                return;

            produtoFlat.DebitarEstoque(message.Quantidade);

            await _produtoFlatRepository.AtualizarAsync(produtoFlat);
        }



        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }

    }
}
