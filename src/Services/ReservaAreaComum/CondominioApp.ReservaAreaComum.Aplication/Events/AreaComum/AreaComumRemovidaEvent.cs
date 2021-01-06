using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
    public class AreaComumRemovidaEvent : AreaComumEvent
    {
        public AreaComumRemovidaEvent(Guid areaComumId)
        {
            Id = areaComumId;           
        }        
    }
}
