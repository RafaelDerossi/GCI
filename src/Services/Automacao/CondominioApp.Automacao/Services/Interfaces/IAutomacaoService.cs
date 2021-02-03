using CondominioApp.Automacao.Models.Credencial;
using CondominioApp.Automacao.Models.Dispositivo;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CondominioApp.Automacao.Services.Interfaces
{
   public interface IAutomacaoService
    {
        Task<Credencial> ObterCredencial(string email, string senha);

        Task<IEnumerable<Dispositivo>> ObterDispositivos(string email, string senha);

        Task<ValidationResult> LigarDesligarDispositivo(string email, string senha, string dispositivoId);
    }
}
