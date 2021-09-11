using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Events
{
    public class GrupoEditadoEvent : GrupoEvent
    {

        public GrupoEditadoEvent(Guid grupoId, string descricao)
        {           
            Descricao = descricao;
            GrupoId = grupoId;
        }
    }
}
