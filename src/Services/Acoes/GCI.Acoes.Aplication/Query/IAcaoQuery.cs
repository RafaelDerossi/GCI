using GCI.Acoes.Domain.FlatModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GCI.Acoes.Aplication.Query
{
    public interface IAcaoQuery
    {
        Task<AcaoFlat> ObterPorId(Guid Id);

        Task<AcaoFlat> ObterPorCodigo(string codigo);

        Task<IEnumerable<AcaoFlat>> ObterTodos();      
    }
}