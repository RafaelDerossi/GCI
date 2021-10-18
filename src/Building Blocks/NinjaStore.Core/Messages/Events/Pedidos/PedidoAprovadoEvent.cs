using NinjaStore.Core.Enumeradores;
using NinjaStore.Core.Messages.DTO;
using System;
using System.Collections.Generic;

namespace NinjaStore.Core.Messages.Events.Pedidos
{
    public class PedidoAprovadoEvent : PedidoEvent
    {
        public PedidoAprovadoEvent(Guid id)
        {
            AggregateId = id;
            Id = id;            
        }        
    }
}
