using CondominioApp.Automacao.ViewModel;
using CondominioApp.Core.Service;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.Automacao.App.Services.Interfaces
{
   public interface IDispositivosService : IServiceBase
    {
        ValidationResult ValidationResult { get; }

        Task<IEnumerable<DispositivoViewModel>> ObterDispositivos();

        ValidationResult LigarDesligarDispositivo(string dispositivoId);
    }
}
