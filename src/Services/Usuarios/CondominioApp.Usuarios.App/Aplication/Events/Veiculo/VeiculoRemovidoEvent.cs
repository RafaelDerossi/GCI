using System;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class VeiculoRemovidoEvent : VeiculoEvent
    {        
        public VeiculoRemovidoEvent(
            Guid veiculoId, Guid condominioId)
        {            
            VeiculoId = veiculoId;
            CondominioId = condominioId;            
        }
    }
}