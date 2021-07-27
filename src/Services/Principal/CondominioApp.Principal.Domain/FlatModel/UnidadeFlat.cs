using CondominioApp.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Domain.FlatModel
{
   public class UnidadeFlat
    {
        public const int Max = 200;

        public Guid Id { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public DateTime DataDeAlteracao { get; private set; }

        public bool Lixeira { get; private set; }

        public string Codigo { get; private set; }

        public string Numero { get; private set; }

        public string Andar { get; private set; }

        public int Vagas { get; private set; }

        public string Telefone { get; private set; }

        public string Ramal { get; private set; }

        public string Complemento { get; private set; }

        public Guid GrupoId { get; private set; }

        public string GrupoDescricao { get; private set; }

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

        protected UnidadeFlat() { }

        public UnidadeFlat(Guid id, bool lixeira, 
            string unidadeCodigo, string unidadeNumero, string unidadeAndar,
            int unidadeVagas, string unidadeTelefone, string unidadeRamal, string unidadeComplemento,
            Guid grupoId, string grupoDescricao, Guid condominioId, string condominioCnpj, string condominioNome,
            string condominioNomeLogo)
        {
            Id = id;
            Lixeira = lixeira;
            Codigo = unidadeCodigo;
            Numero = unidadeNumero;
            Andar = unidadeAndar;
            Vagas = unidadeVagas;
            Telefone = unidadeTelefone;
            Ramal = unidadeRamal;
            Complemento = unidadeComplemento;
            GrupoId = grupoId;
            GrupoDescricao = grupoDescricao;
            CondominioId = condominioId;
            CondominioCnpj = condominioCnpj;
            CondominioNome = condominioNome;
            CondominioNomeLogo = condominioNomeLogo;
        }


        public void EnviarParaLixeira() => Lixeira = true;

        public void RestaurarDaLixeira() => Lixeira = false;


        public void SetCodigo(string codigo) => this.Codigo = codigo;

        public void SetNumero(string numero) => this.Numero = numero;

        public void SetAndar(string andar) => this.Andar = andar;       

        public void SetVagas(int vagas) => Vagas = vagas;

        public void SetTelefone(string telefone) => Telefone = telefone;

        public void SetRamal(string ramal) => Ramal = ramal;

        public void SetComplemento(string complemento) => Complemento = complemento;

        public void SetGrupoDescricao(string descricao) => GrupoDescricao = descricao;

        public void SetCondominioCNPJ(string cnpj) => CondominioCnpj = cnpj;

        public void SetCondominioNome(string nome) => CondominioNome = nome;

        public void SetCondominioLogo(string logo) => CondominioNomeLogo = logo;


        public string ObterDescricaoUnidade()
        {
            return $"{Numero}|{Andar}|{GrupoDescricao}";
        }
    }
}
