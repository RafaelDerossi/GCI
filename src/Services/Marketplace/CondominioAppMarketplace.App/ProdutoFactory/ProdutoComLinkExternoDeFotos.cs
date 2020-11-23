using CondominioApp.Core.ValueObjects;
using CondominioAppMarketplace.App.ViewModel;
using CondominioAppMarketplace.Domain;

namespace CondominioAppMarketplace.App.ProdutoFactory
{
    public class ProdutoComLinkExternoDeFotos : IProdutoFactory
    {
        public Produto CriarProduto(ProdutoViewModel ViewModel)
        {
            var produto = new Produto(ViewModel.Nome, ViewModel.Descricao, ViewModel.Chamada, ViewModel.EspecificacaoTecnica,
                         new Url(ViewModel.LinkDoProduto), ViewModel.ParceiroId);

            foreach (var fotoDoProdutoViewModel in ViewModel.FotosDoProduto)
            {
                var FotoDoProduto = new FotoDoProduto(fotoDoProdutoViewModel.NomeOriginal,fotoDoProdutoViewModel.Principal);
                produto.AdicionarFotos(FotoDoProduto);
            }

            produto.MarcarPrimeiraFotoPrincipal();

            return produto;
        }
    }
}