using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Events
{
   public class CondominioRemovidoEvent : CondominioEvent
    {

        public CondominioRemovidoEvent(Guid condominioId, DateTime dataDeAlteracao)
        {
            CondominioId = condominioId;
            DataDeAlteracao = dataDeAlteracao;
        }
    }
}
