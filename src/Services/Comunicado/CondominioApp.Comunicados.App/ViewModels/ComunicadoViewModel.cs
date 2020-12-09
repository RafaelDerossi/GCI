using CondominioApp.Comunicados.App.Models;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondominioApp.Comunicados.App.ViewModels
{
   public class ComunicadoViewModel
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime? DataDeRealizacao { get; set; }

        public Guid CondominioId { get; set; }

        public string NomeCondominio { get; set; }

        public Guid UsuarioId { get; set; }

        public string NomeUsuario { get; set; }

        public VisibilidadeComunicado Visibilidade { get; set; }

        public CategoriaComunicado Categoria { get; set; }       

        public bool CriadoPelaAdministradora { get; set; }

        public IEnumerable<UnidadeViewModel> Unidades { get; set; }

        public IEnumerable<string> Anexos { get; set; }

        public bool TemAnexos
        {
            get {
                bool temAnexos = false;
                if (Anexos != null)
                {
                    temAnexos = Anexos.Count() > 0;
                }
                return temAnexos;
            }         
        }
    }
}
