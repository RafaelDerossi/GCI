using System;

namespace CondominioApp.Ocorrencias.App.Models
{
    public class AtualizaRespostaOcorrenciaViewModel
    {
        public Guid Id { get; set; }
      
        public string Descricao { get; set; }

        public string NomeOriginalFoto { get; set; }

        public string NomeFoto { get; set; }

        public Guid MoradorIdFuncionarioId { get; set; }

    }
}
