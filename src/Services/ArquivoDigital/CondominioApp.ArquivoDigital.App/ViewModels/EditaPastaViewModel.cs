using CondominioApp.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.ArquivoDigital.App.Models
{
   public class EditaPastaViewModel
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public Guid CondominioId { get; set; }

        public bool Publica { get; set; }
     
    }
}
