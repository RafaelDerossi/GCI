using System;

namespace CondominioApp.Comunicados.App.Models
{
    public abstract class AnexoComunicadoViewModelBase
    {
        public Guid ArquivoId { get; set; }

        public string NomeOriginal { get; set; }

        public int Tamanho { get; set; }

        public AnexoComunicadoViewModelBase()
        {
        }

        protected AnexoComunicadoViewModelBase(Guid arquivoId, string nomeOriginal, int tamanho)
        {
            ArquivoId = arquivoId;
            NomeOriginal = nomeOriginal;
            Tamanho = tamanho;
        }
    }
}
