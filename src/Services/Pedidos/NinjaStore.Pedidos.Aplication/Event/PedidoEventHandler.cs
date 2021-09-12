﻿using MediatR;
using NinjaStore.Core.Messages;
using NinjaStore.Pedidos.Domain.FlatModel;
using NinjaStore.Pedidos.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NinjaStore.Pedidos.Aplication.Events
{
    public class PedidoEventHandler : CommandHandler,
         INotificationHandler<PedidoAdicionadoEvent>,
         System.IDisposable
    {

        private readonly IPedidoQueryRepository _pedidoQueryRepository;
        private readonly IPedidoRepository _pedidoRepository;
        public PedidoEventHandler(IPedidoQueryRepository pedidoQueryRepository, IPedidoRepository pedidoRepository)
        {
            _pedidoQueryRepository = pedidoQueryRepository;
            _pedidoRepository = pedidoRepository;
        }


        public async Task Handle(PedidoAdicionadoEvent notification, CancellationToken cancellationToken)
        {
            var pedidoFlat = new PedidoFlat
                (notification.Id, notification.Numero, notification.Valor,
                 notification.Desconto, notification.ValorTotal, notification.Cliente.Id,
                 notification.Cliente.Nome, notification.Cliente.Email, notification.Cliente.Aldeia);

            foreach (var item in notification.Produtos)
            {
                var produtoFlat = new ProdutoDoPedidoFlat
                    (item.Id, item.ProdutoId, item.Descricao, item.Foto, item.Valor, item.Desconto,
                     item.ValorTotal);
                pedidoFlat.AdicionarProduto(produtoFlat);
            }

            pedidoFlat.SetNumero(await _pedidoRepository.ObterNumeroDoPedidoPorId(pedidoFlat.Id));

            _pedidoQueryRepository.Adicionar(pedidoFlat);
           
            await PersistirDados(_pedidoQueryRepository.UnitOfWork);
        }
               

        public void Dispose()
        {
            _pedidoQueryRepository?.Dispose();
        }

    }
}