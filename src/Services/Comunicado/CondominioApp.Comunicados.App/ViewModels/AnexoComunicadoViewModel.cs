using System;

namespace CondominioApp.Comunicados.App.Models
{
    public class AnexoComunicadoViewModel
    {
        public Guid ArquivoId { get; set; }

        public string Nome { get; set; }

        public string NomeOriginal { get; set; }

        public string Extensao { get; set; }

        public int Tamanho { get; set; }        

    }
}
