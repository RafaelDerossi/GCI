using System;

namespace CondominioApp.Comunicados.App.ViewModels
{
   public class UnidadeComunicadoViewModel
    {        
        public Guid UnidadeId { get; set; }
        public string Numero { get; set; }
        public string Andar { get; set; }
        public Guid GrupoId { get; set; }
        public string DescricaoGrupo { get; set; }
    }
}
