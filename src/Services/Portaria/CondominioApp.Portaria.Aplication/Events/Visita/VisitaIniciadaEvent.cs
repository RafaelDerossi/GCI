using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using CondominioApp.Portaria.Domain.ValueObjects;
using System;

namespace CondominioApp.Portaria.Aplication.Events
{
   public class VisitaIniciadaEvent : VisitaEvent
    {

        public VisitaIniciadaEvent(Guid id, DateTime dataDeEntrada)
        {
            Id = id;
            DataDeEntrada = dataDeEntrada;
        }

    }
}
