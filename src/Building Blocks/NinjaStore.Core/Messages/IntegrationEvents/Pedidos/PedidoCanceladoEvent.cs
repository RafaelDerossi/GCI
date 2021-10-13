using NinjaStore.Core.Enumeradores;
using NinjaStore.Core.Messages.DTO;
using System;
using System.Collections.Generic;

namespace NinjaStore.Core.Messages.IntegrationEvents.Pedidos
{
    public class PedidoCanceladoEvent : PedidoEvent
    {
        public PedidoCanceladoEvent(Guid id, string justificativa)
        {
            AggregateId = id;
            Id = id;
            Justificativa = justificativa;
        }        
    }
}
