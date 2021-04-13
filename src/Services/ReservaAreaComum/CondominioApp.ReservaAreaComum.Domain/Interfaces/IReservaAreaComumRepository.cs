using CondominioApp.Core.Data;
using System;
using System.Threading.Tasks;

namespace CondominioApp.ReservaAreaComum.Domain.Interfaces
{
    public interface IReservaAreaComumRepository : IRepository<AreaComum>
    {
        Task<Reserva> ObterReservaPorId(Guid id);

        Task<Guid> Obter_AreaComumId_Por_ReservaId(Guid reservaId);

        Task<int> ObterQtdDeReservasProcessando();

        Task<Reserva> ObterPrimeiraNaFilaParaSerProcessada();


        void AdicionarPeriodo(Periodo entity);

        void RemoverPeriodo(Periodo entity);

        void AdicionarReserva(Reserva entity);
    }
}
