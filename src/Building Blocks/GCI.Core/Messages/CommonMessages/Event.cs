using System;
using GCI.Core.Helpers;
using MediatR;

namespace GCI.Core.Messages.CommonMessages
{
    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DataHoraDeBrasilia.Get();
        }
    }
}