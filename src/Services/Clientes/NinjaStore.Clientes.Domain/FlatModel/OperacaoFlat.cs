using GCI.Core.DomainObjects;
using System;
using GCI.Core.Enumeradores;

namespace GCI.Acoes.Domain.FlatModel
{
    [BsonCollection("OperacaoFlat")]
    public class OperacaoFlat : Document, IAggregateRoot
   {        
        public Guid OperacaoId { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public string DataDeCadastroFormatada
        {
            get
            {
                if (DataDeCadastro != null)
                    return DataDeCadastro.ToString("dd/MM/yyyy HH:mm");
                else
                    return null;
            }
        }

        public DateTime DataDeAlteracao { get; private set; }

        public string DataDeAlteracaoFormatada
        {
            get
            {
                if (DataDeAlteracao != null)
                    return DataDeAlteracao.ToString("dd/MM/yyyy HH:mm");
                else
                    return null;
            }
        }


        public string CodigoDaAcao { get; private set; }

        public decimal Preco { get; private set; }

        public int Quantidade { get; private set; }

        public DateTime DataDaOperacao { get; private set; }

        public string DataDaOperacaoFormatada
        {
            get
            {
                if (DataDaOperacao != null)
                    return DataDaOperacao.ToString("dd/MM/yyyy HH:mm");
                else
                    return null;
            }
        }

        public decimal CustoDaOperacao { get; private set; }

        public decimal ValorTotal { get; private set; }

        public TipoOperacao Tipo { get; private set; }

        public string DescricaoTipoOperacao
        {
            get
            {
                if (Tipo == TipoOperacao.COMPRA)
                    return "C";
                return "V";
            }
        }

        protected OperacaoFlat()
        {
        }

        public OperacaoFlat
            (Guid operacaoId, DateTime dataDeCadastro,
             string codigoDaAcao, decimal preco, int quantidade, DateTime dataDaOperacao,
             decimal custoDaOperacao, decimal valorTotal, TipoOperacao tipo)
        {
            OperacaoId = operacaoId;
            DataDeCadastro = dataDeCadastro;
            DataDeAlteracao = dataDeCadastro;
            CodigoDaAcao = codigoDaAcao;
            Preco = preco;
            Quantidade = quantidade;
            DataDaOperacao = dataDaOperacao;
            CustoDaOperacao = custoDaOperacao;
            ValorTotal = valorTotal;
            Tipo = tipo;
        }
    }
}
