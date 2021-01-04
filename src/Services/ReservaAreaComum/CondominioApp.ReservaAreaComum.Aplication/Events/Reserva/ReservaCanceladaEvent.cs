using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
    public class ReservaCanceladaEvent : ReservaEvent
    {      
        public ReservaCanceladaEvent(Guid reservaCanceladaId)            
        {
            Id = reservaCanceladaId;           
        }
    }
}