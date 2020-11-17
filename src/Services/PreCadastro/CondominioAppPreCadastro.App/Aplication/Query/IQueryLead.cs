using CondominioAppPreCadastro.App.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioAppPreCadastro.App.Aplication.Query
{
    public interface IQueryLead : IDisposable
    {
        Task<LeadViewModel> ObterPorId(Guid Id);

        Task<IEnumerable<LeadViewModel>> ObterTodos();

        Task<IEnumerable<LeadViewModel>> ObterPorDatas(DateTime DataInicio, DateTime DataFim);

        Task<IEnumerable<LeadViewModel>> ObterPendentes();
    }
}