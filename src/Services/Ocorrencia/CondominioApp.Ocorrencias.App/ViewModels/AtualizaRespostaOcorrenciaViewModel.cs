using Microsoft.AspNetCore.Http;
using System;

namespace CondominioApp.Ocorrencias.App.Models
{
    public class AtualizaRespostaOcorrenciaViewModel
    {
        public Guid Id { get; set; }
      
        public string Descricao { get; set; }       

        public Guid MoradorIdFuncionarioId { get; set; }

        public IFormFile ArquivoFoto { get; set; }
    }
}
