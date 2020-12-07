using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Correspondencias.App.DTO
{
   public class CorrespondenciaExcelDTO
    {
        public string DataDaChegada { get; set; }

        public string DataDaRetirada { get; set; }

        public string EntreguePor { get; set; }
       
        public string RetiradoPor { get; set; }

        public string Observacao { get; set; }
    }
}
