using CondominioApp.Enquetes.App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Enquetes.App.ViewModels
{
   public class EnqueteViewModel
    {
        public Guid Id { get; set; }

        public string DataDeCadastro { get; set; }

        public string DataDeAlteracao { get; set; }

        public string Descricao { get; set; }       

        public string DataInicio { get; set; }

        public string DataFim { get; set; }


        public Guid CondominioId { get; set; }
        public string CondominioNome { get; set; }

        public bool ApenasProprietarios { get; set; }

        public Guid UsuarioId { get; set; }
        public string UsuarioNome { get; set; }

        public IEnumerable<AlternativaEnqueteViewModel> Alternativas { get; set; }
    }
}
