using System;

namespace CondominioAppMarketplace.App.ViewModel
{
    public class ItemDeVendaViewModel
    {
        public Guid ProdutoId { get; set; }

        public Guid VendedorId { get; set; }

        public Guid ParceiroId { get; set; }

        public DateTime DataDeInicioDaExposicao { get; set; }

        public DateTime DataDeFinalDaExposicao { get; set; }

        public decimal PrecoDoProduto { get; set; }

        public int PorcentagemDeDesconto { get; set; }
    }
}
