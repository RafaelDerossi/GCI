using System;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class MarcadoComoProprietarioEvent : MoradorEvent
    {        
        public MarcadoComoProprietarioEvent(Guid id)
        {
            Id = id;
        }
    }
}