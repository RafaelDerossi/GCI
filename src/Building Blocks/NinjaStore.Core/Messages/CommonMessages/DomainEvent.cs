using MediatR;
using GCI.Core.Helpers;
using System;

namespace GCI.Core.Messages.CommonMessages
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
