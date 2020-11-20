using System;

namespace CondominioAppMarketplace.App.ViewModel
{
    public class LeadViewModel
    {
        public Guid LeadId { get; set; }

        public string NomeDoCondominio { get; set; }

        public string NomeDoCliente { get; set; }

        public string Bloco { get; set; }

        public string Unidade { get; set; }

        public string Observacao { get; set; }

        public string TelefoneDoCliente { get; set; }

        public string EmailDoMorador { get; set; }

        public Guid ItemDeVendaId { get; set; }

        public string PrecoDoProduto { get; set; }

        public string PorcentagemDeDescontoFormatado { get; set; }

        public string PrecoComDescontoFormatado { get; set; }

        public Guid ProdutoId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Chamada { get; set; }

        public string EspecificacaoTecnica { get; set; }

        public string linkDoProduto { get; set; }

        public bool EVisualizacaoDaWeb { get; set; }
    }
}
