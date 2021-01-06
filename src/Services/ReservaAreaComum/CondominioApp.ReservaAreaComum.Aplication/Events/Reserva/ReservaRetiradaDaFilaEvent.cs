using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
   public class ReservaRetiradaDaFilaEvent : ReservaEvent
    {

        public ReservaRetiradaDaFilaEvent
            (Guid reservaId)
        {            
            Id = reservaId;
        }

    }
}
