using System;
using CondominioApp.Core.Data;

namespace CondominioAppMarketplace.Domain.Interfaces
{
    public interface ICampanhaRepository : IRepository<Campanha>
    {
        bool VerificaExistenciaDaCampanha(Guid ItemDeVendaId);
    }
}
