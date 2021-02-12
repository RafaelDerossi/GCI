using CondominioApp.Automacao.Models;
using CondominioApp.Automacao.ViewModel;
using CondominioApp.Core.Service;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioApp.Automacao.App.Services.Interfaces
{
   public interface IDispositivosService : IServiceBase
    {
        Task<IEnumerable<DispositivoViewModel>> ObterDispositivos();

        Task<ValidationResult> LigarDesligarDispositivo(string dispositivoId);
    }
}
