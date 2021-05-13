using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Enquetes.App.ViewModels
{
   public class AtualizaEnqueteViewModel
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }      

        public bool ApenasProprietarios { get; set; }

        public IEnumerable<AdicionaAlternativaEnqueteViewModel> Alternativas { get; set; }

    }
}
