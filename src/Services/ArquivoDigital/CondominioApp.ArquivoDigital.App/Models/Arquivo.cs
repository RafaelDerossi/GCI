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

        public Guid UsuarioId { get; private set; }

        public string NomeUsuario { get; private set; }

        public string Titulo { get; private set; }

        public string Descricao { get; private set; }

        public Guid AnexadoPorId { get; private set; }

        public Arquivo()
        {
        }

        public Arquivo
            (NomeArquivo nome, int tamanho, Guid condominioId, Guid pastaId, bool publico,
            Guid usuarioId, string nomeUsuario, string titulo, string descricao, Guid anexadoPorId)
        {
            Nome = nome;
            Tamanho = tamanho;
            CondominioId = condominioId;
            PastaId = pastaId;
            Publico = publico;
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
            Titulo = titulo;
            Descricao = descricao;
            AnexadoPorId = anexadoPorId;
        }

        public void SetNome(NomeArquivo nome) => Nome = nome;
        
        public void SetTamanho(int tamanho) => Tamanho = tamanho;

        public void SetCondominioId(Guid condominioId) => CondominioId = condominioId;

        public void SetPastaId(Guid pastaId) => PastaId = pastaId;

        public void MarcarComoPublico() => Publico = true;

        public void MarcarComoPrivado() => Publico = false;

        public void SetUsuario(Guid id, string nome) 
        {
            UsuarioId = id;
            NomeUsuario = nome;
        }

        public void SetTitulo(string titulo) => Titulo = titulo;

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetAnexadoPorId(Guid id) => AnexadoPorId = id;
    }
}
