using GCI.Core.Messages.CommonMessages;
using System;
namespace GCI.Core.Messages.Events.Pedidos
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
