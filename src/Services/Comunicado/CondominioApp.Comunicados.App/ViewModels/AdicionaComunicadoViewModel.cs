using CondominioApp.Core.Enumeradores;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CondominioApp.Comunicados.App.ViewModels
{
    public class AdicionaComunicadoViewModel
    {
        public IEnumerable<Guid> UnidadesId { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime? DataDeRealizacao { get; set; }        

        public Guid FuncionarioId { get; set; }

        public VisibilidadeComunicado Visibilidade { get; set; }

        public CategoriaComunicado Categoria { get; set; }

        public bool CriadoPelaAdministradora { get; set; }

        public IEnumerable<IFormFile> Anexos { get; set; }

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
