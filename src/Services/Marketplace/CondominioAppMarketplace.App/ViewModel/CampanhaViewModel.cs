using System;
using System.Collections.Generic;

namespace CondominioAppMarketplace.App.ViewModel
{
    public class CampanhaViewModel
    {
        public Guid CampanhaId { get; set; }

        public string Titulo { get; private set; }

        public string Descricao { get; set; }

        public string Banner { get; private set; }

        public DateTime DataDeInicio { get; private set; }

        public DateTime DataDeFim { get; private set; }

        public string DataDeCadastroFormatada { get; set; }

        public string DataDeAlteracaoFormatada { get; set; }

        public bool Ativo { get; private set; }

        public bool TodosOsCondominios { get; private set; }

        public int NumeroDeCliques { get; private set; }

        public Guid ItemDeVendaId { get; private set; }

        public Guid ProdutoId { get; set; }

        public string NomeDoProduto { get; set; }

        public string DescricaoDoProduto { get; set; }

        public string ChamadaDoProduto { get; set; }

        public string EspecificacaoTecnica { get; set; }

        public string LinkDoProduto { get; set; }

        public Guid ParceiroId { get; set; }

        public bool EVisualizacaoDaWeb { get; set; }

        public List<CondominioViewModel> Condominios { get; set; }
    }
}
