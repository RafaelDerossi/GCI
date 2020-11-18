using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Domain.FlatModel
{
   public class GrupoFlat
    {
        public Guid Id { get; set; }

        public string GrupoDescricao { get; set; }

        public Guid CondominioId { get; set; }

        public string CondominioCnpj { get; set; }

        public string CondominioNome { get; set; }

        public string CondominioLogoMarca { get; set; }

    }
}
