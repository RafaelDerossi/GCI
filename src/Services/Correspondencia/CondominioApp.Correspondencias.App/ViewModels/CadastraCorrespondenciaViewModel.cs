using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Correspondencias.App.ViewModels
{
   public class CadastraCorrespondenciaViewModel
    {
        public Guid UnidadeId { get; set; }        

        public string Observacao { get; set; }

        public Guid FuncionarioId { get; set; }

        public string Foto { get;  set; }

        public string NomeOriginal { get; set; }

        public string NumeroRastreamentoCorreio { get; set; }

        public DateTime DataDeChegada { get; set; }

        public string TipoDeCorrespondencia { get; set; }

        public StatusCorrespondencia Status { get; set; }

        public string NomeRetirante { get; set; }

        public DateTime? DataDaRetirada { get; set; }

    }
}
