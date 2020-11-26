using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain.ValueObjects;
using System;

namespace CondominioApp.Principal.Aplication.Events
{
    public abstract class UnidadeEvent : Event
    {
        public Guid UnidadeId { get; protected set; }

        public DateTime DataDeCadastro { get; protected set; }

        public DateTime DataDeAlteracao { get; protected set; }       

        public string Codigo { get; protected set; }

        public string Numero { get; protected set; }

        public string Andar { get; protected set; }

        public int Vaga { get; protected set; }

        public string Telefone { get; protected set; }

        public string Ramal { get; protected set; }

        public string Complemento { get; protected set; }

        public Guid GrupoId { get; protected set; }

        public string GrupoDescricao { get; protected set; }

        public Guid CondominioId { get; protected set; }

        public string CondominioCnpj { get; protected set; }

        public string CondominioNome { get; protected set; }

        public string CondominioLogoMarca { get; protected set; }

    }
}
