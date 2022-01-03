using GCI.Acoes.Domain;
using GCI.Acoes.Domain.YhFinance;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GCI.Acoes.Aplication.Query
{
    public interface ICotacaoDeAcaoQuery : IDisposable
    {
        Task<Cota> ObterPorCodigo(string codigo);        
    }
}