using CondominioApp.Core.Data;
using CondominioApp.ReservaAreaComum.Domain.FlatModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CondominioApp.ReservaAreaComum.Domain.Interfaces
{
    public interface IReservaAreaComumQueryRepository : IRepository<AreaComumFlat>
    {
        void AdicionarReserva(ReservaFlat entity);

        void ApagarReserva(Func<ReservaFlat, bool> predicate);

        void AtualizarReserva(ReservaFlat entity);

        Task<IEnumerable<ReservaFlat>> ObterReserva(Expression<Func<ReservaFlat, bool>> expression, bool OrderByDesc = false, int take = 0);

        Task<ReservaFlat> ObterReservaPorId(Guid Id);


        void AdicionarPeriodo(PeriodoFlat entity);

        void RemoverPeriodo(PeriodoFlat entity);

        void AtualizarPeriodo(PeriodoFlat entity);

        Task<PeriodoFlat> ObterPeriodoPorId(Guid Id);
    }
}
