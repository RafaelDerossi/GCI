using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CondominioApp.Core.Data;

namespace CondominioAppMarketplace.Domain.Interfaces
{
    public interface IParceiroRepository : IRepository<Parceiro>
    {
        Task<IEnumerable<Vendedor>> ObterTodosOsVendedores();

        Task<IEnumerable<Vendedor>> ObterVendedores(Expression<Func<Vendedor, bool>> expression, bool OrderByDesc = false, int take = 0);

        Task<Vendedor> ObterVendedorPorId(Guid Id);

        void AdicionarVendedor(Vendedor vendedor);

        void AtualizarVendedor(Vendedor vendedor);
    }
}