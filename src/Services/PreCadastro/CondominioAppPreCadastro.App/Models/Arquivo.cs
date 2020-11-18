using System;
using CondominioApp.Core.DomainObjects;

namespace CondominioAppPreCadastro.App.Models
{
    public class Arquivo : Entity
    {
        public const int Max = 1000;

        public string NomeOriginalDoArquivo { get; private set; }

        public string Nome { get; private set; }

        public Lead Lead { get; private set; }

        protected Arquivo() { }

        public Arquivo(string nomeOriginalDoArquivo, string nome)
        {
            NomeOriginalDoArquivo = nomeOriginalDoArquivo;
            Nome = nome;
        }

        public void SetNome(string nome) => Nome = nome;

        public void SetNomeOriginalDoArquivo(string nomeOriginal) => NomeOriginalDoArquivo = nomeOriginal;

    }
}