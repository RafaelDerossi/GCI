using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using CondominioApp.Portaria.ValueObjects;
using System;

namespace CondominioApp.Portaria.Aplication.Events
{
   public class VisitaReprovadaEvent : VisitaEvent
    {

        public VisitaReprovadaEvent(Guid id)
        {
            Id = id;
        }

    }
}
