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

        public Guid FuncionarioId { get; protected set; }

        public string NomeFuncionario { get; protected set; }

        public string Titulo { get; protected set; }

        public string Descricao { get; protected set; }

        public Guid AnexadoPorId { get; protected set; }



        public void SetNome(string nomeArquivo, string nomeOriginal)
        {
            try
            {
                Nome = new NomeArquivo(nomeArquivo, nomeOriginal);
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

        public void SetFuncionario(Guid id, string nome)
        {
            FuncionarioId = id;
            NomeFuncionario = nome;
        }

        public void SetTitulo(string titulo) => Titulo = titulo;

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetAnexadoPorId(Guid id) => AnexadoPorId = id;

    }
}
