using CondominioApp.Core.Messages;
using CondominioApp.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Aplication.Commands
{
    public abstract class GrupoCommand : Command
    {
        public Guid GrupoId { get; protected set; }

        public string Descricao { get; protected set; }

        public Guid CondominioId { get; protected set; }

    }
}
