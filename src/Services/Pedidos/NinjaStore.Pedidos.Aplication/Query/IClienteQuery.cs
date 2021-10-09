using NinjaStore.Pedidos.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NinjaStore.Pedidos.Aplication.Query
{
    public interface IClienteQuery : IDisposable
    {
        Task<Cliente> ObterPorId(Guid Id);

        Task<IEnumerable<Cliente>> ObterTodos();
    }
}