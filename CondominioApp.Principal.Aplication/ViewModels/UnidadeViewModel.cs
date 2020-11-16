using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Aplication.ViewModels
{
   public class UnidadeViewModel
    {
        public Guid UnidadeId { get; set; }       
        public string Numero { get; set; }
        public string Andar { get; set; }
        public int Vagas { get; set; }
        public string Telefone { get; set; }
        public string Ramal { get; set; }
        public string Complemento { get; set; }
        public Guid GrupoId { get; set; }       
        public Guid CondominioId { get; set; }     

    }
}
