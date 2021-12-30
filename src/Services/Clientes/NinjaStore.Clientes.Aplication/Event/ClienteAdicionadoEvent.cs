using GCI.Core.ValueObjects;
using System;
namespace GCI.Acoes.Aplication.Events
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
