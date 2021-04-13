using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
   public class ReservaAguardandoAprovacaoEvent : ReservaEvent
    {

        public ReservaAguardandoAprovacaoEvent
            (Guid reservaId, string justificativa)
        {            
            Id = reservaId;
            Justificativa = justificativa;
        }

    }
}
