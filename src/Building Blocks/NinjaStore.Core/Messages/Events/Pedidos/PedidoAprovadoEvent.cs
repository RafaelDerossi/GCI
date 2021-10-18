using NinjaStore.Core.Messages.CommonMessages;
using System;

namespace NinjaStore.Core.Messages.Events.Pedidos
{
    public class PedidoAprovadoEvent : Event
    {
        public Guid PedidoId { get; protected set; }

        public PedidoAprovadoEvent(Guid pedidoId)
        {
            AggregateId = pedidoId;
            PedidoId = pedidoId;            
        }        
    }
}
