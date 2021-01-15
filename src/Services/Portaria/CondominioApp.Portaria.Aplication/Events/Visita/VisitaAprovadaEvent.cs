using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using CondominioApp.Portaria.ValueObjects;
using System;

namespace CondominioApp.Portaria.Aplication.Events
{
   public class VisitaAprovadaEvent : VisitaEvent
    {

        public VisitaAprovadaEvent(Guid id)
        {
            Id = id;
        }

    }
}
