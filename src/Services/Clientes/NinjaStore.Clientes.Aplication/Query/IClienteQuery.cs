using GCI.Acoes.Domain.FlatModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GCI.Acoes.Aplication.Query
{
    public interface IClienteQuery
    {
        Task<ClienteFlat> ObterPorId(Guid Id);

        Task<IEnumerable<ClienteFlat>> ObterTodos();
    }
}