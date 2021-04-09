using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CondominioApp.Comunicados.App.ViewModels
{
    public class CadastraComunicadoViewModel
    {
        public IEnumerable<Guid> UnidadesId { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime? DataDeRealizacao { get; set; }

        public Guid CondominioId { get; set; }

        public Guid FuncionarioId { get; set; }

        public VisibilidadeComunicado Visibilidade { get; set; }

        public CategoriaComunicado Categoria { get; set; }

        public bool CriadoPelaAdministradora { get; set; }

        public IEnumerable<CadastraAnexoComunicadoViewModel> Anexos { get; set; }

        public bool TemAnexos
        {
            get
            {
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
