using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Principal.Domain.ValueObjects;

namespace CondominioApp.Principal.Aplication.Events
{
    public class LogoDoCondominioAtualizadoEvent : CondominioEvent
    {
      
        public LogoDoCondominioAtualizadoEvent(Guid id, Foto logoMarca)            
        {
            CondominioId = id;            
            LogoMarca = logoMarca;            
        }


    }
}