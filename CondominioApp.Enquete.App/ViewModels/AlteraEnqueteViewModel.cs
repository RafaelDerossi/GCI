using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Enquetes.App.ViewModels
{
   public class AlteraEnqueteViewModel
    {
        public Guid EnqueteId { get; set; }
        public string Descricao { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }      

        public bool ApenasProprietarios { get; set; }
       
    }
}
