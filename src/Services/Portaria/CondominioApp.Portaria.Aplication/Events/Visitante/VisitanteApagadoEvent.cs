using System;

namespace CondominioApp.Portaria.Aplication.Events
{
   public class VisitanteApagadoEvent : VisitanteEvent
    {
        public VisitanteApagadoEvent(Guid id)
        {
            Id = id;
        }

    }
}
