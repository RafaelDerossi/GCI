using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Aplication.ViewModels
{
   public class GrupoViewModel
    {
        public Guid GrupoId { get; set; }

        public string Descricao { get; set; }

        public Guid CondominioId { get; set; }
       
    }
}
