using CondominioApp.Automacao.Models;
using CondominioApp.Core.Data;
using CondominioApp.Core.Enumeradores;
using System;
using System.Threading.Tasks;

namespace CondominioApp.Automacao.App.Models
{
    public interface IAutomacaoRepository : IRepository<CondominioCredencial>
    {
        Task<bool> VerificaSeJaEstaCadastrado(Guid condominioId, TipoApiAutomacao tipoApiAutomacao);
    }
}