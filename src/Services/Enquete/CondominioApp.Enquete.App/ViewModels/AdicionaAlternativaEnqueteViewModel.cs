using System;
using System.Collections.Generic;

namespace CondominioApp.Enquetes.App.ViewModels
{
   public class AdicionaAlternativaEnqueteViewModel
    {
        public string Descricao { get; set; }

        public int Ordem { get; set; }

        public AdicionaAlternativaEnqueteViewModel()
        {
        }

        public AdicionaAlternativaEnqueteViewModel(string descricao, int ordem)
        {
            Descricao = descricao;
            Ordem = ordem;
        }
    }
}
