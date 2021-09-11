﻿using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
   public class ReservaReprovadaPelaAdmEvent : ReservaEvent
    {

        public ReservaReprovadaPelaAdmEvent
              (Guid reservaId, string justificativa, string observacao,
               Guid funcionarioId, string nomeFuncionario, string origem)
        {
            Id = reservaId;
            Justificativa = justificativa;
            Observacao = observacao;
            FuncionarioId = funcionarioId;
            NomeFuncionario = nomeFuncionario;
            Origem = origem;
        }

    }
}