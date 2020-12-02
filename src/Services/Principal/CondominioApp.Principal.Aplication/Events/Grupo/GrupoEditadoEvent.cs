using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Events
{
    public class GrupoEditadoEvent : GrupoEvent
    {

        public GrupoEditadoEvent(Guid grupoId, DateTime dataDeAlteracao, string descricao)
        {
            DataDeAlteracao = dataDeAlteracao;
            Descricao = descricao;
            GrupoId = grupoId;
        }
    }
}
