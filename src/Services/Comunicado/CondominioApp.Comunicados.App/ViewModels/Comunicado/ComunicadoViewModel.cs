using CondominioApp.Comunicados.App.Models;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondominioApp.Comunicados.App.ViewModels
{
   public class ComunicadoViewModel : ComunicadoViewModelBase
    {
        public Guid Id { get; set; }

        public string DataDeCadastro { get; set; }

        public string DataDeAlteracao { get; set; }        

        public string NomeCondominio { get; set; }       

        public string NomeUsuario { get; set; }        

        public IEnumerable<UnidadeComunicadoViewModel> Unidades { get; set; }

        public new IEnumerable<AnexoComunicadoViewModel> Anexos { get; set; }       

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
