using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
   public class ReservaReprovadaEvent : ReservaEvent
    {

        public ReservaReprovadaEvent
            (Guid reservaId, string justificativa)
        {            
            Id = reservaId;
            Justificativa = justificativa;
        }

    }
}
