using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
    public class AreaComumDesativadaEvent : AreaComumEvent
    {
        public AreaComumDesativadaEvent(Guid areaComumId)
        {
            Id = areaComumId;           
        }        
    }
}
