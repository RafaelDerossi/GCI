using System;

namespace CondominioApp.ArquivoDigital.App.Models
{
    public class EditaArquivoViewModel
    {
        public Guid Id { get; set; }        

        public string NomeOriginal { get; set; }

        public bool Publico { get; set; }

    }
}
