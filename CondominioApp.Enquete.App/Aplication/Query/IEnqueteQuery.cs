using CondominioApp.Enquetes.App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.Enquetes.App.Aplication.Query
{
    public interface IEnqueteQuery : IDisposable
    {
        Task<Enquete> ObterPorId(Guid Id);

        Task<IEnumerable<Enquete>> ObterTodos();

        Task<IEnumerable<Enquete>> ObterRemovidos();
    }
}