using System;

namespace CondominioApp.Portaria.Aplication.Events
{
   public class VisitanteRemovidoEvent : VisitanteEvent
    {
        public VisitanteRemovidoEvent(Guid id)
        {
            Id = id;
        }

    }
}
