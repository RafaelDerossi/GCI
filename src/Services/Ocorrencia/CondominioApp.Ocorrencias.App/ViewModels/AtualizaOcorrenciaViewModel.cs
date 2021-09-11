using Microsoft.AspNetCore.Http;
using System;

namespace CondominioApp.Ocorrencias.App.ViewModels
{
    public class AtualizaOcorrenciaViewModel
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }        

        public bool Publica { get; set; }

        public IFormFile ArquivoFoto { get; set; }

    }
}
