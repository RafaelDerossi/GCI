using CondominioApp.Comunicados.App.Models;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondominioApp.Comunicados.App.ViewModels
{
   public class EditaComunicadoViewModel : ComunicadoViewModelBase
    {
        public Guid ComunicadoId { get; set; }

        public IEnumerable<Guid> UnidadesId { get; set; }

        public new IEnumerable<EditaAnexoComunicadoViewModel> Anexos { get; set; }

        public new bool TemAnexos
        {
            get
            {
                base.Anexos = Anexos;                
                return base.TemAnexos;
            }
        }
    }
}
