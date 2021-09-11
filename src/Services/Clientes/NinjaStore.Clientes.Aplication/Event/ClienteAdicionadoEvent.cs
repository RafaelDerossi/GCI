using NinjaStore.Clientes.Domain.ValueObjects;
using System;
namespace NinjaStore.Clientes.Aplication.Events
{
    public class ClienteAdicionadoEvent : ClienteEvent
    {

        public ClienteAdicionadoEvent(Guid id, string nome, Email email, string aldeia)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Aldeia = aldeia;
        }        
    }
}
