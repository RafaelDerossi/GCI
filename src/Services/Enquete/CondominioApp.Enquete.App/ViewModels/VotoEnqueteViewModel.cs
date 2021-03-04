using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.Enquetes.App.ViewModels
{
   public class VotoEnqueteViewModel
    {
        public Guid UnidadeId { get; set; }        

        public Guid UsuarioId { get; set; }        

        public Guid AlternativaId { get; set; }

        public TipoDeUsuario TipoDeUsuario { get; set; }
    }
}
