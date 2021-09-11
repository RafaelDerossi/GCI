using System;
using System.Collections.Generic;

namespace CondominioAppMarketplace.App.ViewModel
{
    public class ProdutoViewModel
    {
        public Guid ProdutoId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Chamada { get; set; }

        public string EspecificacaoTecnica { get; set; }

        public bool Ativo { get; set; }

        public string LinkDoProduto { get; set; }

        public Guid ParceiroId { get; set; }

        public string EVisualizacaoDaWeb { get; set; }

        public bool LinkExternoDeFotos { get; set; }

        public List<FotoDoProdutoViewModel> FotosDoProduto { get; set; }
    }
}