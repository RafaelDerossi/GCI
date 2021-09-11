﻿using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
   public class ReservaReprovadaAutomaticamenteEvent : ReservaEvent
    {

        public ReservaReprovadaAutomaticamenteEvent
              (Guid reservaId, string justificativa, string observacao)
        {
            Id = reservaId;
            Justificativa = justificativa;
            Observacao = observacao;
        }

    }
}