using CondominioApp.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Domain.FlatModel
{
   public class GrupoFlat
    {
        public const int Max = 200;
        public Guid Id { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public DateTime DataDeAlteracao { get; private set; }

        public bool Lixeira { get; private set; }

        public string Descricao { get; private set; }

        public Guid CondominioId { get; private set; }

        public string CondominioCnpj { get; private set; }

        public string CondominioNome { get; private set; }

        public string CondominioNomeLogo { get; private set; }

        public string UrlCondominioLogo
        {
            get
            {
                if (CondominioNomeLogo == null || CondominioNomeLogo == "")
                    return "";

                return StorageHelper.ObterUrlDeArquivo(CondominioId.ToString(), CondominioNomeLogo);
            }
        }


        protected GrupoFlat() { }

        public GrupoFlat(Guid id,
            bool lixeira, string grupoDescricao, Guid condominioId, string condominioCnpj,
            string condominioNome, string condominioLogo)
        {
            Id = id;
            Lixeira = lixeira;
            Descricao = grupoDescricao;
            CondominioId = condominioId;
            CondominioCnpj = condominioCnpj;
            CondominioNome = condominioNome;
            CondominioNomeLogo = condominioLogo;
        }

        public void EnviarParaLixeira() => Lixeira = true;

        public void RestaurarDaLixeira() => Lixeira = false;      

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetCondominioCNPJ(string cnpj) => CondominioCnpj = cnpj;

        public void SetCondominioNome(string nome) => CondominioNome = nome;

        public void SetCondominioLogo(string logo) => CondominioNomeLogo = logo;
    }
}
