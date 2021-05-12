using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
    public class AreaComumApagadaEvent : AreaComumEvent
    {
        public AreaComumApagadaEvent(Guid areaComumId)
        {
            Id = areaComumId;           
        }        
    }
}
