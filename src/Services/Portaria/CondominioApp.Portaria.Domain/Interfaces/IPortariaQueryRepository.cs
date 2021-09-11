using CondominioApp.Core.Data;
using CondominioApp.Portaria.Domain.FlatModel;
using CondominioApp.Portaria.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CondominioApp.Portaria.Domain.Interfaces
{
    public interface IPortariaQueryRepository : IRepository<VisitanteFlat>
    {  

        void AdicionarVisita(VisitaFlat entity);

        void AtualizarVisita(VisitaFlat entity);

        void ApagarVisita(Func<VisitaFlat, bool> predicate);

        Task<bool> VisitanteCadastradoPorId(Guid Id);

        
        Task<VisitaFlat> ObterVisitaPorId(Guid id);

        Task<IEnumerable<VisitaFlat>> ObterVisitas(Expression<Func<VisitaFlat, bool>> expression, bool OrderByDesc = false, int take = 0);

    }
}
