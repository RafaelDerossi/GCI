using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Aplication.ViewModels
{
   public class AlteraCondominioViewModel
    {

        public Guid Id { get; set; }

        public string Cnpj { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string LogoMarca { get; set; }

        public string NomeOriginal { get; set; }

        public string Telefone { get; set; }

        public string Logradouro { get; set; }

        public string Complemento { get; set; }

        public string Numero { get; set; }

        public string Cep { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }
    }
}
