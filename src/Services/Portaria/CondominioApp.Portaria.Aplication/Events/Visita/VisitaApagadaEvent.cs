﻿using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using CondominioApp.Portaria.Domain.ValueObjects;
using System;

namespace CondominioApp.Portaria.Aplication.Events
{
   public class VisitaApagadaEvent : VisitaEvent
    {

        public VisitaApagadaEvent(Guid id)
        {
            Id = id;
        }

    }
}