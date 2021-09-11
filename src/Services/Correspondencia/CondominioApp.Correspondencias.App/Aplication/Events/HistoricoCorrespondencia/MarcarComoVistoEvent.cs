using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.Correspondencias.Aplication.Events
{
   public class MarcarComoVistoEvent : HistoricoCorrespondenciaEvent
    {
        public MarcarComoVistoEvent
            (Guid correspondenciaId)
        {
            CorrespondenciaId = correspondenciaId;            
        }

    }
}
