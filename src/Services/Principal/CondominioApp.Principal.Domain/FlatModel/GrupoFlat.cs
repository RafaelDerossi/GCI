using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Domain.FlatModel
{
   public class GrupoFlat
    {
        public Guid Id { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public DateTime DataDeAlteracao { get; private set; }

        public bool Lixeira { get; private set; }

        public string Descricao { get; private set; }

        public Guid CondominioId { get; private set; }

        public string CondominioCnpj { get; private set; }

        public string CondominioNome { get; private set; }

        public string CondominioLogoMarca { get; private set; }

        protected GrupoFlat() { }

        public GrupoFlat(Guid id, string grupoDescricao, Guid condominioId, string condominioCnpj,
            string condominioNome, string condominioLogoMarca)
        {
            Id = id;
            Descricao = grupoDescricao;
            CondominioId = condominioId;
            CondominioCnpj = condominioCnpj;
            CondominioNome = condominioNome;
            CondominioLogoMarca = condominioLogoMarca;
        }

        public void EnviarParaLixeira() => Lixeira = true;

        public void RestaurarDaLixeira() => Lixeira = false;
    }
}
