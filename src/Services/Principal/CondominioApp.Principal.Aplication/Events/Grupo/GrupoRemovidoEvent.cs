using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Events
{
    public class GrupoRemovidoEvent : GrupoEvent
    {
        public GrupoRemovidoEvent(Guid grupoId)
        {  
            GrupoId = grupoId;
        }
    }
}
