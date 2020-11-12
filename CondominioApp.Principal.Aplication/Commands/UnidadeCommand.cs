using CondominioApp.Core.Messages;
using CondominioApp.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Aplication.Commands
{
    public abstract class UnidadeCommand : Command
    {
        public Guid UnidadeId { get; protected set; }

        public string Codigo { get; protected set; }

        public string Numero { get; protected set; }

        public string Andar { get; protected set; }

        public int Vaga { get; protected set; }

        public Telefone Telefone { get; protected set; }

        public string Ramal { get; protected set; }

        public string Complemento { get; protected set; }

        public Guid GrupoId { get; protected set; }

        public Guid CondominioId { get; protected set; }

    }
}
