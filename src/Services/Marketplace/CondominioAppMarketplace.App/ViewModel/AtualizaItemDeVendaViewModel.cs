using System;

namespace CondominioAppMarketplace.App.ViewModel
{
    public class AtualizaItemDeVendaViewModel
    {
        public Guid Id { get; set; }        

        public decimal PrecoDoProduto { get; set; }

        public int PorcentagemDeDesconto { get; set; }
    }
}
