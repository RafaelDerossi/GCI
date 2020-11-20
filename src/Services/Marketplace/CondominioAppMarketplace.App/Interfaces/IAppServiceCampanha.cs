using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CondominioAppMarketplace.App.ViewModel;
using FluentValidation.Results;

namespace CondominioAppMarketplace.App.Interfaces
{
    public interface IAppServiceCampanha : IDisposable
    {
        Task<IEnumerable<CampanhaViewModel>> CampanhasAtivas();

        Task<IEnumerable<CampanhaViewModel>> CampanhasExpiradas();

        Task<IEnumerable<CampanhaViewModel>> CampanhasFuturas();

        Task<IEnumerable<CampanhaViewModel>> CampanhasAtivasDoParceiro(Guid ParceiroId);

        Task<IEnumerable<CampanhaViewModel>> CampanhasExpiradasDoParceiro(Guid ParceiroId);

        Task<IEnumerable<CampanhaViewModel>> CampanhasFuturasDoParceiro(Guid ParceiroId);

        Task<ValidationResult> IniciarCampanha(CampanhaNovaViewModel ViewModel);

        Task<ValidationResult> ReconfigurarIntervalos(IntervaloDeCampanhaViewModel ViewModel);

        Task<bool> DeclinarCampanha(Guid CampanhaId);

        Task<bool> ContabilizarCliques(Guid CampanhaId);
    }
}
