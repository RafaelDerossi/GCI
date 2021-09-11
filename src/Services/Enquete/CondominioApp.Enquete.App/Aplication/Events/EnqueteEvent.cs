using CondominioApp.Core.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CondominioApp.Enquetes.App.Aplication.Events
{
    public abstract class EnqueteEvent : Event
    {
        public Guid Id { get; protected set; }

        public string Descricao { get; protected set; }

        public DateTime DataInicio { get; protected set; }

        public DateTime DataFim { get; protected set; }


        public Guid CondominioId { get; protected set; }
        public string CondominioNome { get; protected set; }

        public bool ApenasProprietarios { get; protected set; }

        public Guid UsuarioId { get; protected set; }
        public string UsuarioNome { get; protected set; }

        public IEnumerable<string> Alternativas { get; protected set; }      

        
    }
}
