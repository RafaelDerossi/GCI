using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CondominioApp.Principal.Domain.FlatModel;

namespace CondominioApp.Principal.Aplication.Query.Interfaces
{
    public interface ICondominioQuery : IDisposable
    {
        Task<CondominioFlat> ObterPorId(Guid Id);

        Task<IEnumerable<CondominioFlat>> ObterTodos();

        Task<IEnumerable<CondominioFlat>> ObterRemovidos();

    }
}