using System;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class MoradorExcluidoEvent : MoradorEvent
    {        
        public MoradorExcluidoEvent(Guid id)
        {
            Id = id;
        }
    }
}