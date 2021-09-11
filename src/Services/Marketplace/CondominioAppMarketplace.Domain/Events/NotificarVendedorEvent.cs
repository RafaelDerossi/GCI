using System;
using CondominioApp.Core.Messages.CommonMessages.DomainEvents;

namespace CondominioAppMarketplace.Domain.Events
{
    public class NotificarVendedorEvent : DomainEvent
    {
        public Guid VendedorId { get; private set; }

        public NotificarVendedorEvent(Guid aggregateId, Guid vendedorId)
            : base(aggregateId)
        {
            VendedorId = vendedorId;
        }
    }
}