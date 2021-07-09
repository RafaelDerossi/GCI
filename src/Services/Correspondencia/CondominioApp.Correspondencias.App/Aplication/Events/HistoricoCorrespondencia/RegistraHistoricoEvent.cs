using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.Correspondencias.Aplication.Events
{
   public class RegistraHistoricoEvent : HistoricoCorrespondenciaEvent
    {
        public RegistraHistoricoEvent
            (Guid correspondenciaId, AcoesCorrespondencia acao, Guid funcionarioId,
             string nomeFuncionario, bool visto)
        {
            CorrespondenciaId = correspondenciaId;
            Acao = acao;
            FuncionarioId = funcionarioId;
            NomeFuncionario = nomeFuncionario;
            Visto = visto;
        }

    }
}
