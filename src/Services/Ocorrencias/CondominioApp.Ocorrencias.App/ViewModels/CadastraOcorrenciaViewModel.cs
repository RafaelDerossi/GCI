using CondominioApp.Ocorrencias.App.Models;
using CondominioApp.Ocorrencias.App.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CondominioApp.Ocorrencias.App.ViewModels
{
   public class CadastraOcorrenciaViewModel
    {        
        public string Descricao { get; set; }
        public Foto Foto { get; set; }
        public bool Publica { get; set; }

        public Guid UnidadeId { get; set; }
        public Guid UsuarioId { get; set; }                
        public Guid CondominioId { get; set; }       
        
        public bool Panico { get; set; }

        public IEnumerable<AnexoOcorrenciaViewModel> Anexos { get; set; }

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
