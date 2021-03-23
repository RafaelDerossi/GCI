using System;

namespace CondominioApp.Comunicados.App.ViewModels
{
    public class AnexoComunicadoViewModel
    {
        public Guid ArquivoId { get; set; }

        public string Nome { get; set; }

        public string NomeOriginal { get; set; }        

        public string Extensao { get; set; }

        public int Tamanho { get; set; }


        public AnexoComunicadoViewModel(Guid arquivoId, string nome, string nomeOriginal, string extensao, int tamanho)
        {
            ArquivoId = arquivoId;
            Nome = nome;
            NomeOriginal = nomeOriginal;
            Extensao = extensao;
            Tamanho = tamanho;
        }
    }
}
