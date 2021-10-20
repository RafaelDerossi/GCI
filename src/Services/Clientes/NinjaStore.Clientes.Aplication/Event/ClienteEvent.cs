using NinjaStore.Core.ValueObjects;
using NinjaStore.Core.Messages.CommonMessages;

namespace NinjaStore.Clientes.Aplication.Events
{
    public abstract class ClienteEvent : Event
    {
        public System.Guid ClienteId { get; protected set; }

        public System.DateTime DataDeCadastro { get; protected set; }

        public System.DateTime DataDeAlteracao { get; protected set; }

        public string Nome { get; protected set; }        

        public Email Email { get; protected set; }

        public string Aldeia { get; protected set; }

    }
}
