using CondominioApp.Core.Data;
using CondominioApp.Portaria.Domain.FlatModel;
using CondominioApp.Portaria.ValueObjects;
using System;
using System.Threading.Tasks;

namespace CondominioApp.Portaria.Domain.Interfaces
{
    public interface IVisitanteQueryRepository : IRepository<VisitanteFlat>
    {  

        void AdicionarVisita(VisitaFlat entity);

        void AtualizarVisita(VisitaFlat entity);

        Task<VisitaFlat> ObterVisitaPorId(Guid id);

        Task<bool> VisitanteCadastradoPorId(Guid Id);

    }
}
