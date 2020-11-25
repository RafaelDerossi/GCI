using CondominioApp.Core.Messages;
using System;

namespace CondominioApp.Principal.Aplication.Events
{
    public abstract class GrupoEvent : Event
    {
        public Guid GrupoId { get; protected set; }

        public DateTime DataDeCadastro { get; protected set; }

        public DateTime DataDeAlteracao { get; protected set; }

        public bool Lixeira { get; protected set; }

        public string Descricao { get; protected set; }

        public Guid CondominioId { get; protected set; }

        public string CondominioCnpj { get; protected set; }

        public string CondominioNome { get; protected set; }

        public string CondominioLogoMarca { get; protected set; }
    }
}
