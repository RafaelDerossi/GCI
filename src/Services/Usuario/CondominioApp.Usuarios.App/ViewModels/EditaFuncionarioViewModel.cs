using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Usuarios.App.ViewModels
{
   public class EditaFuncionarioViewModel
    {
        public Guid FuncionarioId { get; set; }        

        public string Atribuicao { get; set; }

        public string Funcao { get; set; }      

        public Permissao Permissao { get; set; }
    }
}
