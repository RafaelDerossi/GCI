using CondominioApp.ArquivoDigital.App.ValueObjects;
using CondominioApp.Core.Messages;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class ArquivoCommand : Command
    {
        public Guid Id { get; protected set; }

        public NomeArquivo Nome { get; protected set; }

        public int Tamanho { get; protected set; }       

        public Guid PastaId { get; protected set; }

        public bool Publico { get; protected set; }

        public Guid UsuarioId { get; protected set; }

        public string NomeUsuario { get; protected set; }

        public string Titulo { get; protected set; }

        public string Descricao { get; protected set; }

        public Guid AnexadoPorId { get; protected set; }



        public void SetNome(string nomeOriginal)
        {
            try
            {
                Nome = new NomeArquivo(nomeOriginal, Id);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }
       
        public void SetTamanho(int tamanho) => Tamanho = tamanho;        

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
