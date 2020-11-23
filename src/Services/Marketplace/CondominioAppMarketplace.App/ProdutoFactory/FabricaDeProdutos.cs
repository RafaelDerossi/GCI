using CondominioApp.Core.DomainObjects;
using CondominioAppMarketplace.App.ViewModel;
using CondominioAppMarketplace.Domain;

namespace CondominioAppMarketplace.App.ProdutoFactory
{
    public class FabricaDeProdutos
    {
        private readonly IProdutoFactory _produtoFactory;
        public FabricaDeProdutos(IProdutoFactory produtoFactory)
        {
            _produtoFactory = produtoFactory;
        }

        public Produto CriarProduto(ProdutoViewModel ViewModel)
        {
            if (ViewModel.FotosDoProduto.Count == 0)
                throw new DomainException("Não é possível construir um produto sem fotos!");

            return _produtoFactory.CriarProduto(ViewModel);
        }
    }
}
