using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CondominioAppMarketplace.App.ViewModel;
using FluentValidation.Results;

namespace CondominioAppMarketplace.App.Interfaces
{
    public interface IAppServiceLead : IDisposable
    {
        Task<IEnumerable<LeadMarketplaceViewModel>> ObterTodos();

        Task<IEnumerable<LeadMarketplaceViewModel>> ObterPorVendedor(Guid VendedorId);

        Task<IEnumerable<LeadMarketplaceViewModel>> ObterPorParceiro(Guid ParceiroId);

        Task<ValidationResult> EnviarLead(LeadNovoViewModel ViewModel);
    }
}
