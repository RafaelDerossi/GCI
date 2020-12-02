using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Usuarios.App.ViewModels
{
   public class EditarMoradorViewModel
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Rg { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Cpf { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }

        public string Foto { get; set; }

        public string NomeOriginal { get; set; }
    }
}
