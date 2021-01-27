using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Principal.Domain.ValueObjects;

namespace CondominioApp.Principal.Aplication.Events
{
    public class ContratoRemovidoEvent : ContratoEvent
    {      
        public ContratoRemovidoEvent(Guid id)            
        {
            Id = id;
        }

    }
}