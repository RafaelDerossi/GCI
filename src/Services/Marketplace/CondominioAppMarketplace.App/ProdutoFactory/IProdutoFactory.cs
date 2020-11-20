using CondominioAppMarketplace.App.ViewModel;
using CondominioAppMarketplace.Domain;

namespace CondominioAppMarketplace.App.ProdutoFactory
{
    public interface IProdutoFactory
    {
        Produto CriarProduto(ProdutoViewModel ViewModel);
    }
}
