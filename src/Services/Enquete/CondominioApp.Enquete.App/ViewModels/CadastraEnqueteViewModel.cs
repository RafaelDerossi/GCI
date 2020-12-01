using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Enquetes.App.ViewModels
{
   public class CadastraEnqueteViewModel
    {
        public string Descricao { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }


        public Guid CondominioId { get; set; }
        public string CondominioNome { get; set; }

        public bool ApenasProprietarios { get; set; }

        public Guid UsuarioId { get; set; }
        public string UsuarioNome { get; set; }

        public IEnumerable<string> Alternativas { get; set; }
    }
}
