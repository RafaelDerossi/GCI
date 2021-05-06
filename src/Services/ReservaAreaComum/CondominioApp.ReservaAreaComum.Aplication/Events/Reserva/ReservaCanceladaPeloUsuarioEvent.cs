using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
   public class ReservaCanceladaPeloUsuarioEvent : ReservaEvent
    {
        public ReservaCanceladaPeloUsuarioEvent
              (Guid reservaId, string justificativa, string observacao, Guid moradorId,
               string nomeMorador, string origem)
        {
            Id = reservaId;
            Justificativa = justificativa;
            Observacao = observacao;
            MoradorId = moradorId;
            NomeMorador = nomeMorador;
            Origem = origem;
        }

    }
}
