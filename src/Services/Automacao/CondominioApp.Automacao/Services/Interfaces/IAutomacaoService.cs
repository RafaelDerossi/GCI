using CondominioApp.Automacao.ViewModel;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominioApp.Automacao.Services.Interfaces
{
   public interface IAutomacaoService
    {
        Task<CredencialViewModel> ObterCredencial(string email, string senha);

        Task<IEnumerable<DispositivoViewModel>> ObterDispositivos(string email, string senha);

        Task<ValidationResult> LigarDesligarDispositivo(string email, string senha, string dispositivoId);
    }
}
