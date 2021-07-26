using System;
using CondominioApp.Core.Enumeradores;

namespace CondominioApp.Principal.Aplication.Events
{
    public class ContratoApagadoEvent : CondominioEvent
    {      
        public ContratoApagadoEvent(Guid contratoId)
        {
            ContratoId = contratoId;
        }
    }
}