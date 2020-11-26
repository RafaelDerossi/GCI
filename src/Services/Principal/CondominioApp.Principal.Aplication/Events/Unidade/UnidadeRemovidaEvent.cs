using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Events
{
    public class UnidadeRemovidaEvent : UnidadeEvent
    {
        public UnidadeRemovidaEvent(Guid unidadeId, DateTime dataDeAlteracao)
        {  
            UnidadeId = unidadeId;
            DataDeAlteracao = dataDeAlteracao;
        }
    }
}
