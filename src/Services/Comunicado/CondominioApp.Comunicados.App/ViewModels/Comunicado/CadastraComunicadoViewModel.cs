using CondominioApp.Comunicados.App.Models;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondominioApp.Comunicados.App.ViewModels
{
   public class CadastraComunicadoViewModel : ComunicadoViewModelBase
    {
        public IEnumerable<Guid> UnidadesId { get; set; }

       
    }
}
