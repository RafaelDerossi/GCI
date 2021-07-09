using CondominioApp.Core.Enumeradores;
using CondominioApp.Correspondencias.App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.Correspondencias.App.Aplication.Query
{
    public interface ICorrespondenciaQuery : IDisposable
    {
        Task<Correspondencia> ObterPorId(Guid id);       

        Task<IEnumerable<Correspondencia>> ObterPorCondominioPeriodoEStatus(Guid condominioId, DateTime dataInicio, DateTime dataFim, StatusCorrespondencia status);

        Task<IEnumerable<Correspondencia>> ObterPorUnidadeEPeriodo(Guid unidadeId, DateTime dataInicio, DateTime dataFim);

        Task<Correspondencia> ObterPorCodigo(string codigo);
    }
}