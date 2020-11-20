using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CondominioAppMarketplace.App.ViewModel;

namespace CondominioAppMarketplace.App.Interfaces
{
    public interface IAppServiceLead : IDisposable
    {
        Task<IEnumerable<LeadViewModel>> ObterTodos();

        Task<IEnumerable<LeadViewModel>> ObterPorVendedor(Guid VendedorId);

        Task<IEnumerable<LeadViewModel>> ObterPorParceiro(Guid ParceiroId);

        Task<bool> EnviarLead(LeadNovoViewModel ViewModel);
    }
}
