using System;

namespace CondominioApp.Portaria.Aplication.Events
{
   public class VisitaTerminadaEvent : VisitaEvent
    {

        public VisitaTerminadaEvent(Guid id, DateTime dataDeSaida)
        {
            Id = id;
            DataDeSaida = dataDeSaida;
        }

    }
}
