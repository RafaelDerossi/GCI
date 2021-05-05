using System;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class MoradorAtivadoEvent : MoradorEvent
    {        
        public MoradorAtivadoEvent(Guid id)
        {
            Id = id;
        }
    }
}