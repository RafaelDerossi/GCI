using CondominioApp.Core.Data;
using System;
using System.Threading.Tasks;

namespace CondominioApp.ReservaAreaComum.Domain.Interfaces
{
    public interface IAreaComumRepository : IRepository<AreaComum>
    {
        Task<Reserva> ObterReservaPorId(Guid id);

        Task<Guid> ObterAreaComumIdPorReservaId(Guid reservaId);

        void AdicionarPeriodo(Periodo entity);

        void RemoverPeriodo(Periodo entity);

        void AdicionarReserva(Reserva entity);
    }
}
