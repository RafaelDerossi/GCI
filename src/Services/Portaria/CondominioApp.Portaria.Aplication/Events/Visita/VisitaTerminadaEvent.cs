using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using CondominioApp.Portaria.ValueObjects;
using System;

namespace CondominioApp.Portaria.Aplication.Events
{
   public class VisitaTerminadaEvent : VisitaEvent
    {

        public VisitaTerminadaEvent(Guid id, DateTime dataDeSaida)
        {
            Id = id;
            DataDeSaida = DataDeSaida;
        }

    }
}
