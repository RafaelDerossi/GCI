using CondominioApp.Core.Messages;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
    public abstract class GrupoCommand : Command
    {
        public Guid GrupoId { get; protected set; }

        public string Descricao { get; protected set; }

        public Guid CondominioId { get; protected set; }

    }
}
