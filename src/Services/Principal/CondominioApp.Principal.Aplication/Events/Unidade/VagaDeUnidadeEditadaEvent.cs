using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Events
{
    public class VagaDeUnidadeEditadaEvent : UnidadeEvent
    {
        public VagaDeUnidadeEditadaEvent(Guid id, int unidadeVagas)
        {
            UnidadeId = id;                   
            Vaga = unidadeVagas;
        }

    }
}
