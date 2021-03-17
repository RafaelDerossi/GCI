using CondominioApp.ArquivoDigital.App.ValueObjects;
using CondominioApp.Core.DomainObjects;
using System;

namespace CondominioApp.ArquivoDigital.App.Models
{
  public class Arquivo : Entity
    {
        public const int Max = 200;

        public NomeArquivo Nome { get; private set; }        

        public int Tamanho { get; private set; }

        public Guid CondominioId { get; private set; }

        public Guid PastaId { get; private set; }

        public bool Publico { get; private set; }


        public Arquivo()
        {
        }

        public Arquivo(NomeArquivo nome, int tamanho, Guid condominioId, Guid pastaId)
        {
            Nome = nome;            
            Tamanho = tamanho;
            CondominioId = condominioId;
            PastaId = pastaId;            
        }


        public void SetNome(NomeArquivo nome) => Nome = nome;
        
        public void SetTamanho(int tamanho) => Tamanho = tamanho;

        public void SetCondominioId(Guid condominioId) => CondominioId = condominioId;

        public void SetPastaId(Guid pastaId) => PastaId = pastaId;

        public void MarcarComoPublico() => Publico = true;

        public void MarcarComoPrivado() => Publico = false;

    }
}
