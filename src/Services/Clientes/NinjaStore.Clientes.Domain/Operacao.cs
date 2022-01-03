using GCI.Core.DomainObjects;
using GCI.Core.Enumeradores;
using System;

namespace GCI.Acoes.Domain
{
    public class Operacao : Entity
    {       

        public string CodigoDaAcao { get; private set; }        

        public decimal Preco { get; private set; }

        public int Quantidade { get; private set; }

        public DateTime DataDaOperacao { get; private set; }

        public decimal CustoDaOperacao { get; private set; }

        public decimal ValorTotal { get; private set; }

        public TipoOperacao Tipo { get; private set; }

        protected Operacao()
        {
        }

        public Operacao
            (string codigoDaAcao, decimal preco, int quantidade,
             DateTime dataDaOperacao, TipoOperacao tipo)
        {
            CodigoDaAcao = codigoDaAcao;
            Preco = preco;
            Quantidade = quantidade;
            DataDaOperacao = dataDaOperacao;
            Tipo = tipo;
            CalculaValorTotal();
        }
       

        private void CalculaValorTotal()
        {
            decimal taxa = 5;
            decimal emolumentos = 1.0325M;

            ValorTotal = Quantidade * Preco;

            CustoDaOperacao = (ValorTotal * emolumentos) + taxa;

            ValorTotal += CustoDaOperacao;
        }
    }
}
