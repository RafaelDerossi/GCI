using System;
using System.Collections.Generic;

namespace CondominioAppMarketplace.App.ViewModel
{
    public class ItemDaVitrineViewModel
    {
        public Guid ItemDeVendaId { get; set; }

        public DateTime DataDeCadastro { get; set; }

        public DateTime DataDeAlteracao { get; set; }

        public string DataDeCadastroFormatada { get; set; }

        public string DataDeAlteracaoFormatada { get; set; }

        public int NumeroDeCliques { get; set; }

        public string PrecoDoProduto { get; set; }

        public int ValorDoDesconto { get; set; }

        public string PrecoComDesconto { get; set; }

        public string PorcentagemDeDesconto { get; set; }

        public DateTime DataDeInicio { get; set; }

        public DateTime DataDeFim { get; set; }

        public Guid VendedorId { get; set; }

        public Guid ParceiroId { get; set; }

        public Guid ProdutoId { get; set; }

        public string Nome { get; private set; }

        public string Descricao { get; set; }

        public string Chamada { get; set; }

        public string EspecificacaoTecnica { get; set; }

        public bool Ativo { get; set; }

        public string Url { get; set; }

        public bool EVisualizacaoDaWeb { get; set; }

        public string TelefoneDoVendedor { get; set; }

        public bool Whatsapp { get; set; }

        public List<FotoDoProdutoViewModel> FotosDoProduto { get; set; }
    }
}
