using CondominioApp.Core.Data;
using CondominioApp.Enquetes.App.Models;
using System;
using System.Threading.Tasks;

namespace CondominioApp.Enquetes.App.Models
{
    public interface IEnqueteRepository : IRepository<Enquete>
    {
        Task<AlternativaEnquete> ObterAlternativaPorId(Guid Id);

        void AdicionarResposta(RespostaEnquete entity);
    }
}