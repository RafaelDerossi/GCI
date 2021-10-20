using NinjaStore.Core.ValueObjects;
using System;
namespace NinjaStore.Clientes.Aplication.Events
{
    public class ClienteAdicionadoEvent : ClienteEvent
    {

        public ClienteAdicionadoEvent(Guid clienteId, DateTime dataDeCadastro, string nome, Email email, string aldeia)
        {
            AggregateId = clienteId;
            ClienteId = clienteId;
            DataDeCadastro = dataDeCadastro;            
            Nome = nome;
            Email = email;
            Aldeia = aldeia;
        }        
    }
}
