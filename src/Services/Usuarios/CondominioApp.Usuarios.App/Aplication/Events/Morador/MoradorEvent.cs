using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.ValueObjects;
using System;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class MoradorEvent : Core.Messages.Event
    {
        public Guid Id { get; set; }

        public Guid UsuarioId { get; set; }
        
        public Guid UnidadeId { get; protected set; }

        public string NumeroUnidade { get; protected set; }

        public string AndarUnidade { get; protected set; }

        public string GrupoUnidade { get; protected set; }

        public Guid CondominioId { get; protected set; }

        public string NomeCondominio { get; protected set; }

        public bool Proprietario { get; protected set; }

        public bool Principal { get; protected set; }
        
    }
}