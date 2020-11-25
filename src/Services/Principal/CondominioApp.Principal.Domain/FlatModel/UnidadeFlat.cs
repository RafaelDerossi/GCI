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

        public string CondominioLogoMarca { get; private set; }

        protected UnidadeFlat() { }

        public UnidadeFlat(Guid id, DateTime dataDeCadastro, DateTime dataDeAlteracao, bool lixeira, 
            string unidadeCodigo, string unidadeNumero, string unidadeAndar,
            int unidadeVagas, string unidadeTelefone, string unidadeRamal, string unidadeComplemento,
            Guid grupoId, string grupoDescricao, Guid condominioId, string condominioCnpj, string condominioNome,
            string condominioLogoMarca)
        {
            Id = id;
            DataDeCadastro = dataDeCadastro;
            DataDeAlteracao = dataDeAlteracao;
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
            CondominioLogoMarca = condominioLogoMarca;
        }


        public void EnviarParaLixeira() => Lixeira = true;

        public void RestaurarDaLixeira() => Lixeira = false;
    }
}
