using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Events
{
    public class GrupoApagadoEvent : GrupoEvent
    {
        public GrupoApagadoEvent(Guid grupoId)
        {  
            GrupoId = grupoId;
        }
    }
}
