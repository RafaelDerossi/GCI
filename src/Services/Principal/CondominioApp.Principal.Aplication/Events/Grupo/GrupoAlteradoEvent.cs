using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Events
{
    public class GrupoAlteradoEvent : GrupoEvent
    {

        public GrupoAlteradoEvent(Guid grupoId, DateTime dataDeAlteracao, string descricao)
        {
            DataDeAlteracao = dataDeAlteracao;
            Descricao = descricao;
            GrupoId = grupoId;
        }
    }
}
