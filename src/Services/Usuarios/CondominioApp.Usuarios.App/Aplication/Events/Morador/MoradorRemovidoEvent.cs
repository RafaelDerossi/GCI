using System;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class MoradorRemovidoEvent : MoradorEvent
    {        
        public MoradorRemovidoEvent(Guid id)
        {
            Id = id;
        }
    }
}