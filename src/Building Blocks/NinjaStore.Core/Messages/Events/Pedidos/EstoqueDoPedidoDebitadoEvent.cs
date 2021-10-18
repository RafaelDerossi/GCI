using NinjaStore.Core.Messages.CommonMessages;
using System;
namespace NinjaStore.Core.Messages.Events.Pedidos
{
    public class EstoqueDoPedidoDebitadoEvent : Event
    {
        public Guid PedidoId { get; protected set; }        

        public EstoqueDoPedidoDebitadoEvent
            (Guid pedidoId)
        {
            AggregateId = pedidoId;
            PedidoId = pedidoId;            
        }        
    }
}
