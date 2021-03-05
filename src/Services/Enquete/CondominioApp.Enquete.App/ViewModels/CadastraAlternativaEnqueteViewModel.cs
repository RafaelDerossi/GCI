using System;
using System.Collections.Generic;

namespace CondominioApp.Enquetes.App.ViewModels
{
   public class CadastraAlternativaEnqueteViewModel
    {
        public string Descricao { get; set; }

        public int Ordem { get; set; }

        public CadastraAlternativaEnqueteViewModel()
        {

        }
        public CadastraAlternativaEnqueteViewModel(string descricao, int ordem)
        {
            Descricao = descricao;
            Ordem = ordem;
        }
    }
}
