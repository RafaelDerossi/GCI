using System;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class DesmarcadoComoProprietarioEvent : MoradorEvent
    {        
        public DesmarcadoComoProprietarioEvent(Guid id)
        {
            Id = id;
        }
    }
}