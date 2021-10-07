using MediatR;
using NinjaStore.Core.Helpers;
using System;

namespace NinjaStore.Core.Messages
{
    public abstract class DomainEvent : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected DomainEvent()
        {
            Timestamp = DataHoraDeBrasilia.Get();
        }
    }
}
