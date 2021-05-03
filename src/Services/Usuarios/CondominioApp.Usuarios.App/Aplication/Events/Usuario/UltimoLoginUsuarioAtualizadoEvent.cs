using System;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class UltimoLoginUsuarioAtualizadoEvent : UsuarioEvent
    {        
        public UltimoLoginUsuarioAtualizadoEvent(Guid usuarioId, DateTime? dataUltimoLogin)
        {            
            UsuarioId = usuarioId;
            DataUltimoLogin = dataUltimoLogin;
        }
    }
}