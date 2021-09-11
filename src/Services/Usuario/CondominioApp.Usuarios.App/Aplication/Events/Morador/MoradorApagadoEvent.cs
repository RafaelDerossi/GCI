using System;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class MoradorApagadoEvent : MoradorEvent
    {        
        public MoradorApagadoEvent(Guid id)
        {
            Id = id;
        }
    }
}