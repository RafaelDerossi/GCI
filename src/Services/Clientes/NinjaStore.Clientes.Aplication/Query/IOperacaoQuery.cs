using GCI.Acoes.Domain.FlatModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GCI.Acoes.Aplication.Query
{
    public interface IOperacaoQuery
    {
        Task<IEnumerable<OperacaoFlat>> ObterPorCodigo(string codigo);

        Task<IEnumerable<OperacaoFlat>> ObterTodas();        
    }
}