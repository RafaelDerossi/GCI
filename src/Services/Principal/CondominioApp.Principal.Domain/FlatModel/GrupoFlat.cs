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

        public GrupoFlat(Guid id, string grupoDescricao, Guid condominioId, string condominioCnpj,
            string condominioNome, string condominioLogoMarca)
        {
            Id = id;
            GrupoDescricao = grupoDescricao;
            CondominioId = condominioId;
            CondominioCnpj = condominioCnpj;
            CondominioNome = condominioNome;
            CondominioLogoMarca = condominioLogoMarca;
        }
    }
}
