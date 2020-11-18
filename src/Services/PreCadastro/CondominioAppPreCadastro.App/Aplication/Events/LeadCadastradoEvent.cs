using CondominioApp.Core.Messages;
using CondominioAppPreCadastro.App.Models;

namespace CondominioAppPreCadastro.App.Aplication.Events
{
    public class LeadCadastradoEvent : Event
    {
        public Lead Lead { get; private set; }

        public LeadCadastradoEvent(Lead lead)
        {
            Lead = lead;
        }

    }
}