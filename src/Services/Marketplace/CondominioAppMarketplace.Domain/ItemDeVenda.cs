using System;
using System.Collections.Generic;
using System.Globalization;
using CondominioApp.Core.DomainObjects;

namespace CondominioAppMarketplace.Domain
{
    public class ItemDeVenda : Entity, IAggregateRoot
    {
        NumberFormatInfo InformacaoDeNumeroFormatado = new CultureInfo("pt-BR", false).NumberFormat;

        public int NumeroDeCliques { get; private set; }

        public decimal Preco { get; private set; }

        public int PorcentagemDeDesconto { get; private set; }

        public DateTime DataDeInicio { get; private set; }

        public DateTime DataDeFim { get; private set; }

        public Guid ProdutoId { get; private set; }

        public Produto Produto { get; private set; }

        public Guid VendedorId { get; private set; }

        public Vendedor Vendedor { get; private set; }

        public Guid ParceiroId { get; private set; }

        public Guid CondominioId { get; private set; }

        public ICollection<Lead> Leads { get; private set; }

        public ICollection<Campanha> Campanhas { get; private set; }

        protected ItemDeVenda() { }

        public ItemDeVenda(decimal preco, int porcentagemDeDesconto, DateTime dataDeInicio, DateTime dataDeFim, Guid produtoId, Guid vendedorId, Guid parceiroId, Guid condominioId)
        {   
            ProdutoId = produtoId;
            VendedorId = vendedorId;
            ParceiroId = parceiroId;
            CondominioId = condominioId;

            setPorcentagemDeDesconto(porcentagemDeDesconto);
            setPreco(preco);
            ConfigurarIntervalo(dataDeInicio, dataDeFim);
            Validar();
        }

        public string PrecoDoProduto
        {
            get { return Preco.ToString("C", InformacaoDeNumeroFormatado); }
        }

        public string PrecoComDescontoFormatado
        {
            get 
            {
                var porcentagemDoValor = Preco * (Convert.ToDecimal(PorcentagemDeDesconto) / Convert.ToDecimal(100));
                var ValorFinal = Preco - porcentagemDoValor;

                return ValorFinal.ToString("C", InformacaoDeNumeroFormatado); 
            }
        }

        public string PorcentagemDeDescontoFormatado
        {
            get { return PorcentagemDeDesconto + "%"; }
        }

        public void ContaCliques() => NumeroDeCliques++;

        public void setPreco(decimal preco)
        {
            if (preco < 0)
                this.Preco = preco *= -1;
            else
                this.Preco = preco;
        }

        public void setPorcentagemDeDesconto(int porcentagemDeDesconto)
        {
            if (porcentagemDeDesconto < 0)
                PorcentagemDeDesconto = porcentagemDeDesconto *= -1;
            else
                PorcentagemDeDesconto = porcentagemDeDesconto;
        }

        public void ConfigurarIntervalo(DateTime dataDeInicio, DateTime dataDeFim)
        {
            if (dataDeInicio != null && dataDeFim != null)
            {
                if (dataDeFim < dataDeInicio)
                    throw new DomainException("Data de início do item de venda não pode ser maior que a de fim");

                DataDeInicio = dataDeInicio.Date;
                DataDeFim = dataDeFim.Date;
            }
        }

        public void setVendedor(Vendedor vendedor)
        {
            Vendedor = vendedor;
        }

        public void setProduto(Produto produto)
        {
            Produto = produto;
        }

        public void Validar()
        {
            if (ProdutoId == Guid.Empty) throw new DomainException("O Id do Produto do item de venda não pode estar vazio!");
            if (VendedorId == Guid.Empty) throw new DomainException("O Id do Vendedor do item de venda não pode estar vazio!");
            if (ParceiroId == Guid.Empty) throw new DomainException("O Id do Parceir do item de venda não pode estar vazio!");
        }
    }
}
