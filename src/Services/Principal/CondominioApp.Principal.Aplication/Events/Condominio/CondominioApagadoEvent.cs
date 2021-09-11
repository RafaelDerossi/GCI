using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Events
{
   public class CondominioApagadoEvent : CondominioEvent
    {

        public CondominioApagadoEvent(Guid condominioId)
        {
            CondominioId = condominioId;
        }
    }
}
