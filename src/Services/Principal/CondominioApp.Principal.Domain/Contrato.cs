using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Principal.Domain.ValueObjects;
using System;

namespace CondominioApp.Principal.Domain
{
    public class Contrato : Entity
    {
        public const int Max = 200;

        public Guid CondominioId { get; private set; }

        public DateTime DataAssinatura { get; private set; }

        public TipoDePlano Tipo { get; private set; }

        public string Descricao { get; private set; }

        public bool Ativo { get; private set; }

        public int QuantidadeDeUnidadesContratada { get; private set; }

        public NomeArquivo ArquivoContrato { get; private set; }


        /// <summary>
        /// Construtores
        /// </summary>
        protected Contrato()
        {
        }

        public Contrato
            (Guid condominioId, DateTime dataAssinatura, TipoDePlano tipo,string descricao,
             bool ativo, NomeArquivo arquivoContrato, int quantidadeDeUnidadesContratada)
        {
            CondominioId = condominioId;
            DataAssinatura = dataAssinatura;
            Tipo = tipo;
            Descricao = descricao;
            Ativo = ativo;
            ArquivoContrato = arquivoContrato;
            QuantidadeDeUnidadesContratada = quantidadeDeUnidadesContratada;
        }



        ///Metodos Set

        public void SetCondominioId(Guid id) => CondominioId = id;

        public void SetDataAssinatura(DateTime data) => DataAssinatura = data;

        public void SetTipoDePlano(TipoDePlano tipo) => Tipo = tipo;

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetQuantidadeDeUnidadesContratada(int qtd) => QuantidadeDeUnidadesContratada = qtd;

        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;

        public void SetArquivoContrato(NomeArquivo arquivoContrato) => ArquivoContrato = arquivoContrato;

    }
}
