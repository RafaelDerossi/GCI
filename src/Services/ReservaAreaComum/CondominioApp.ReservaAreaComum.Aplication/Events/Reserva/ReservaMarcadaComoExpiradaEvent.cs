using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
   public class ReservaMarcadaComoExpiradaEvent : ReservaEvent
    {

        public ReservaMarcadaComoExpiradaEvent
            (Guid reservaId, string justificativa, string observacao)
        {            
            Id = reservaId;
            Justificativa = justificativa;
            Observacao = observacao;
        }

    }
}
