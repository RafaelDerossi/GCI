using Microsoft.AspNetCore.Http;
using System;

namespace CondominioApp.Ocorrencias.App.Models
{
    public class AdicionaRespostaOcorrenciaMoradorViewModel
    {
        public Guid OcorrenciaId { get; set; }

        public string Descricao { get; set; }        

        public Guid MoradorId { get; set; }

        public IFormFile ArquivoFoto { get; set; }
    }
}
