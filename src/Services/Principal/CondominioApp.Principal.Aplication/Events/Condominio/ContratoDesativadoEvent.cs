using System;
using CondominioApp.Core.Enumeradores;

namespace CondominioApp.Principal.Aplication.Events
{
    public class ContratoDesativadoEvent : CondominioEvent
    {      
        public ContratoDesativadoEvent(Guid contratoId)
        {
            ContratoId = contratoId;
        }
    }
}