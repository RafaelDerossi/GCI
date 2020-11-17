using System;
using CondominioApp.Core.DomainObjects;

namespace CondominioAppPreCadastro.App.Models
{
    public class Arquivo : Entity
    {
        public const int Max = 1000;

        public string NomeOriginalDoArquivo { get; private set; }

        public string Nome { get; private set; }

        public Guid LeadId { get; private set; }

        public Lead Lead { get; private set; }

        protected Arquivo() { }

        public Arquivo(string nomeOriginalDoArquivo, string nome, Guid leadId, Lead lead)
        {
            NomeOriginalDoArquivo = nomeOriginalDoArquivo;
            Nome = nome;
            LeadId = leadId;
            Lead = lead;
        }

        public void SetNome(string nome) => Nome = nome;

        public void SetNomeOriginalDoArquivo(string nomeOriginal) => NomeOriginalDoArquivo = nomeOriginal;

        public void SetLeadId(Guid Id) => LeadId = Id;
    }
}