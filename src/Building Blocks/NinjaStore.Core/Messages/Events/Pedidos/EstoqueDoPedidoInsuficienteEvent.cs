using GCI.Core.Messages.CommonMessages;
using System;
namespace GCI.Core.Messages.Events.Pedidos
{
    public class EstoqueDoPedidoInsuficienteEvent : Event
    {
        public Guid PedidoId { get; protected set; }

        public Guid ProdutoId { get; protected set; }

        public string Descricao { get; protected set; }

        public EstoqueDoPedidoInsuficienteEvent
            (Guid pedidoId, Guid produtoId, string descricao)
        {
            AggregateId = pedidoId;
            PedidoId = pedidoId;
            ProdutoId = produtoId;
            Descricao = descricao;
        }        
    }
}
