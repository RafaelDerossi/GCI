using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.Usuarios.App.ViewModels
{
   public class AtualizaFuncionarioViewModel
    {
        public Guid FuncionarioId { get; set; }        

        public string Atribuicao { get; set; }

        public string Funcao { get; set; }      

        public Permissao Permissao { get; set; }
    }
}
