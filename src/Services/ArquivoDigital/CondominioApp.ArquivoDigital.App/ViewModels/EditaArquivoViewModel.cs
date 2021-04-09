using System;

namespace CondominioApp.ArquivoDigital.App.Models
{
    public class EditaArquivoViewModel
    {
        public Guid Id { get; set; }        

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public bool Publico { get; set; }

        public string NomeOriginal { get; set; }

    }
}
