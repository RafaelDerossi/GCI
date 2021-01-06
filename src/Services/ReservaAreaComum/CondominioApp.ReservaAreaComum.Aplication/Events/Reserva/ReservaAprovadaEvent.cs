using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
   public class ReservaAprovadaEvent : ReservaEvent
    {

        public ReservaAprovadaEvent
            (Guid reservaId)
        {            
            Id = reservaId;
        }

    }
}
