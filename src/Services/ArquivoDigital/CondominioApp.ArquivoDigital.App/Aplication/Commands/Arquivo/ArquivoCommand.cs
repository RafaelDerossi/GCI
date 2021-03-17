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

        public Guid CondominioId { get; protected set; }

        public Guid PastaId { get; protected set; }

        public bool Publico { get; protected set; }




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

        public void SetCondominioId(Guid condominioId) => CondominioId = condominioId;

        public void SetPastaId(Guid pastaId) => PastaId = pastaId;

        public void MarcarComoPublico() => Publico = true;

        public void MarcarComoPrivado() => Publico = false;

       
    }
}
