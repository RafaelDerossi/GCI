using System;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class FuncionarioDesativadoEvent : FuncionarioEvent
    {        
        public FuncionarioDesativadoEvent(Guid id)
        {
            Id = id;                        
        }
    }
}