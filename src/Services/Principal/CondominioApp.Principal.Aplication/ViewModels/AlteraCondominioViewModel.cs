using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Aplication.ViewModels
{
   public class AlteraCondominioViewModel
    {

        public Guid CodominioId { get; set; }

        public string Cnpj { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string LogoMarca { get; set; }

        public string NomeOriginal { get; set; }

        public string Telefone { get; set; }

    }
}
