using System;
using Microsoft.AspNetCore.Http;

namespace CondominioApp.ArquivoDigital.App.Models
{
    public class AdicionaArquivoViewModel
    {
        public Guid PastaId { get; set; }

        public bool Publico { get; set; }

        public Guid FuncionarioId { get; set; }        

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public IFormFile Arquivo { get; set; }

    }
}
