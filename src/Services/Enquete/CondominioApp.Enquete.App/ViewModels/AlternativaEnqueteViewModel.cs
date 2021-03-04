using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Enquetes.App.ViewModels
{
   public class AlternativaEnqueteViewModel
    {
        public Guid Id { get; set; }

        public string DataDeCadastro { get; set; }

        public string DataDeAlteracao { get; set; }

        public string Descricao { get; set; }

        public IEnumerable<RespostaEnqueteViewModel> Respostas { get; set; }

        public double Porcentagem { get; set; }
    }
}
