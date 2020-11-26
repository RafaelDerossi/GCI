using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Events
{
    public class CodigoUnidadeResetadoEvent : UnidadeEvent
    {
        public CodigoUnidadeResetadoEvent(Guid id, DateTime dataDeAlteracao, string unidadeCodigo)
        {
            UnidadeId = id;
            DataDeAlteracao = dataDeAlteracao;           
            Codigo = unidadeCodigo;                
        }

    }
}
