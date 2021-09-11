using CondominioApp.Core.Enumeradores;
using Microsoft.AspNetCore.Http;
using System;

namespace CondominioApp.Ocorrencias.App.Models
{
    public class AdicionaRespostaOcorrenciaAdministracaoViewModel
    {
        public Guid OcorrenciaId { get; set; }

        public string Descricao { get; set; }

        public Guid FuncionarioId { get; set; }

        public IFormFile ArquivoFoto { get; set; }

        public IFormFile ArquivoAnexo { get; set; }

        public StatusDaOcorrencia StatusDaOcorrencia { get; set; }

    }
}
