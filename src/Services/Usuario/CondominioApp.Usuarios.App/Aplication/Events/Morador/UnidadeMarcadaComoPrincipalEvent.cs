using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.ValueObjects;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class UnidadeMarcadaComoPrincipalEvent : MoradorEvent
    {        
        public UnidadeMarcadaComoPrincipalEvent(Guid id)
        {
            Id = id;
        }
    }
}