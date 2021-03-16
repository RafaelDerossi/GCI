using CondominioApp.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.ArquivoDigital.App.Models
{
  public class Arquivo : Entity
    {
        public string Nome { get; private set; }

        public string NomeOriginal { get; private set; }

        public string Extencao { get; private set; }

        public int Tamanho { get; private set; }

        public Guid CondominioId { get; private set; }

        public Guid PastaId { get; private set; }

        public bool Publico { get; private set; }


        public Arquivo()
        {
        }

        public Arquivo(string nome, string nomeOriginal, string extencao, int tamanho, Guid condominioId, Guid pastaId)
        {
            Nome = nome;
            NomeOriginal = nomeOriginal;
            Extencao = extencao;
            Tamanho = tamanho;
            CondominioId = condominioId;
            PastaId = pastaId;
        }


        public void SetNome(string nome) => Nome = nome;

        public void SetNomeOriginal(string nomeOriginal) => NomeOriginal = nomeOriginal;

        public void SetExtencao(string extencao) => Extencao = extencao;

        public void SetTamanho(int tamanho) => Tamanho = tamanho;

        public void SetCondominioId(Guid condominioId) => CondominioId = condominioId;

        public void SetPastaId(Guid pastaId) => PastaId = pastaId;

        public void MarcarComoPublico() => Publico = true;

        public void MarcarComoPrivado() => Publico = false;

    }
}
