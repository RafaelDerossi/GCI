using CondominioApp.Core.Data;
using CondominioApp.Portaria.Domain;
using CondominioApp.Portaria.ValueObjects;
using System;
using System.Threading.Tasks;

namespace CondominioApp.Portaria.Domain.Interfaces
{
    public interface IVisitanteRepository : IRepository<Visitante>
    {
        Task<bool> VisitanteJaCadastradoPorCpf(Cpf cpf, Guid visitanteId);

        Task<bool> VisitanteJaCadastradoPorRg(Rg rg, Guid visitanteId);

        Task<Visitante> ObterPorIdAsNoTracking(Guid Id);

        void AdicionarVisita(Visita entity);

        void AtualizarVisita(Visita entity);

        Task<Visita> ObterVisitaPorId(Guid id);

    }
}
