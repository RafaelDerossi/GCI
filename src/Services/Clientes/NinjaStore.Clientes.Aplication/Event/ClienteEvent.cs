﻿using NinjaStore.Clientes.Domain.ValueObjects;
using NinjaStore.Core.Messages;

namespace NinjaStore.Clientes.Aplication.Events
{
    public abstract class ClienteEvent : Event
    {
        public System.Guid Id { get; protected set; }

        public string Nome { get; protected set; }        

        public Email Email { get; protected set; }

        public string Aldeia { get; protected set; }

    }
}
