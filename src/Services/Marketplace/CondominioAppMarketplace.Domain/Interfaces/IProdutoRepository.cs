using CondominioApp.Core.Data;

namespace CondominioAppMarketplace.Domain.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        void AdicionarFoto(FotoDoProduto foto);

        void RemoverFoto(FotoDoProduto foto);
    }
}