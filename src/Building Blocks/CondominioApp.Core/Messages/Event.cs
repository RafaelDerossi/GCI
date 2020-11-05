using System;
using CondominioApp.Core.Helpers;

namespace CondominioApp.Core.Messages
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