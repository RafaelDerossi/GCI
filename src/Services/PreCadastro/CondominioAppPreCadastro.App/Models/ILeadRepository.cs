using System;
using System.Threading.Tasks;
using CondominioApp.Core.Data;

namespace CondominioAppPreCadastro.App.Models
{
    public interface ILeadRepository : IRepository<Lead>
    {
        Task<Condominio> ObterCondominioPorId(Guid Id);
    }
}