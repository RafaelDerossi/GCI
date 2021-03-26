using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.Ocorrencias.App.Models
{
    public class CadastraRespostaOcorrenciaSindicoViewModel
    {
        public Guid OcorrenciaId { get; set; }

        public string Descricao { get; set; }

        public Guid FuncionarioId { get; set; }                

        public string FotoNome { get; set; }

        public string FotoNomeOriginal { get; set; }

        public StatusDaOcorrencia Status { get; set; }

    }
}
