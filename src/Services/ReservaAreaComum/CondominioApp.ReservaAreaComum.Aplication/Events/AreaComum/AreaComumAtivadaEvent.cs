using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
    public class AreaComumAtivadaEvent : AreaComumEvent
    {
        public AreaComumAtivadaEvent(Guid areaComumId)
        {
            Id = areaComumId;           
        }        
    }
}
