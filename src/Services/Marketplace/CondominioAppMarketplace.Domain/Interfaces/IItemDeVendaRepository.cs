using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CondominioApp.Core.Data;

namespace CondominioAppMarketplace.Domain.Interfaces
{
    public interface IItemDeVendaRepository : IRepository<ItemDeVenda>
    {
        Task<IEnumerable<ItemDeVenda>> ObterItensDoParceiro(Guid ParceiroId);

        Task<IEnumerable<Lead>> ObterTodosOsLeads();

        Task<IEnumerable<Lead>> ObterLeads(Expression<Func<Lead, bool>> expression, bool OrderByDesc = false, int take = 0);

        Task<Lead> ObterLeadPorId(Guid Id);
   
        ItemDeVenda ObterItemDeVendaAleatorio();

        bool VerificarExistenciaDoItemDeVenda(Guid ProdutoId, Guid CondominioId);

        void AdicionarLead(Lead Lead);
    }
}
