using System;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class FuncionarioAtivadoEvent : FuncionarioEvent
    {        
        public FuncionarioAtivadoEvent(Guid id)
        {
            Id = id;                        
        }
    }
}