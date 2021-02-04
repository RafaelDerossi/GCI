using CondominioApp.Automacao.ViewModel;
using CondominioApp.Core.Enumeradores;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominioApp.Automacao.Services.Interfaces
{
   public interface IAutomacaoService
    {
        Task<IEnumerable<DispositivoViewModel>> ObterDispositivos(Guid condominioId, TipoApiAutomacao tipoApiAutomacao);

        Task<ValidationResult> LigarDesligarDispositivo(Guid condominioId, string dispositivoId);
    }
}
