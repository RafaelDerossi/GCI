using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Aplication.ViewModels
{
   public class AtualizaUnidadeViewModel
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Numero { get; set; }
        public string Andar { get; set; }
        public int Vagas { get; set; }
        public string Telefone { get; set; }
        public string Ramal { get; set; }
        public string Complemento { get; set; }      
    }
}
