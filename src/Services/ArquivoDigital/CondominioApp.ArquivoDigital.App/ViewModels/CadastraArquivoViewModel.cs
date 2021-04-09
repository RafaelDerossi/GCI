using System;

namespace CondominioApp.ArquivoDigital.App.Models
{
    public class CadastraArquivoViewModel
    {
        public string NomeOriginal { get; set; }

        public int Tamanho { get; set; }       

        public Guid PastaId { get; set; }

        public bool Publico { get; set; }

        public Guid UsuarioId { get; set; }        

        public string Titulo { get; set; }

        public string Descricao { get; set; }

    }
}
