using GCI.Core.DomainObjects;
using System;

namespace GCI.Acoes.Domain
{
    public class Compra : Entity
    {
        public const int Max = 200;

        public string CodigoDaAcao { get; private set; }        

        public decimal Preco { get; private set; }

        public int Quantidade { get; private set; }

        public DateTime DataDaCompra { get; set; }

        public decimal CustoDaOperacao { get; private set; }

        public decimal ValorTotal { get; private set; }

        protected Compra()
        {
        }

        public Compra(string codigoDaAcao, decimal preco, int quantidade, DateTime dataDaCompra)
        {
            CodigoDaAcao = codigoDaAcao;
            Preco = preco;
            Quantidade = quantidade;
            DataDaCompra = dataDaCompra;
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
