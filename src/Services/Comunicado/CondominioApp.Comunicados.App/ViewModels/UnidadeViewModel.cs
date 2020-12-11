using CondominioApp.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Comunicados.App.ViewModels
{
   public class UnidadeViewModel
    {        
        public Guid UnidadeId { get; set; }
        public string DataDeCadastro { get; set; }
        public string DataDeAlteracao { get; set; }
        public string Numero { get; set; }
        public string Andar { get; set; }              
        public Guid GrupoId { get; set; }
        public string DescricaoGrupo { get; set; }   
    }
}
