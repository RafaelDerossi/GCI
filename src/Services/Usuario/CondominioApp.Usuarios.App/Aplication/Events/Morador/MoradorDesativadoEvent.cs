using System;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class MoradorDesativadoEvent : MoradorEvent
    {        
        public MoradorDesativadoEvent(Guid id)
        {
            Id = id;
        }
    }
}