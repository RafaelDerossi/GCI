using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
   public class ReservaRetiradaDaFilaEvent : ReservaEvent
    {

        public ReservaRetiradaDaFilaEvent
            (Guid reservaId,StatusReserva status, string justificativa, string observacao)
        {            
            Id = reservaId;
            Status = status;
            Justificativa = justificativa;
            Observacao = observacao;
        }

    }
}
