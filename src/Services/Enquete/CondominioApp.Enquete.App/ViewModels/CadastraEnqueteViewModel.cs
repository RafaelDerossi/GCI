using System;
using System.Collections.Generic;

namespace CondominioApp.Enquetes.App.ViewModels
{
   public class CadastraEnqueteViewModel
    {
        public string Descricao { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public Guid CondominioId { get; set; }        

        public bool ApenasProprietarios { get; set; }

        public Guid FuncionarioId { get; set; }        

        public IEnumerable<CadastraAlternativaEnqueteViewModel> Alternativas { get; set; }
    }
}
