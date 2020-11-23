using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CondominioAppMarketplace.App.ViewModel;
using FluentValidation.Results;

namespace CondominioAppMarketplace.App.Interfaces
{
    public interface IAppServiceLead : IDisposable
    {
        Task<IEnumerable<LeadViewModel>> ObterTodos();

        Task<IEnumerable<LeadViewModel>> ObterPorVendedor(Guid VendedorId);

        Task<IEnumerable<LeadViewModel>> ObterPorParceiro(Guid ParceiroId);

        Task<ValidationResult> EnviarLead(LeadNovoViewModel ViewModel);
    }
}
