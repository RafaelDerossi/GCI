using GCI.Core.Messages.CommonMessages;
using System;

namespace GCI.Core.Messages.Events.Pedidos
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
