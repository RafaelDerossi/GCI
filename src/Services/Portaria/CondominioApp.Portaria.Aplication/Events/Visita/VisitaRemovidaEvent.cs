using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using CondominioApp.Portaria.ValueObjects;
using System;

namespace CondominioApp.Portaria.Aplication.Events
{
   public class VisitaRemovidaEvent : VisitaEvent
    {

        public VisitaRemovidaEvent(Guid id)
        {
            Id = id;
        }

    }
}
